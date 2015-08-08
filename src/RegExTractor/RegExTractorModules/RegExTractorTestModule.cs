using System;
using RegExTractorShared;
using RegExTractor;
using Ninject.Modules;


namespace RegExTractorModules
{
    public class RegExTractorTestModule : NinjectModule
    {
        private string directory = @"C:\Users\Jan\Desktop\DESKTEMP\prod_node2_01.06.2015-30.07.2015";
        private bool recursive = false;
        private string filter = "*";
        
        public override void Load()
        {
            Bind<IFileListProvider>()
                .To<SimpleFileListProvider>()
                .WithConstructorArgument("Directory", directory)
                .WithConstructorArgument("Recursive", recursive)
                .WithConstructorArgument("Filter", filter);

            Bind<IRegExSearchTermProvider>().To<DummySearchTermProvider>();

            Bind<IRegExCrawler>().To<SimpleRegExCrawler>();

            Bind<IFileWriter>().To<FindingsXmlFileWriter>();
        }
    }
}