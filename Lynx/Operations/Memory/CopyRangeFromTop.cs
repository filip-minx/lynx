namespace Lynx.Operations.Memory
{
    public class CopyRangeFromTop : Operation
    {
        public override string Identifier => "d";

        public override string VerboseIdentifier => "CopyRangeFromTop";

        public override int Arity => 1;

        public override object[] Execute(Arguments arguments, LynxRuntime runtime)
        {
            int count = arguments.Get<int>(0);

            var copy = new object[count];

            for (int i = 0; i < count; i++)
            {
                copy[count - 1 - i] = runtime.Stack[i];
            }

            return copy;
        }
    }
}
