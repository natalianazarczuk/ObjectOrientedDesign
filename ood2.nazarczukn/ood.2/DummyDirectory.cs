using System;
using System.Collections.Generic;

namespace Task2
{
    public class DummyDirectory : DummyNode
    {
        public DummyDirectory(string name) : base(name, true) { }
        public DummyDirectory(string name, DummyDirectory parent) : base(name, parent, true) { }

        public override string GetPrintableName()
        {
            return Name + "/";
        }


        public override string GetPrintableContent()
        {
            return null;
        }
    }
}