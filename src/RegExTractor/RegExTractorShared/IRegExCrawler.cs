using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RegExTractorShared
{
    public interface IRegExCrawler
    {
        List<Finding> Crawl(List<RegExSearchTerm> SearchTerms, string Content, string FileName, string FileFolder);
    }
}
