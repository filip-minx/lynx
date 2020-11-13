using System;

namespace Lynx.Operations.Memory
{
    public class RegisterWrite : Operation
    {
        public override string Identifier => "}";

        public override string VerboseIdentifier => "RegWrite";

        public override int Arity => 2;

        public override object[] Execute(Arguments arguments, LynxRuntime runtime)
        {
            var key = arguments.Get<object>(0);
            var value = arguments.Get<object>(1);

            runtime.Register[key] = value;

            return null;
        }
    }
}
