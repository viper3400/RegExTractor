using System;
using System.Collections.Generic;
using System.IO;
using RegExTractorShared;
using Ninject;

namespace RegExTractorModules
{
    public class RegExTractorSimpleWorkflow
    {

        private IRegExFileIterator fileIterator;

        public void Process(string Directory, bool Recursive, string Filter, string SearchTermInputFile, string XmlOutputFile, int MaxThreads)
        {
            var mainKernel = new StandardKernel(
                new RegExTractorSimpleModule(Directory,Recursive,Filter,SearchTermInputFile, MaxThreads));


            // get IRegExCrawler and register event
            var regExCrawler = mainKernel.Get<IRegExCrawler>();
            regExCrawler.SingleFileCrawlFinished += RegExTractorSimpleWorkflow_SingleFileCrawlFinished;

            var fileList = mainKernel.Get<IFileListProvider>().GetFileList;
            var regExSearchTerms = mainKernel.Get<IRegExSearchTermProvider>().GetSearchTermList;

            fileIterator = mainKernel.Get<IRegExFileIterator>();
            fileIterator.SingleFileProcessed += fileIterator_SingleFileProcessed;
            var findings = fileIterator.Iterate(fileList, regExSearchTerms, regExCrawler);

            mainKernel.Get<IFileWriter>().WriteFindings(findings, XmlOutputFile);
            fileIterator = null;
        
        }



        void fileIterator_SingleFileProcessed(object sender, ReportProgressEventArgs e)
        {
            OnSingleFileCrawlFinished(e);
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

        // Request async cancel of workflow
        public void CancelAsync()
        {
            if (fileIterator != null) fileIterator.CancelAsync();            
        }
    }
}
