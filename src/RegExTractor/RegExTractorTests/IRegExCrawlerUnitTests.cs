using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using RegExTractorShared;
using RegExTractor;
using NUnit.Framework;

namespace RegExTractorTests
{
    [TestFixture]
    public class IRegExCrawlerUnitTests
    {
        const string TESTCATEGORY = "IRegExCrawlerUnitTest";

        [TestCase]
        [Category(TESTCATEGORY)]
        public void A01_SimpleRexExCrawlerTest()
        {
            string content = File.ReadAllText("./Testdata/testdata.log");

            var regExSearchTerm1 = new RegExSearchTerm()
            {
                Expression = @"(\d{4}-\d{2}-\d{2}).+(CatalogCacheUpdateJob perform)(.+)",
                ExpressionFriendlyName = "SearchTerm 1"
            };

            var regExSearchList = new List<RegExSearchTerm>() { regExSearchTerm1 };



            var expectedFinding1 = new Finding()
            {
                Expression = @"(\d{4}-\d{2}-\d{2}).+(CatalogCacheUpdateJob perform)(.+)",
                ExpressionFriendlyName = "SearchTerm 1",
                FileFolder = @"D:\WORK\RegExTractor\src\RegExTractor\RegExTractorTests\bin\Debug\Testdata",
                FileName = "testdata.log",
                Match = new List<RegExTractorMatchCollection>()
                {
                    // first match
                    new RegExTractorMatchCollection()
                    {
                        Id = 1,
                        MatchCollection = new List<RegExTractorMatch>()
                        {                        
                            new RegExTractorMatch()
                            { 
                                Id = 1,
                                Match = "2015-06-27"
                            },
                            new RegExTractorMatch()
                            {
                                Id = 2,
                                Match = "CatalogCacheUpdateJob perform"
                            },
                            new RegExTractorMatch()
                            {
                                Id = 3,
                                Match = " - Performing scheduled reload of catalog cache..."
                            }
                        }
                    },

                    // second match
                    new RegExTractorMatchCollection()
                    {
                        Id = 2,
                        MatchCollection = new List<RegExTractorMatch>()
                        {                        
                            new RegExTractorMatch()
                            { 
                                Id = 1,
                                Match = "2015-06-27"
                            },
                            new RegExTractorMatch()
                            {
                                Id = 2,
                                Match = "CatalogCacheUpdateJob perform"
                            },
                            new RegExTractorMatch()
                            {
                                Id = 3,
                                Match = " - Scheduled catalog cache reload successfully completed."
                            }
                        }
                    },

                    // third match
                    new RegExTractorMatchCollection()
                    {
                        Id = 3,
                        MatchCollection = new List<RegExTractorMatch>()
                        {                        
                            new RegExTractorMatch()
                            { 
                                Id = 1,
                                Match = "2015-06-28"
                            },
                            new RegExTractorMatch()
                            {
                                Id = 2,
                                Match = "CatalogCacheUpdateJob perform"
                            },
                            new RegExTractorMatch()
                            {
                                Id = 3,
                                Match = " - Performing scheduled reload of catalog cache..."
                            }
                        }
                    },

                    // fourth match
                    new RegExTractorMatchCollection()
                    {
                        Id = 4,
                        MatchCollection = new List<RegExTractorMatch>()
                        {                        
                            new RegExTractorMatch()
                            { 
                                Id = 1,
                                Match = "2015-06-28"
                            },
                            new RegExTractorMatch()
                            {
                                Id = 2,
                                Match = "CatalogCacheUpdateJob perform"
                            },
                            new RegExTractorMatch()
                            {
                                Id = 3,
                                Match = " - Scheduled catalog cache reload successfully completed."
                            }
                        }
                    }

                }             
            };

            var expected = new List<Finding>() { expectedFinding1 };

            IRegExCrawler crawler = new SimpleRegExCrawler();
            var actual = crawler.Crawl(regExSearchList, content);

            Assert.AreEqual(expected[0].Expression, actual[0].Expression);
            Assert.AreEqual(expected[0].ExpressionFriendlyName, actual[0].ExpressionFriendlyName);
            //Assert.AreEqual(expected.FirstOrDefault().FileFolder, actual.FirstOrDefault().FileFolder);
            //Assert.AreEqual(expected.FirstOrDefault().FileName, actual.FirstOrDefault().FileName);

            var matchCount = actual[0].Match.Count();
            Assert.AreEqual(4, matchCount);

           
            for (int i = 0; i <= matchCount; i++)
            {
                var expectedMatch = expected[0].Match[0];
                var actualMatch = actual[0].Match[0];

                Assert.AreEqual(expectedMatch.Id, actualMatch.Id);
                Assert.AreEqual(expectedMatch.MatchCollection[0].Id, actualMatch.MatchCollection[0].Id);
                Assert.AreEqual(expectedMatch.MatchCollection[1].Id, actualMatch.MatchCollection[1].Id);
                Assert.AreEqual(expectedMatch.MatchCollection[2].Id, actualMatch.MatchCollection[2].Id);
            }


            


            
            

            
        }
    }
}
