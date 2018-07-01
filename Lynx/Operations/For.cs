namespace Lynx.Operations
{
    public class For : Operation
    {
        public override string Indentifier => "f";

        public override int Arity => 1;

        public override string VerboseIdentifier => "For";

        public override object[] Execute(Arguments arguments, Interpreter interpreter)
        {
            var iterations = arguments.Get<int>(0);

            var pos = interpreter.Tokens.Position;

            for (int i = 0; i < iterations; i++)
            {
                interpreter.Tokens.Position = pos;

                interpreter.Memory.Push(i);

                interpreter.ExecuteSubroutine(interpreter.Tokens, ";");
            }

            return null;
        }
    }
}
