using System;
using System.Collections.Generic;
using RegExTractorShared;
using RegExTractor;
using NUnit.Framework;

namespace RegExTractorTests
{

    [TestFixture]
    public class IRegExSearchTermProviderTest
    {
        const string TESTCATEGORY = "IRegExSearchTermProviderTest";

        [TestCase]
        [Category(TESTCATEGORY)]
        public void A01_FlatFileSearchTermProviderTest()
        {
            var testDataFilePath = @".\Testdata\IRegExSearchTermProviderTest\FlatFileSearchTerms.txt";

            var expected = new List<RegExSearchTerm>()
            {
                new RegExSearchTerm()
                {
                    Expression = @"(\d{4}-\d{2}-\d{2}).+(CatalogCacheUpdateJob perform)(.+)",
                    ExpressionFriendlyName = "Expression 1"
                },
                new RegExSearchTerm()
                {
                    Expression = @"2015-06-27 12:03:04,721  INFO   \[EJB default - 5\] RuleChangeCommand executeChange - Setting entry 00.2285 to MODIFY",
                    ExpressionFriendlyName = "Expression 2"
                }
            };

            IRegExSearchTermProvider searchProvider = new FlatFileSearchTermProvider(testDataFilePath);
            var actual = searchProvider.GetSearchTermList;

            Assert.AreEqual(expected[0].Expression, actual[0].Expression);
            Assert.AreEqual(expected[0].ExpressionFriendlyName, actual[0].ExpressionFriendlyName);

            Assert.AreEqual(expected[1].Expression, actual[1].Expression);
            Assert.AreEqual(expected[1].ExpressionFriendlyName, actual[1].ExpressionFriendlyName);
        }

    }
}
