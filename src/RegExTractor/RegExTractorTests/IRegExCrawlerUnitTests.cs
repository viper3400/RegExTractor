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

            Assert.AreEqual(expected.FirstOrDefault().Expression, actual.FirstOrDefault().Expression);
            Assert.AreEqual(expected.FirstOrDefault().ExpressionFriendlyName, actual.FirstOrDefault().ExpressionFriendlyName);
            Assert.AreEqual(expected.FirstOrDefault().FileFolder, actual.FirstOrDefault().FileFolder);
            Assert.AreEqual(expected.FirstOrDefault().FileName, actual.FirstOrDefault().FileName);

            var matchCount = actual.FirstOrDefault().Match.Count();
            Assert.AreEqual(4, matchCount);

            for (int i = 1; i <= matchCount;  i++)
            {
                Assert.AreEqual(expected.FirstOrDefault().Match[i].Id, actual.FirstOrDefault().Match[i].Id);

                var collectionCount = actual.FirstOrDefault().Match[i].MatchCollection.Count();
                Assert.AreEqual(3,collectionCount);

                for (int k = 1; k <= collectionCount; k++)
                {
                    Assert.AreEqual(expected.FirstOrDefault().Match[i].MatchCollection[k].Id, actual.FirstOrDefault().Match[i].MatchCollection[k].Id);
                    Assert.AreEqual(expected.FirstOrDefault().Match[i].MatchCollection[k].Match, actual.FirstOrDefault().Match[i].MatchCollection[k].Match);
                }
            }
            

            
        }
    }
}
