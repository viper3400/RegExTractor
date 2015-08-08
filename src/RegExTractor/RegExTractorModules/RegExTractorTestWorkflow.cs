using System;
using System.Collections.Generic;
using System.IO;
using RegExTractorShared;
using Ninject;

namespace RegExTractorModules
{
    public class RegExTractorTestWorkflow
    {
        public void Test()
        {
            var mainKernel = new StandardKernel(new RegExTractorTestModule());

            var fileList = mainKernel.Get<IFileListProvider>().GetFileList;
            var regExSearchTerms = mainKernel.Get<IRegExSearchTermProvider>().GetSearchTermList;

            var findings = new List<Finding>();
            foreach (var file in fileList)
            {
                findings.AddRange(mainKernel
                    .Get<IRegExCrawler>()
                    .Crawl(regExSearchTerms, File.ReadAllText(file.FullName)));
            }

            mainKernel.Get<IFileWriter>().WriteFindings(findings, "output.xml");
        }
    }
}
