using System;

namespace Lynx.Operations
{
    public class Write : Operation
    {
        public override int Arity => 1;

        public override string Identifier => "w";

        public override string VerboseIdentifier => "Write";

        public override object[] Execute(Arguments arguments, LynxRuntime runtime)
        {
            Console.Write(arguments.Get<string>(0));

            return null;
        }
    }
}
