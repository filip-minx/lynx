using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lynx.Operations
{
    public class BlockTerminator : Operation
    {
        public override string Identifier => ";";

        public override string VerboseIdentifier => ";";

        public override int Arity => 0;

        public override object[] Execute(Arguments arguments, LynxRuntime runtime)
        {
            return null;
        }
    }
}
