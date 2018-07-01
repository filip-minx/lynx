namespace Lynx
{
    public abstract class Operation
    {
        public abstract string Indentifier { get; }
        public abstract int Arity { get; }

        public abstract object[] Execute(Arguments arguments, Interpreter interpreter);
    }
}
