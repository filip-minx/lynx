using System;
using System.Text;

namespace Lynx
{
    public class LynxLanguageProvider : ILanguageProvider
    {
        ICodeParser parser = new CodeParser();

        public LynxAssembly Compile(string code)
        {
            var tokens = parser.Parse(code);

            var assembly = new LynxAssembly(tokens);

            return assembly;
        }

        public string GenerateCode(LynxAssembly assembly)
        {
            var code = new StringBuilder();

            Token lastToken = null;

            foreach (var token in assembly.Tokens)
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
