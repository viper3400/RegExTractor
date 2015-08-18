using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RegExTractorShared;
using System.Threading;

namespace RegExTractor
{
    /// <summary>
    /// Enhanced class implementing IRegExCrawler. 
    /// </summary>
    public class AsyncRegExCrawler : IRegExCrawler
    {
        private List<Finding> resultList;
        private ManualResetEvent[] manualEvents;        
        
        /// <summary>
        /// Parse the given content with the given search terms. Every search term
        /// will be processed in it's own thread to increase 
        /// overall search performance.
        /// </summary>
        /// <param name="SearchTerms"></param>
        /// <param name="Content"></param>
        /// <param name="FileName"></param>
        /// <param name="FileFolder"></param>
        /// <returns></returns>
        /// <remarks>This method split the search term list into new lists with only
        /// one item per list. This single item lists are passed to a new threaded
        /// SimpleRegExCrawler class.</remarks>
        /// <seealso cref="SimpleRegExCrawler"/>
        public List<Finding> Crawl(List<RegExSearchTerm> SearchTerms, string Content, string FileName, string FileFolder)        
        {
            resultList = new List<Finding>();
            var threadCount = SearchTerms.Count;
            manualEvents = new ManualResetEvent[threadCount];
            

            foreach (var searchTerm in SearchTerms)
            {
                var searchTermIndex = SearchTerms.IndexOf(searchTerm);
                manualEvents[searchTermIndex] = new ManualResetEvent(false);
                ThreadPool.QueueUserWorkItem(DoWork, new object[] { searchTerm, Content, FileName, FileFolder, manualEvents[searchTermIndex]});
            }
            WaitHandle.WaitAll(manualEvents);
            return resultList;
        }

        public event EventHandler<ReportProgressEventArgs> SingleFileCrawlFinished;
        
       
        
        
        private void DoWork(object ThreadContext)
        {
            object [] array = ThreadContext as object[];
            var searchTerm = array[0] as RegExSearchTerm;
            var content = array[1] as string;
            var fileName = array[2] as string;
            var fileFolder = array[3] as string;
            var manualEvent = array[4] as ManualResetEvent;

            var regExCrawler = new SimpleRegExCrawler();
            regExCrawler.SingleFileCrawlFinished += regExCrawler_SingleFileCrawlFinished;
            resultList.AddRange(regExCrawler.Crawl(new List<RegExSearchTerm>() { searchTerm }, content, fileName, fileFolder));
            manualEvent.Set();
        }

        void regExCrawler_SingleFileCrawlFinished(object sender, ReportProgressEventArgs e)
        {
            // report progress                       
            if (SingleFileCrawlFinished != null)
            {
                SingleFileCrawlFinished(this, e);
            }
        }
           
    }
}
