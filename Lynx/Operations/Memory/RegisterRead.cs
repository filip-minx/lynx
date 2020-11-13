namespace Lynx.Operations.Memory
{
    public class RegisterRead : Operation
    {
        public override string Identifier => "{";

        public override string VerboseIdentifier => "RegRead";

        public override int Arity => 1;

        public override object[] Execute(Arguments arguments, LynxRuntime runtime)
        {
            var key = arguments.Get<object>(0);

            return new[] { runtime.Register[key] };
        }
    }
}
