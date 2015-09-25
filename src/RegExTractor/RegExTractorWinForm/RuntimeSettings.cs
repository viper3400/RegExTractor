using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RegExTractorWinForm
{
    internal static class RuntimeSettings
    {

        private static int maxThreads = 4;

        internal static int MaxThreads
        {
            get { return maxThreads; }
            set { maxThreads = value; }
        }

    
    }
}
