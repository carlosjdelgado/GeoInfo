using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeoInfo.DataBuilder.Services
{
    public class FileSystemService
    {
        public FileSystemService()
        {

        }

        public void CreateFolderIfNotExist(string path)
        {
            if (!System.IO.Directory.Exists(path))
            {
                System.IO.Directory.CreateDirectory(path);
            }
        }

        public void RemoveFiles(string path, string searchPattern)
        {
            foreach(string fileName in System.IO.Directory.EnumerateFiles(path, searchPattern))
            {
                System.IO.File.Delete(fileName);
            }            
        }
    }
}
