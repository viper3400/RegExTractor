using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using RegExTractorShared;
using System.Threading;

namespace RegExTractor
{
    /// <summary>
    /// Provides methods for async iteration through a file list and perfoming a regExSearch for each
    /// </summary>
    public class AsyncFileIterator : IRegExFileIterator
    {

        private ManualResetEvent[] manualEvents;
        private System.Collections.Queue resultQueue;
        private bool canellationPending = false;
        
        /// <summary>
        /// Iterates through the given file list an spawn a new thread per file for peforming the RegEx search.
        /// </summary>
        /// <param name="FileList"></param>
        /// <param name="SearchTermList"></param>
        /// <param name="Crawler"></param>
        /// <returns></returns>
        public List<Finding> Iterate(List<FileInfo> FileList, List<RegExSearchTerm> SearchTermList, IRegExCrawler Crawler)
        {
            var start = DateTime.Now;
            resultQueue = new System.Collections.Queue();
            var chunkedFileLists = ChunkBy(FileList, 64);
            foreach (var chunkedList in chunkedFileLists)
            {
                SpawnThreads(chunkedList, SearchTermList, Crawler);
            }
            var duration = DateTime.Now - start;
            System.Diagnostics.Trace.TraceInformation(String.Format("Duration: {0}:{1}:{2} ",duration.Hours, duration.Minutes, duration.Seconds));

            var resultList = new List<Finding>();
            for (int i = 1; i <= resultQueue.Count; i++)
            {
               resultList.AddRange((List<Finding>)resultQueue.Dequeue());
            }
            return resultList;
        }

        private void SpawnThreads(List<FileInfo> FileList, List<RegExSearchTerm> SearchTermList, IRegExCrawler Crawler)
        {

            var threadCount = FileList.Count();
            manualEvents = new ManualResetEvent[threadCount];
            foreach (var file in FileList)
            {
                var currentIndex = FileList.IndexOf(file);
                System.Diagnostics.Trace.TraceInformation(String.Format("threadCount: {0}, currentIndex: {1} current File: {2}", threadCount, currentIndex, file.FullName));
                manualEvents[currentIndex] = new ManualResetEvent(false);
                ThreadPool.QueueUserWorkItem(DoWork, new object[] { file, SearchTermList, Crawler, manualEvents[currentIndex] });
            }

            WaitHandle.WaitAll(manualEvents);

        }

        public event EventHandler<ReportProgressEventArgs> SingleFileProcessed;

        /// <summary>
        /// Signal the async file iterator to canel all threads
        /// </summary>
        public void CancelAsync()
        {
            canellationPending = true;
        }

        private void DoWork(object ThreadContext)
        {
            object[] array = ThreadContext as object[];
            var file = array[0] as FileInfo;
            var searchTerms = array[1] as List<RegExSearchTerm>;
            var crawler = array[2] as IRegExCrawler;            
            var manualEvent = array[3] as ManualResetEvent;

            if (!canellationPending)
            {
                resultQueue.Enqueue(crawler
                   .Crawl(searchTerms, File.ReadAllText(file.FullName), file.Name, file.DirectoryName));

                if (SingleFileProcessed != null)
                {
                    SingleFileProcessed(this, new ReportProgressEventArgs() { Message = file.FullName + " processed." });
                }
            }
            manualEvent.Set();
        }

        private List<List<FileInfo>> ChunkBy(List<FileInfo> source, int chunkSize)
        {
            return source
                .Select((x, i) => new { Index = i, Value = x })
                .GroupBy(x => x.Index / chunkSize)
                .Select(x => x.Select(v => v.Value).ToList())
                .ToList();
        }


    }
}
