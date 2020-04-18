namespace Lynx.Operations
{
    public class CopyToTop : Operation
    {
        public override string Identifier => "c";

        public override string VerboseIdentifier => "CopyToTop";

        public override int Arity => 1;

        public override object[] Execute(Arguments arguments, LynxRuntime runtime)
        {
            int valueIndex = arguments.Get<int>(0);

            var value = runtime.Memory.PeekAt(valueIndex);

            runtime.Memory.Push(value);

            return null;
        }
    }
}
