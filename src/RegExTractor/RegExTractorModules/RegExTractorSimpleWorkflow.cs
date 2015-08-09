using System;
using System.Collections.Generic;
using System.IO;
using RegExTractorShared;
using Ninject;

namespace RegExTractorModules
{
    public class RegExTractorSimpleWorkflow
    {
        public void Process(string Directory, bool Recursive, string Filter, string SearchTermInputFile, string XmlOutputFile)
        {
            var mainKernel = new StandardKernel(
                new RegExTractorSimpleModule(Directory,Recursive,Filter,SearchTermInputFile));

            var fileList = mainKernel.Get<IFileListProvider>().GetFileList;
            var regExSearchTerms = mainKernel.Get<IRegExSearchTermProvider>().GetSearchTermList;

            var findings = new List<Finding>();
            foreach (var file in fileList)
            {
                findings.AddRange(mainKernel
                    .Get<IRegExCrawler>()
                    .Crawl(regExSearchTerms, File.ReadAllText(file.FullName),file.Name,file.DirectoryName));
            }

            mainKernel.Get<IFileWriter>().WriteFindings(findings, XmlOutputFile);
        }
    }
}
