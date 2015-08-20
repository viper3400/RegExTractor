using System;
using RegExTractorShared;
using RegExTractor;
using Ninject.Modules;


namespace RegExTractorModules
{
    public class RegExTractorSimpleModule : NinjectModule
    {        
        private string directory;
        private bool recursive;
        private string filter;
        private string searchTermInputFile;
        

        public RegExTractorSimpleModule(string Directory, bool Recursive, string Filter,string SearchTermInputFile)
        {
            directory = Directory;
            recursive = Recursive;
            filter = Filter;
            searchTermInputFile = SearchTermInputFile;
        }

        public override void Load()
        {
            Bind<IFileListProvider>()
                .To<SimpleFileListProvider>()
                .WithConstructorArgument("Directory", directory)
                .WithConstructorArgument("Recursive", recursive)
                .WithConstructorArgument("Filter", filter);

            Bind<IRegExSearchTermProvider>().To<FlatFileSearchTermProvider>().WithConstructorArgument("SearchTermsInputFile", searchTermInputFile);

            Bind<IRegExFileIterator>().To<AsyncFileIterator>();

            Bind<IRegExCrawler>().To<AsyncRegExCrawler>();

            Bind<IFileWriter>().To<FindingsXmlFileWriter>();
        }
    }
}