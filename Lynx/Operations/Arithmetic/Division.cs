using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lynx.Operations.Arithmetic
{
    public class Division : Operation
    {
        public override string Identifier => "/";

        public override int Arity => 2;

        public override string VerboseIdentifier => "Divide";

        public override object[] Execute(Arguments arguments, LynxRuntime runtime)
        {
            var a = arguments.Get<double>(1);
            var b = arguments.Get<double>(0);

            return new object[] { a / b };
        }
    }
}
