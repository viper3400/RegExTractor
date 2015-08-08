using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RegExTractorShared;
using System.IO;

namespace RegExTractor
{
    public class SimpleFileListProvider : IFileListProvider
    {
        public SimpleFileListProvider(string Directory, bool Recursive, string Filter)
        {
            directory = Directory;
            recursive = Recursive;
            filter = Filter;
        }

        private string directory;
        private bool recursive;
        private string filter;

        public List<FileInfo> GetFileList
        {
            get { return ScanFiles() }
        }

        private List<FileInfo> ScanFiles()
        {
            var searchOption = recursive ? SearchOption.AllDirectories : SearchOption.TopDirectoryOnly;
            var dirInfo = new DirectoryInfo(directory);
            var fileInfo = dirInfo.GetFiles(filter, searchOption);
            return fileInfo.ToList();

        }
    }
}
