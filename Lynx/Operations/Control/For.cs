namespace Lynx.Operations.Control
{
    public class For : Operation
    {
        public override string Identifier => "f";

        public override int Arity => 1;

        public override string VerboseIdentifier => "For";

        public override object[] Execute(Arguments arguments, LynxRuntime runtime)
        {
            var iterations = arguments.Get<int>(0);

            var pos = runtime.Tokens.Position;

            for (int i = 0; i < iterations; i++)
            {
                runtime.Tokens.Position = pos;

                runtime.Memory.Push(i);

                runtime.ExecuteSubroutine(";");
            }

            return null;
        }
    }
}
