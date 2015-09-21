using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RegExTractor
{
    public static class GlobalSettings
    {
        private static RegExTractorSettings settings = new RegExTractorSettings("debugsettings.config");

        public static int MaxAsyncFileIteratorThreads
        {
            get { return settings.MaxAsyncFileIteratorThreads; }
        } 
    }
}
