using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RegExTractorShared
{
    public class Finding
    {
        string Expression { get; set; }
        string ExpressionFriendlyName { get; set; }
        string FileName { get; set; }
        string FileFolder { get; set; }
        Dictionary<int, Dictionary<int, string>> Match;
    }
}
