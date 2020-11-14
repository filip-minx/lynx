using System;

namespace Lynx.Operations.IO
{
    public class PeekWriteLine : Operation
    {
        public override string Identifier => "L";

        public override string VerboseIdentifier => "PeekWriteLine";

        public override int Arity => 0;

        public override object[] Execute(Arguments arguments, LynxRuntime runtime)
        {
            Console.WriteLine(runtime.Stack.Peek());

            return null;
        }
    }
}
