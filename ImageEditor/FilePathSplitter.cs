﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace ImageEditor
{
    public class FilePathSplitter
    {
        string fileName;

        public char DirectorySeparatorChar { get; } = Path.DirectorySeparatorChar;

        public FilePathSplitter(string fileName)
        {
            this.fileName = fileName;
        }

        public string GetFileDirectory()
        {
            return Path.GetDirectoryName(fileName);
        }

        public string GetFileNameWithoutExtension()
        {
            return Path.GetFileNameWithoutExtension(fileName);
        }

        public string GetFileExtension()
        {
            return Path.GetExtension(fileName);
        }

        public string GetFileNameWithSuffix(string suffix)
        {
            return GetFileNameWithoutExtension() + $"_{suffix}" + GetFileExtension();
        }

        public string GetFullFilePathWithSuffix(string suffix)
        {
            return GetFileDirectory() + DirectorySeparatorChar + GetFileNameWithSuffix(suffix);
        }

    }
}
