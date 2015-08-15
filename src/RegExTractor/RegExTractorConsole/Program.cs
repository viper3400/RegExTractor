using System;
using RegExTractorModules;


namespace RegExTractorConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            var options = new RegExTractorOptions();
            if (CommandLine.Parser.Default.ParseArguments(args, options))
            {
                var workflow = new RegExTractorSimpleWorkflow();
                workflow.SingleFileCrawlFinished += workflow_SingleFileCrawlFinished;
                workflow.Process(options.Directory, options.Recursive, options.Filter, options.SearchTermInputFile, options.OutputFile);
            }
            
            Console.WriteLine("Finished ... Press any key ...");
            Console.ReadKey();
        }

        static void workflow_SingleFileCrawlFinished(object sender, RegExTractorShared.ReportProgressEventArgs e)
        {
            Console.WriteLine(e.Message);
        }
    }
}
