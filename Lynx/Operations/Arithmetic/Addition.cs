﻿namespace Lynx.Operations.Arithmetic
{
    public class Addition : Operation
    {
        public override int Arity => 2;

        public override string Identifier => "+";

        public override string VerboseIdentifier => "Add";

        public override object[] Execute(Arguments arguments, LynxRuntime runtime)
        {
            var a = arguments.Get<double>(0);
            var b = arguments.Get<double>(1);

            return new object[] { a + b };
        }
    }
}
