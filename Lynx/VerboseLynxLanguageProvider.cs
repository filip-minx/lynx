using Lynx.Operations;
using Lynx.Operations.Control;
using System.Collections.Generic;
using System.Text;

namespace Lynx
{
    public class VerboseLynxLanguageProvider : ILanguageProvider
    {
        private ICodeParser parser = new VerboseCodeParser();
        private int indent = 0;

        private HashSet<Operation> indentIncreasingOperations = new HashSet<Operation>()
        {
            OperationsRegister.GetOperation<For>(),
            OperationsRegister.GetOperation<TwoWayCondition>()
        };

        private HashSet<Operation> indentDecreasingOperations = new HashSet<Operation>()
        {
            OperationsRegister.GetOperation<BlockTerminator>()
        };

        public LynxAssembly Compile(string code)
        {
            var tokens = parser.Parse(code);

            var assembly = new LynxAssembly(tokens);

            return assembly;
        }

        public string GenerateCode(LynxAssembly assembly)
        {
            var sb = new StringBuilder();

            indent = 0;

            Token lastToken = null;

            foreach (var token in assembly.Tokens)
            {
                FormatWhitespace(token, lastToken, sb);

                if (token.TokenType == TokenType.Operation)
                {
                    sb.Append(OperationsRegister.GetOperation(token.Pattern).VerboseIdentifier);
                }
                else
                {
                    sb.Append(token.Pattern);
                }

                lastToken = token;
            }

            return sb.ToString();
        }

        private void FormatWhitespace(Token currentToken, Token lastToken, StringBuilder sb)
        {
            if (lastToken == null) return;
            
            if (lastToken.TokenType == TokenType.Operation)
            {
                sb.AppendLine();

                if (IsIndentIncreasing(lastToken))
                {
                    indent++;
                }

                if (IsIndentDecreasing(currentToken))
                {
                    indent = indent > 0 ? indent - 1 : 0;
                }

                sb.Append(new string(' ', indent * 4));
            }
            else
            {
                sb.Append(' ');
            }
        }

        private bool IsIndentDecreasing(Token token)
        {
            if (token.TokenType != TokenType.Operation) return false;

            return indentDecreasingOperations.Contains(OperationsRegister.GetOperation(token.Pattern));
        }

        private bool IsIndentIncreasing(Token token)
        {
            if (token.TokenType != TokenType.Operation) return false;

            return indentIncreasingOperations.Contains(OperationsRegister.GetOperation(token.Pattern));
        }
    }
}
