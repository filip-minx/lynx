namespace Lynx.Operations.Control
{
    public class TwoWayCondition : Operation
    {
        public override string Identifier => "?";

        public override string VerboseIdentifier => "IfThenElse";

        public override int Arity => 1;

        public override object[] Execute(Arguments arguments, LynxRuntime runtime)
        {
            var condition = arguments.Get<int>(0) == 1;

            if (condition)
            {
                runtime.ExecuteSubroutine(";");
                runtime.SkipSubroutine(";");
            }
            else
            {
                runtime.SkipSubroutine(";");
                runtime.ExecuteSubroutine(";");
            }


            return null;
        }
    }
}
