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

        /// <summary>
        ///  This is a test to test a regular expression wich will
        ///  return 4 results to 3 groups
        /// </summary>
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
            var actual = crawler.Crawl(regExSearchList, content, expected[0].FileName, expected[0].FileFolder);

            Assert.AreEqual(expected[0].Expression, actual[0].Expression);
            Assert.AreEqual(expected[0].ExpressionFriendlyName, actual[0].ExpressionFriendlyName);
            Assert.AreEqual(expected[0].FileFolder, actual[0].FileFolder);
            Assert.AreEqual(expected[0].FileName, actual[0].FileName);

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

        /// <summary>
        /// This is a testcase which will test just one regular expression
        /// with one expected result without overload
        /// </summary>
        [TestCase]
        [Category(TESTCATEGORY)]
        public void A02_SimpleRegexCrawlerOneExpressionOneResultTest()
        {

            string content = File.ReadAllText("./Testdata/testdata.log");

            var regExSearchTerm = new RegExSearchTerm()
            {
                Expression = @"2015-06-27 12:03:04,721  INFO   \[EJB default - 5\] RuleChangeCommand executeChange - Setting entry 00.2285 to MODIFY",
                ExpressionFriendlyName = "Ex1"
            };

            var expectedFinding = new Finding()
            {
                Expression = @"2015-06-27 12:03:04,721  INFO   \[EJB default - 5\] RuleChangeCommand executeChange - Setting entry 00.2285 to MODIFY",
                ExpressionFriendlyName = "Ex1",
                Match = new List<RegExTractorMatchCollection>()
                {
                   new RegExTractorMatchCollection()
                   {
                       Id = 1,
                       MatchCollection = new List<RegExTractorMatch>()
                       {
                           new RegExTractorMatch()
                           {
                               Id = 1,
                               Match = "2015-06-27 12:03:04,721  INFO   [EJB default - 5] RuleChangeCommand executeChange - Setting entry 00.2285 to MODIFY"
                           }
                       }
                   }
                }
            };

            IRegExCrawler crawler = new SimpleRegExCrawler();
            var actual = crawler.Crawl(new List<RegExSearchTerm>(){ regExSearchTerm}, content, expectedFinding.FileName, expectedFinding.FileFolder);

            var expected = new List<Finding>() { expectedFinding };

            Assert.AreEqual(expected[0].Expression, actual[0].Expression);
            Assert.AreEqual(expected[0].ExpressionFriendlyName, actual[0].ExpressionFriendlyName);
            Assert.AreEqual(expected[0].FileFolder, actual[0].FileFolder);
            Assert.AreEqual(expected[0].FileName, actual[0].FileName);

            var matchCount = actual[0].Match.Count();
            Assert.AreEqual(1, matchCount);


            for (int i = 0; i <= matchCount; i++)
            {
                var expectedMatch = expected[0].Match[0];
                var actualMatch = actual[0].Match[0];

                Assert.AreEqual(expectedMatch.Id, actualMatch.Id);
                Assert.AreEqual(expectedMatch.MatchCollection[0].Id, actualMatch.MatchCollection[0].Id);
            }
        }

        
        /// <summary>
        /// This testcase comnines A01 and A03 two find multiple
        /// regular expression with multiple results
        /// </summary>
        [TestCase]
        [Category(TESTCATEGORY)]
        public void A03_SimpleRegExCrawlerTwoExpressionMultipleResultTest()
        {
            // Read the content
            string content = File.ReadAllText("./Testdata/testdata.log");

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
            var regExSearchList = new List<RegExSearchTerm>() { regExSearchTerm1, regExSearchTerm2 };

            // build the expected findigs
            // build finding one
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


            // build finding two
            var expectedFinding2 = new Finding()
            {
                Expression = @"2015-06-27 12:03:04,721  INFO   \[EJB default - 5\] RuleChangeCommand executeChange - Setting entry 00.2285 to MODIFY",
                ExpressionFriendlyName = "Ex1",
                Match = new List<RegExTractorMatchCollection>()
                {
                   new RegExTractorMatchCollection()
                   {
                       Id = 1,
                       MatchCollection = new List<RegExTractorMatch>()
                       {
                           new RegExTractorMatch()
                           {
                               Id = 1,
                               Match = "2015-06-27 12:03:04,721  INFO   [EJB default - 5] RuleChangeCommand executeChange - Setting entry 00.2285 to MODIFY"
                           }
                       }
                   }
                }
            };

            // build expected findings list
            var expected = new List<Finding>() { expectedFinding1, expectedFinding2 };

            // do the magic and crawl!
            IRegExCrawler crawler = new SimpleRegExCrawler();
            var actual = crawler.Crawl(regExSearchList, content, expectedFinding1.FileName, expectedFinding1.FileFolder);

            // check the results
            // result for finding one
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


            // result for finding two
            Assert.AreEqual(expected[1].Expression, actual[1].Expression);
            Assert.AreEqual(expected[1].ExpressionFriendlyName, actual[1].ExpressionFriendlyName);
            //Assert.AreEqual(expected.FirstOrDefault().FileFolder, actual.FirstOrDefault().FileFolder);
            //Assert.AreEqual(expected.FirstOrDefault().FileName, actual.FirstOrDefault().FileName);

            matchCount = actual[1].Match.Count();
            Assert.AreEqual(1, matchCount);


            for (int i = 0; i <= matchCount; i++)
            {
                var expectedMatch = expected[1].Match[0];
                var actualMatch = actual[1].Match[0];

                Assert.AreEqual(expectedMatch.Id, actualMatch.Id);
                Assert.AreEqual(expectedMatch.MatchCollection[0].Id, actualMatch.MatchCollection[0].Id);
            }



        }
    }
}
