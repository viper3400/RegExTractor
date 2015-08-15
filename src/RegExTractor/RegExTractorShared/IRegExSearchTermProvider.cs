using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RegExTractorShared
{
    public interface IRegExSearchTermProvider
    {
        List<RegExSearchTerm> GetSearchTermList { get; }
    }
}
