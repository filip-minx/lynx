namespace Lynx.Operations.Memory
{
    public class ReadStackSize : Operation
    {
        public override string Identifier => "v";

        public override string VerboseIdentifier => "ReadStackSize";

        public override int Arity => 0;

        public override object[] Execute(Arguments arguments, LynxRuntime runtime)
        {
            return new object[] { runtime.Stack.Count };
        }
    }
}
