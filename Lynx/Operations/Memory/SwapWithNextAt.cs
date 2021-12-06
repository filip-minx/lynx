using System;

namespace Lynx.Operations.Memory
{
    public class SwapWithNextAt : Operation
    {
        public override string Identifier => "S";

        public override string VerboseIdentifier => "SwapWithNextAt";

        public override int Arity => 1;

        public override object[] Execute(Arguments arguments, LynxRuntime runtime)
        {
            var index = arguments.Get<int>(0);

            var temp = runtime.Stack[index];

            runtime.Stack[index] = runtime.Stack[index + 1];
            runtime.Stack[index + 1] = temp;

            return null;
        }
    }
}
