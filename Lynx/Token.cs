namespace Lynx
{
    public abstract class Token
    {
        public abstract TokenType TokenType { get; }

        public abstract string Pattern { get; protected set; }

        public override string ToString()
        {
            return Pattern;
        }
    }
}
