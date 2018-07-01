namespace Lynx.Operations.Arithmetic
{
    public class Multiply : Operation
    {
        public override int Arity => 2;

        public override string Indentifier => "*";

        public override object[] Execute(Arguments arguments, Interpreter interpreter)
        {
            return new object[] { arguments.Get<double>(0) * arguments.Get<double>(1) };
        }
    }
}
