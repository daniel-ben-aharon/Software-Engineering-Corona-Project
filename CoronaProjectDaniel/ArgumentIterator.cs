using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CoronaProjectDaniel
{
    public class ArgumentIterator : IArgumentIterator
    {
        private int argIndex;
        private IEnumerable<string> args;
        private IEnumerator<string> e;
        public ArgumentIterator(IEnumerable<string> args)
        {
            this.args = args;
            this.argIndex = 0;
            this.e = this.args.GetEnumerator();
            this.e.MoveNext();
        }
        public bool HasNext()
        {
            return (argIndex < args.Count());
        }

        public bool NextBool()
        {
            bool result = bool.Parse(e.Current);
            e.MoveNext();
            argIndex++;
            return result;
            
        }

        public DateTime NextDate()
        {
            DateTime result = DateTime.Parse(e.Current);
            e.MoveNext();
            argIndex++;
            return result;
        }

        public int NextInt()
        {
            int result = int.Parse(e.Current);
            e.MoveNext();
            argIndex++;
            return result;
        }

        public string NextString()
        {
            string result = e.Current;
            e.MoveNext();
            argIndex++;
            return result;
        }
    }
}
