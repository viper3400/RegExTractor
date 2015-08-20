using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace RegExTractorShared
{
    public interface IRegExFileIterator
    {
        List<Finding> Iterate(List<FileInfo> FileList, List<RegExSearchTerm> SearchTermList, IRegExCrawler Crawler);
        event EventHandler<ReportProgressEventArgs> SingleFileProcessed;
        void CancelAsync();
    }
}
