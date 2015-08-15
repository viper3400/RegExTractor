using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
 
using RegExTractorShared;
using System.Xml;

namespace RegExTractor
{
    public class FindingsXmlFileWriter : IFileWriter
    {

        public void WriteFindings(List<Finding> Findings, string OutputFile)
        {

            var xmlWriter = XmlWriter.Create(OutputFile, new XmlWriterSettings(){ Indent = true});            
            xmlWriter.WriteStartDocument();
            xmlWriter.WriteStartElement("Findings");
            xmlWriter.WriteAttributeString("Exportmodule", "FindingsXmlFileWriter");
            xmlWriter.WriteAttributeString("Exportversion", "1");

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

                xmlWriter.WriteStartElement("MatchCollections");
                foreach (var matchCollection in finding.Match)
                {
                    xmlWriter.WriteStartElement("MatchCollection");
                    xmlWriter.WriteAttributeString("Id", matchCollection.Id.ToString());

                    foreach (var match in matchCollection.MatchCollection)
                    {
                        xmlWriter.WriteStartElement("Match");
                        xmlWriter.WriteAttributeString("Id", match.Id.ToString());
                        xmlWriter.WriteString(match.Match);
                        // end <Match>
                        xmlWriter.WriteEndElement();
                    }

                    xmlWriter.WriteEndElement();
                }
                // end <MatchCollections>
                xmlWriter.WriteEndElement();

                // end <Finding>
                xmlWriter.WriteEndElement();
            }

            // end <Findings>
            xmlWriter.WriteEndElement();
            xmlWriter.WriteEndDocument();
            xmlWriter.Close();
        }

        private void GetFindings()
        {

        }

        
    }
}

