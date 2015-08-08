using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RegExTractorShared;
using RegExTractor;
using NUnit.Framework;

namespace RegExTractorTests
{
    [TestFixture]
    public class IFileWriterUnitTests
    {
        const string TESTCATEGORY = "IFileWriterUnitTests";

        private List<Finding> GetTestFindingList
        {
            get
            {
                return new List<Finding>()
                {
                    GetTestFindingOne
                };

            }
        }

        private Finding GetTestFindingOne
        {
            get
            {
                return new Finding()
                {
                    Expression = @"\d{3}.TEST",
                    ExpressionFriendlyName = "FindingOneExpression",
                    FileFolder = @"C:\TEMP",
                    FileName = "Test1.txt",
                    Match = GetRegExtractorTestMatchCollection

                };
            }
        }

        private RegExTractorMatch GetRegExTractorTestMatch(int Id, string Match)
        {
           return new RegExTractorMatch()
               {
                   Id = Id, 
                   Match = Match
               };
        }

        private List<RegExTractorMatchCollection> GetRegExtractorTestMatchCollection
        {
            get
            {
               return new List<RegExTractorMatchCollection>()
                    {
                        new RegExTractorMatchCollection()
                        {
                            Id = 1,
                            MatchCollection = new List<RegExTractorMatch>()
                            {
                                GetRegExTractorTestMatch(1, "MatchCollection 1 Match 1"),
                                GetRegExTractorTestMatch(2, "MatchCollection 1 Match 2")
                            }
                        },

                        new RegExTractorMatchCollection()
                        {
                            Id = 2,
                            MatchCollection = new List<RegExTractorMatch>()
                            {
                                GetRegExTractorTestMatch(1, "MatchCollection 2 Match 1")                                
                            }
                        }
                    };
            }
        }

        [TestCase]
        [Category(TESTCATEGORY)]
        public void FindingsXmlWriterTest()
        {
            IFileWriter writer = new FindingsXmlFileWriter();
            writer.WriteFindings(GetTestFindingList, "actualXmlFileOutput.xml");
            FileAssert.AreEqual(@".\Testdata\ExpectedXmlFileOutput.xml", "actualXmlFileOutput.xml");
        }
    }


}
