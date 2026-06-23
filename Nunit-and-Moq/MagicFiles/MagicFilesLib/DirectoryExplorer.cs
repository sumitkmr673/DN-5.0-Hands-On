using System.Collections.Generic;
using System.IO;

namespace MagicFilesLib
{
    // The Interface
    public interface IDirectoryExplorer
    {
        ICollection<string> GetFiles(string path);
    }

    // The Implementation
    public class DirectoryExplorer : IDirectoryExplorer
    {
        public ICollection<string> GetFiles(string path)
        {
            string[] files = Directory.GetFiles(path);
            return files;
        }
    }
}