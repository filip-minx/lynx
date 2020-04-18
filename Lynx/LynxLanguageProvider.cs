using System.Text;

namespace Lynx
{
    public class LynxLanguageProvider : ILanguageProvider
    {
        ICodeParser parser = new CodeParser();

        public TokenChain Compile(string code)
        {
            var tokens = parser.Parse(code);

            var assembly = new TokenChain(tokens);

            return assembly;
        }

        public string GenerateCode(TokenChain tokens)
        {
            var code = new StringBuilder();

            Token lastToken = null;

            foreach (var token in tokens)
            {
                if (token.TokenType == TokenType.Operation)
                {
                    code.Append(token);
                }
                else
                {
                    if (lastToken?.TokenType == TokenType.Value)
                    {
                        code.Append(" ");
                    }

                    if ((token as ValueToken).ValueType == ValueType.String)
                    {
                        code.Append($"\"{token.Pattern}\"");
                    }
                    else
                    {
                        code.Append(token.Pattern);
                    }
                }

                lastToken = token;
            }

            return code.ToString();
        }
    }
}
