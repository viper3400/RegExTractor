using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace RegExTractorShared
{
    public interface IFileListProvider
    {
        List<FileInfo> GetFileList { get; }
    }
}
