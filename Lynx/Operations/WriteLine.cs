using System;

namespace Lynx.Operations
{
    public class WriteLine : Operation
    {
        public override int Arity => 1;

        public override string Identifier => "l";

        public override string VerboseIdentifier => "WriteLine";

        public override object[] Execute(Arguments arguments, LynxRuntime runtime)
        {
            Console.WriteLine(arguments.Get<string>(0));

            return null;
        }
    }
}
