namespace Lynx
{
    class OperationToken : Token
    {
        public override TokenType TokenType => TokenType.Operation;

        public override string Pattern { get; protected set; }

        public OperationToken(string pattern)
        {
            Pattern = pattern;
        }
    }
}
