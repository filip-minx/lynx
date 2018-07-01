namespace Lynx.Operations.Arithmetic
{
    public class Add : Operation
    {
        public override int Arity => 2;

        public override string Indentifier => "+";

        public override object[] Execute(Arguments arguments, Interpreter interpreter)
        {
            var a = arguments.Get<double>(0);
            var b = arguments.Get<double>(1);

            return new object[] { a + b };
        }
    }
}
