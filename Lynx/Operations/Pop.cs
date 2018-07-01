using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lynx.Operations
{
    public class Pop : Operation
    {
        public override string Indentifier => "~";

        public override int Arity => 0;

        public override string VerboseIdentifier => "Pop";

        public override object[] Execute(Arguments arguments, Interpreter interpreter)
        {
            interpreter.Memory.Pop();

            return null;
        }
    }
}
