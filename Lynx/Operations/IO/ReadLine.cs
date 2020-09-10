using System;

namespace Lynx.Operations.IO
{
    public class ReadLine : Operation
    {
        public override string Identifier => "i";

        public override string VerboseIdentifier => "ReadLine";

        public override int Arity => 0;

        public override object[] Execute(Arguments arguments, LynxRuntime runtime) => new[] { Console.ReadLine() };
    }
}
