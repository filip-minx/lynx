using System.Threading;

namespace Lynx.Operations.Control
{
    public class Sleep : Operation
    {
        public override string Identifier => "s";

        public override string VerboseIdentifier => "Sleep";

        public override int Arity => 1;

        public override object[] Execute(Arguments arguments, LynxRuntime runtime)
        {
            var sleepTime = arguments.Get<double>(0);

            Thread.Sleep((int)(sleepTime * 1000));

            return null;
        }
    }
}
