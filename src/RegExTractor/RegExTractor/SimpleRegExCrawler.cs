using System;
using System.Collections.Generic;
using System.Linq;
using RegExTractorShared;
using System.Text.RegularExpressions;

namespace RegExTractor
{
    public class SimpleRegExCrawler : IRegExCrawler
    {
        public List<Finding> Crawl(List<RegExSearchTerm> SearchTerms, string Content, string FileName, string FileFolder)
        {
            var findingResultList = new List<Finding>();

            // iterate through search terms
            // each search term may result in a finding
            // this finding will be added to finding result list
            foreach (var searchTerm in SearchTerms)
            {
                var finding = new Finding()
                {
                    Expression = searchTerm.Expression,
                    ExpressionFriendlyName = searchTerm.ExpressionFriendlyName,
                    FileName = FileName,
                    FileFolder = FileFolder,
                    Match = new List<RegExTractorMatchCollection>()
                };

                var regEx = new Regex(searchTerm.Expression);
                var regExMatchCollection = regEx.Matches(Content);

                // the System.Text.RegularExpression.Regex.Matches has not index
                // so we have to count the iterations by ourself
                int matchCount = 0;

                // iterate through match collection
                foreach (Match regExMatch in regExMatchCollection)
                {
                    // increase matchCount
                    matchCount++;
                    // create a new RegExtractorMatchCollection
                    var resultMatchCollection = new RegExTractorMatchCollection()
                    {
                        // set the id of the collection
                        Id = matchCount, MatchCollection = new List<RegExTractorMatch>()
                    };

                    // count match groups
                    var groupsCount = regExMatch.Groups.Count;

                    // loop throug groups
                    for (int g = 0; g < groupsCount; g++)
                    {
                        // create a single RegExTractorMatch
                        var resultMatch = new RegExTractorMatch()
                        {
                            Id = g + 1,
                            Match = regExMatch.Groups[g].Value
                        };
                        // add this match to result collection
                        resultMatchCollection.MatchCollection.Add(resultMatch);
                    }

                    // add the result match collection to finding result
                    finding.Match.Add(resultMatchCollection);

                }                
                // add finding to findig list
                findingResultList.Add(finding);
            }

            // report progress
            var eventArgs = new ReportProgressEventArgs();
            eventArgs.Message = String.Format(@"Finished search in file {0}\{1}",FileFolder, FileName);                
            OnSingleFileCrawlFinished(eventArgs);
            
            return findingResultList;
        }


        protected void OnSingleFileCrawlFinished(ReportProgressEventArgs e)
        {
            EventHandler<ReportProgressEventArgs> handler = SingleFileCrawlFinished;
            if (handler != null)
            {
                handler(this, e);
            }
        }

        public event EventHandler<ReportProgressEventArgs> SingleFileCrawlFinished;
    }
}
