using System;

namespace Lynx.Operations
{
    public class PopAll : Operation
    {
        public override string Identifier => "ˇ";

        public override int Arity => 0;

        public override string VerboseIdentifier => "PopAll";

        public override object[] Execute(Arguments arguments, LynxRuntime runtime)
        {
            runtime.Memory.Clear();

            return null;
        }
    }
}
