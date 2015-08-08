using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RegExTractorShared;

namespace RegExTractor
{
    public class DummySearchTermProvider :  IRegExSearchTermProvider
    {
        public List<RegExSearchTerm> GetSearchTermList
        {
            get 
            {
                // build search term one
                var regExSearchTerm1 = new RegExSearchTerm()
                {
                    Expression = @"(\d{4}-\d{2}-\d{2}).+(CatalogCacheUpdateJob perform)(.+)",
                    ExpressionFriendlyName = "SearchTerm 1"
                };

                // build search term two
                var regExSearchTerm2 = new RegExSearchTerm()
                {
                    Expression = @"2015-06-27 12:03:04,721  INFO   \[EJB default - 5\] RuleChangeCommand executeChange - Setting entry 00.2285 to MODIFY",
                    ExpressionFriendlyName = "Ex1"
                };

                // fill the search term list
                return new List<RegExSearchTerm>() { regExSearchTerm1, regExSearchTerm2 };


            }
        }
    }
}
