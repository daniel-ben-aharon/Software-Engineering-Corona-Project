using System;
using System.Collections.Generic;
using System.Text;

namespace CoronaProjectDaniel
{
    public interface IArgumentIterator
    {
        public string NextString();
        public int NextInt();
        public DateTime NextDate();
        public bool NextBool();
        public bool HasNext();
    }
}
