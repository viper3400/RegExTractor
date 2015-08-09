using System;
using CommandLine;
using CommandLine.Text;

namespace RegExTractorConsole
{

    public class RegExTractorOptions
    {
        [Option('d',"directory",Required=true, HelpText="Directory to wich the search will be applied.")]
        public string Directory { get; set; }

        [Option('r',"recursive",Required=true, HelpText="Definies if the search runs in recursive mode.")]
        public bool Recursive { get; set; }

        [Option('f',"filter",Required=false, DefaultValue="*",HelpText="Filter for files to search in.")]
        public string Filter { get; set; }

        [Option('s',"searchtermfile",Required=true, HelpText="Set the input file which holds the search terms.")]
        public string SearchTermInputFile { get; set; }

        [Option('o',"outputfile", Required=true, HelpText="Sets the xml output file.")]
        public string OutputFile { get; set; }

        [ParserState]
        public IParserState LastParserState { get; set; }

        [HelpOption]
        public string GetUsage()
        {
            return HelpText.AutoBuild(this,
              (HelpText current) => HelpText.DefaultParsingErrorsHandler(this, current));
        }
    }
}
