namespace Lynx.Operations.Memory
{
    public class CopyToTop : Operation
    {
        public override string Identifier => "c";

        public override string VerboseIdentifier => "CopyToTop";

        public override int Arity => 1;

        public override object[] Execute(Arguments arguments, LynxRuntime runtime)
        {
            int valueIndex = arguments.Get<int>(0);

            var value = runtime.Stack.PeekAt(valueIndex);

            runtime.Stack.Push(value);

            return null;
        }
    }
}
