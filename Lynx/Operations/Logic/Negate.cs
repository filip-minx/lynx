namespace Lynx.Operations.Logic
{
    public class Negate : Operation
    {
        public override string Identifier => "!";

        public override int Arity => 1;

        public override string VerboseIdentifier => "Negate";

        public override object[] Execute(Arguments arguments, LynxRuntime runtime)
        {
            var arg = arguments.Get<int>(0);

            return new object[] { -arg };
        }
    }
}
