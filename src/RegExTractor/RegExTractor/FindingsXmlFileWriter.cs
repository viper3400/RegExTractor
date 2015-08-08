using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RegExTractorShared;
using System.Xml;

namespace RegExTractor
{
    public class FindingsXmlFileWriter : IFileWriter
    {

        public void WriteFindings(List<Finding> Findings, string OutputFile)
        {

            var xmlWriter = XmlWriter.Create(OutputFile);
            xmlWriter.WriteStartDocument();
            xmlWriter.WriteStartElement("Findings");

            foreach (var finding in Findings)
            {
                xmlWriter.WriteStartElement("Finding");
                xmlWriter.WriteAttributeString("Expression", finding.Expression);
                xmlWriter.WriteAttributeString("ExpressionFriendlyName", finding.ExpressionFriendlyName);
                
                xmlWriter.WriteStartElement("FileName");
                xmlWriter.WriteString(finding.FileName);
                xmlWriter.WriteEndElement();

                xmlWriter.WriteStartElement("FileFolder");
                xmlWriter.WriteString(finding.FileFolder);
                xmlWriter.WriteEndElement();

                foreach (var matchCollection in finding.Match)
                {
                    xmlWriter.WriteStartElement("MatchCollection");
                    xmlWriter.WriteAttributeString("Id", matchCollection.Id.ToString());

                    foreach (var match in matchCollection.MatchCollection)
                    {
                        xmlWriter.WriteStartElement("Match");
                        xmlWriter.WriteAttributeString("Id", match.Id.ToString());
                        xmlWriter.WriteString(match.Match);
                        xmlWriter.WriteEndElement();
                    }

                    xmlWriter.WriteEndElement();
                }

                xmlWriter.WriteEndElement();
            }

            xmlWriter.WriteEndElement();
            xmlWriter.WriteEndDocument();
            xmlWriter.Close();
        }

        private void GetFindings()
        {

        }

        
    }
}

