using System;

namespace Lynx.Operations.Control
{
    public class While : Operation
    {
        public override string Identifier => "r";

        public override string VerboseIdentifier => "While";

        public override int Arity => 1;

        public override object[] Execute(Arguments arguments, LynxRuntime runtime)
        {
            var condition = arguments.Get<int>(0);

            var pos = runtime.Tokens.Position;

            while (condition != 0)
            {
                runtime.Tokens.Position = pos;

                runtime.ExecuteSubroutine(";");

                condition = (int)Convert.ChangeType(runtime.Stack.Pop(), typeof(int));
            }

            return null;
        }
    }
}
