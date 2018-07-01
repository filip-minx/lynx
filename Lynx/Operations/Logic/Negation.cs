namespace Lynx.Operations.Logic
{
    public class Negation : Operation
    {
        public override string Indentifier => "!";

        public override int Arity => 1;

        public override object[] Execute(Arguments arguments, Interpreter interpreter)
        {
            var arg = arguments.Get<int>(0);

            if (arg == 0)
            {
                return new object[] { 1 };
            }
            else
            {
                return new object[] { 0 };
            }
        }
    }
}
