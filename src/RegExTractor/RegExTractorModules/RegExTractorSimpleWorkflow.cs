using System;
using System.Collections.Generic;
using System.IO;
using RegExTractorShared;
using Ninject;

namespace RegExTractorModules
{
    public class RegExTractorSimpleWorkflow
    {
        public void Process(string Directory, bool Recursive, string Filter, string SearchTermInputFile, string XmlOutputFile)
        {
            var mainKernel = new StandardKernel(
                new RegExTractorSimpleModule(Directory,Recursive,Filter,SearchTermInputFile));


            // get IRegExCrawler and register event
            var regExCrawler = mainKernel.Get<IRegExCrawler>();
            regExCrawler.SingleFileCrawlFinished += RegExTractorSimpleWorkflow_SingleFileCrawlFinished;

            var fileList = mainKernel.Get<IFileListProvider>().GetFileList;
            var regExSearchTerms = mainKernel.Get<IRegExSearchTermProvider>().GetSearchTermList;

            var findings = new List<Finding>();
            foreach (var file in fileList)
            {
                findings.AddRange(regExCrawler
                    .Crawl(regExSearchTerms, File.ReadAllText(file.FullName),file.Name,file.DirectoryName));
            }

            mainKernel.Get<IFileWriter>().WriteFindings(findings, XmlOutputFile);
        }

        /// <summary>
        /// Raised when single file scan finished
        /// </summary>
        public event EventHandler<ReportProgressEventArgs> SingleFileCrawlFinished;

        protected void OnSingleFileCrawlFinished(ReportProgressEventArgs e)
        {
            EventHandler<ReportProgressEventArgs> handler = SingleFileCrawlFinished;
            if (handler != null)
            {
                handler(this, e);
            }
        }

        
        private void RegExTractorSimpleWorkflow_SingleFileCrawlFinished(object sender, ReportProgressEventArgs e)
        {
            OnSingleFileCrawlFinished(e);
        }
    }
}
