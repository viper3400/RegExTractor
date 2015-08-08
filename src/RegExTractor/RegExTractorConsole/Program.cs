using System;
using RegExTractorModules;

namespace RegExTractorConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            var test = new RegExTractorTestWorkflow();
            test.Test();
            
            Console.WriteLine("Finished ... Press any key ...");
            Console.ReadKey();
        }
    }
}
