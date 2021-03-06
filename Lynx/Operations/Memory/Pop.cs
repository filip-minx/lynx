﻿namespace Lynx.Operations.Memory
{
    public class Pop : Operation
    {
        public override string Identifier => "~";

        public override int Arity => 0;

        public override string VerboseIdentifier => "Pop";

        public override object[] Execute(Arguments arguments, LynxRuntime runtime)
        {
            runtime.Stack.Pop();

            return null;
        }
    }
}
