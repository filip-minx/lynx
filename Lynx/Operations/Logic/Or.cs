using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lynx.Operations.Logic
{
    public class Or : Operation
    {
        public override string Identifier => "|";

        public override int Arity => 2;

        public override string VerboseIdentifier => "Or";

        public override object[] Execute(Arguments arguments, LynxRuntime runtime)
        {
            var a = arguments.Get<int>(0);
            var b = arguments.Get<int>(1);

            return new object[] { a | b };
        }
    }
}
