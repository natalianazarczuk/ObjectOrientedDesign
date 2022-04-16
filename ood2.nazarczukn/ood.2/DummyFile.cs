using System;

namespace Task2
{
    public class DummyFile : DummyNode
    {
        public string Content { get; }

        public DummyFile(string name, string content, DummyDirectory parent) : base(name, parent, false)
        {
            this.Content = content;
        }

        public override string GetPrintableContent()
        {
            return Content;
        }
    }
}