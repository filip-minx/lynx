namespace Lynx.Operations.Arithmetic
{
    public class Division : Operation
    {
        public override string Identifier => "/";

        public override int Arity => 2;

        public override string VerboseIdentifier => "Divide";

        public override object[] Execute(Arguments arguments, LynxRuntime runtime)
        {
            var a = arguments.Get<double>(0);
            var b = arguments.Get<double>(1);

            return new object[] { a / b };
        }
    }
}
