using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace ImageEditor
{
    public class FilePathSplitter
    {
        public string FileNameWithoutExtension { get; private set; }
        public string FileExtension { get; private set; }  
        public string FileDirectoryName { get; private set; } 
        public string FileNameWithSufix { get; private set; }
        public string FullFilePathWithSufix { get; private set; }

        public FilePathSplitter(string fileName)
        {
            FileNameWithoutExtension = Path.GetFileNameWithoutExtension(fileName);
            FileExtension = Path.GetExtension(fileName);
            FileDirectoryName = Path.GetDirectoryName(fileName);

            FullFilePathWithSufix = $"{FileDirectoryName}\\{FileNameWithoutExtension}{FileNameWithSufix}{FileExtension}";
            
        }

        public void AddSufixToFileName(string sufix)
        {
            FileNameWithSufix = $"{FileNameWithoutExtension}_{sufix}{FileExtension}"; 
        }


    }
}
