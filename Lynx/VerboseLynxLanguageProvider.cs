using Lynx.Operations;
using Lynx.Operations.Control;
using System;
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

        public TokenChain Compile(string code)
        {
            var tokens = parser.Parse(code);

            var assembly = new TokenChain(tokens);

            return assembly;
        }

        public string GenerateCode(TokenChain tokens)
        {
            var sb = new StringBuilder();

            indent = 0;

            Token lastToken = null;

            foreach (var token in tokens)
            {
                FormatWhitespace(token, lastToken, sb);

                switch (token)
                {
                    case OperationToken operation:
                        sb.Append(OperationsRegister.GetOperation(operation.Pattern).VerboseIdentifier);
                        break;

                    case ValueToken value:
                        sb.Append(value.ValueType == ValueType.String
                            ? $"\"{value.Pattern}\""
                            : value.Pattern);
                        break;

                    default:
                        throw new InvalidOperationException("Invalid token type.");
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
