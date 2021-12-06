using System;

namespace Lynx.Operations.Memory
{
    public class CopyTop : Operation
    {
        public override string Identifier => "C";

        public override string VerboseIdentifier => "CopyTop";

        public override int Arity => 0;

        public override object[] Execute(Arguments arguments, LynxRuntime runtime)
        {
            return new object[] { (int)Convert.ChangeType(runtime.Stack.Peek(), typeof(int)) };
        }
    }
}
