namespace Lynx
{
    class ValueToken : Token
    {
        public override TokenType TokenType => TokenType.Value;
        public ValueType ValueType { get; private set; }

        public override string Pattern { get; protected set; }

        public ValueToken(string pattern, ValueType type)
        {
            Pattern = pattern;
            ValueType = type;
        }
    }
}
