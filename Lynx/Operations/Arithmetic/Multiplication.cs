namespace Lynx.Operations.Arithmetic
{
    public class Multiplication : Operation
    {
        public override int Arity => 2;

        public override string Identifier => "*";

        public override string VerboseIdentifier => "Multiply";

        public override object[] Execute(Arguments arguments, LynxRuntime runtime)
        {
            return new object[] { arguments.Get<double>(0) * arguments.Get<double>(1) };
        }
    }
}
