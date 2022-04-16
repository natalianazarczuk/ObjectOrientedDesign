using System;
using System.Collections.Generic;

namespace Task2
{
    public interface IFileSystemNode
    {
        public string GetPrintableName();
        public string GetPrintableContent();
        public IFileSystemNode GetParent();
        public bool IsDir();
    }
}
