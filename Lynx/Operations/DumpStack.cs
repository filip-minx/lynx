using System;

namespace Lynx.Operations
{
    public class DumpStack : Operation
    {
        public override string Identifier => "_";

        public override string VerboseIdentifier => "DumpStack";

        public override int Arity => 0;

        public override object[] Execute(Arguments arguments, LynxRuntime runtime)
        {
            foreach (var value in runtime.Memory.PopAll())
            {
                Console.WriteLine(value.ToString());
            }

            return null;
        }
    }
}
