using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2
{
    public class Transformation1 : IFileSystemNode
    {
        protected IFileSystemNode node;

        public Transformation1(IFileSystemNode node)
        {
            this.node = node;
        }
        public IFileSystemNode GetParent()
        {
            return node.GetParent();
        }

        public string GetPrintableContent()
        {
            return node.GetPrintableContent();
        }

        public string GetPrintableName()
        {
            string name = node.GetPrintableName();
            int depth = 0;

            var temp = node;
            if(temp != null)
            {
                while(temp.GetParent() != null)
                {
                    depth++;
                    temp = temp.GetParent();
                }
            }

            return $"|{new string('-', depth)}{name}";
        }

        public bool IsDir()
        {
            return node.IsDir();
        }
    }
    public class Transformation2 : IFileSystemNode
    {
        protected IFileSystemNode node;

        public Transformation2(IFileSystemNode node)
        {
            this.node = node;
        }
        public IFileSystemNode GetParent()
        {
            return node.GetParent();
        }

        public string GetPrintableContent()
        {
            if (!node.IsDir())
            {
                string x = node.GetPrintableContent();
                string content = x.Replace(@"-", "");
                return content;
            }
            else
                return node.GetPrintableContent();
        }

        public string GetPrintableName()
        {
            return node.GetPrintableName();
        }

        public bool IsDir()
        {
            return node.IsDir();
        }
    }

    public class Transformation3 : IFileSystemNode
    {
        protected IFileSystemNode node;

        public Transformation3(IFileSystemNode node)
        {
            this.node = node;
        }
        public IFileSystemNode GetParent()
        {
            return node.GetParent();
        }

        public string GetPrintableContent()
        {
            if (!node.IsDir() && !node.GetPrintableName().Contains(".cipher"))
            {
                return node.GetPrintableContent() + "\n";
            }
            else if(!node.IsDir() && node.GetPrintableName().Contains(".cipher"))
            {
                var content = node.GetPrintableContent();
                char[] arr = content.ToCharArray();
                Array.Reverse(arr);

                for(int i = 0; i < arr.Length; i++)
                {
                    arr[i] = Convert.ToChar(arr[i] - 25);
                }
                return new string(arr);
            }
            else
                return node.GetPrintableContent();
        }

        public string GetPrintableName()
        {
            return node.GetPrintableName();
        }

        public bool IsDir()
        {
            return node.IsDir();
        }
    }
}


