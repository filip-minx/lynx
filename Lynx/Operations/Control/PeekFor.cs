using System;

namespace Lynx.Operations.Control
{
    public class PeekFor : Operation
    {
        public override string Identifier => "F";

        public override int Arity => 0;

        public override string VerboseIdentifier => "PeekFor";

        public override object[] Execute(Arguments arguments, LynxRuntime runtime)
        {
            var iterations = (int)Convert.ChangeType(runtime.Stack.Peek(), typeof(int));

            var pos = runtime.Tokens.Position;

            for (int i = 0; i < iterations; i++)
            {
                runtime.Tokens.Position = pos;

                runtime.Stack.Push(i);

                runtime.ExecuteSubroutine(";");
            }

            return null;
        }
    }
}
