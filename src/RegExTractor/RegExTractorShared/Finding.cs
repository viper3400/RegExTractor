using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RegExTractorShared
{
    public class Finding
    {
        public string Expression { get; set; }
        public string ExpressionFriendlyName { get; set; }
        public string FileName { get; set; }
        public string FileFolder { get; set; }
        public List<RegExTractorMatchCollection> Match { get; set; }
    }
}
