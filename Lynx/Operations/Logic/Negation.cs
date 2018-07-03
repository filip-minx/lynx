namespace Lynx.Operations.Logic
{
    public class Negation : Operation
    {
        public override string Identifier => "!";

        public override int Arity => 1;

        public override string VerboseIdentifier => "Negate";

        public override object[] Execute(Arguments arguments, LynxRuntime runtime)
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
