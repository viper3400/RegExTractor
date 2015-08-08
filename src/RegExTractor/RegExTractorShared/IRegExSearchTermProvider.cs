using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RegExTractorShared
{
    public interface IRegExSearchTermProvider
    {
        List<RegExSearchTerm> GetSearchTermList { get; }
    }
}
