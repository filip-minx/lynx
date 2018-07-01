using System;

namespace Lynx.Operations
{
    public class PopAll : Operation
    {
        public override string Indentifier => "ˇ";

        public override int Arity => 0;

        public override object[] Execute(Arguments arguments, Interpreter interpreter)
        {
            interpreter.Memory.Clear();

            return null;
        }
    }
}
