using System;

namespace Lynx.Operations.IO
{
    public class PeekWrite : Operation
    {
        public override string Identifier => "W";

        public override string VerboseIdentifier => "PeekWrite";

        public override int Arity => 0;

        public override object[] Execute(Arguments arguments, LynxRuntime runtime)
        {
            Console.Write(runtime.Stack.Peek());

            return null;
        }
    }
}
