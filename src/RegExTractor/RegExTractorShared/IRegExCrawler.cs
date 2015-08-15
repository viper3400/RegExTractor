using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RegExTractorShared
{
    public interface IRegExCrawler
    {
        List<Finding> Crawl(List<RegExSearchTerm> SearchTerms, string Content, string FileName, string FileFolder);
        
        /// <summary>
        /// Occurs, when a single file from file list has been "crawled"
        /// </summary>
        event EventHandler<ReportProgressEventArgs> SingleFileCrawlFinished;
    }
}
