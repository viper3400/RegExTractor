using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;
using System.ComponentModel;

namespace RegExTractor
{
    [SettingsProvider(typeof(PortableSettingsProvider))]
    public class RegExTractorSettings : ApplicationSettingsBase
    {
            public RegExTractorSettings(string connectionString)
                :base (connectionString)
            {
                // The string passed to base(string) will be added
                // to SettingsContext as "SettingsKey".
                // Here we can further modify SettingsContext if needed:
                // this.Context["MyProperty"] = new object();
            }

          [ApplicationScopedSetting]
          [DefaultSettingValue("4")]
          [CategoryAttribute("AsyncFileIteratorSettings")]
          [Description("Define how many threads are use by AsyncFileIterator.")]
          public int MaxAsyncFileIteratorThreads
          {
              get { return (int)this["MaxAsyncFileIteratorThreads"]; }
              set { this["MaxAsyncFileIteratorThreads"] = value; }
          }
    }
}
