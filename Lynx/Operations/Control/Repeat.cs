namespace Lynx.Operations.Control
{
    public class Repeat : Operation
    {
        public override string Identifier => "@";

        public override int Arity => 1;

        public override string VerboseIdentifier => "Repeat";

        public override object[] Execute(Arguments arguments, LynxRuntime runtime)
        {
            var iterations = arguments.Get<int>(0);

            var pos = runtime.Tokens.Position;

            for (int i = 0; i < iterations; i++)
            {
                runtime.Tokens.Position = pos;

                runtime.ExecuteSubroutine(";");
            }

            return null;
        }
    }
}
