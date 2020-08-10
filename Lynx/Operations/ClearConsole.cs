using System;

namespace Lynx.Operations
{
    public class ClearConsole : Operation
    {
        public override string Identifier => "x";

        public override string VerboseIdentifier => "Clear";

        public override int Arity => 0;

        public override object[] Execute(Arguments arguments, LynxRuntime runtime)
        {
            Console.Clear();

            return null;
        }
    }
}
