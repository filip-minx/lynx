using System;

namespace Lynx.Operations.Memory
{
    public class DumpStack : Operation
    {
        public override string Identifier => "_";

        public override string VerboseIdentifier => "DumpStack";

        public override int Arity => 0;

        public override object[] Execute(Arguments arguments, LynxRuntime runtime)
        {
            foreach (var value in runtime.Stack.PopAll())
            {
                Console.WriteLine(value.ToString());
            }

            return null;
        }
    }
}
