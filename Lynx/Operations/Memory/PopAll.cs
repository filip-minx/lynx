namespace Lynx.Operations.Memory
{
    public class PopAll : Operation
    {
        public override string Identifier => "ˇ";

        public override int Arity => 0;

        public override string VerboseIdentifier => "PopAll";

        public override object[] Execute(Arguments arguments, LynxRuntime runtime)
        {
            runtime.Stack.Clear();

            return null;
        }
    }
}
