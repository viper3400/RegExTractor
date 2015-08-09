using System;
using System.IO;
using System.Collections.Generic;
using RegExTractorShared;


namespace RegExTractor
{
    public class FlatFileSearchTermProvider : IRegExSearchTermProvider
    {
        private string searchTermsInputFile;

        public FlatFileSearchTermProvider (string SearchTermsInputFile)
        {
            searchTermsInputFile = SearchTermsInputFile;
        }
        

        public System.Collections.Generic.List<RegExSearchTerm> GetSearchTermList
        {
            get { return ReadSearchTermsFromFile(); }
        }

        private List<RegExSearchTerm> ReadSearchTermsFromFile()
        {
            // create the result list
            var regExSearchTermList = new List<RegExSearchTerm>();
            // read the input file
            var fileContent = File.ReadAllLines(searchTermsInputFile);
            
            // fileContent has no index so we've to create a counter on our own
            int expressionCounter = 0;

            foreach(var line in fileContent)
            {
                expressionCounter++;

                regExSearchTermList.Add(
                    new RegExSearchTerm()
                    {
                        Expression = line,
                        ExpressionFriendlyName = "Expression " + expressionCounter.ToString()
                    });
            }

            return regExSearchTermList;

        }
    }
}
