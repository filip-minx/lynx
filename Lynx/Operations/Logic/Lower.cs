﻿namespace Lynx.Operations.Logic
{
    public class Lower : Operation
    {
        public override string Identifier => "<";

        public override string VerboseIdentifier => "Lower";

        public override int Arity => 2;

        public override object[] Execute(Arguments arguments, LynxRuntime runtime)
        {
            var a = arguments.Get<double>(0);
            var b = arguments.Get<double>(1);

            return new object[] { a < b ? 1 : 0 };
        }
    }
}
