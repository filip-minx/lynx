namespace Lynx.Operations.Logic
{
    public class Equals : Operation
    {
        public override string Identifier => "=";

        public override string VerboseIdentifier => "Equals";

        public override int Arity => 2;

        public override object[] Execute(Arguments arguments, LynxRuntime runtime)
        {
            var a = arguments.Get<object>(0);
            var b = arguments.Get<object>(1);

            return new object[] { a.Equals(b) ? 1 : 0 };
        }
    }
}
