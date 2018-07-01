using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lynx.Operations
{
    public class Write : Operation
    {
        public override int Arity => 1;

        public override string Indentifier => "w";

        public override object[] Execute(Arguments arguments, Interpreter interpreter)
        {
            Console.Write(arguments.Get<string>(0));

            return null;
        }
    }
}
