using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace Lynx
{
    public class Interpreter
    {
        internal Memory Memory = new Memory();
        internal TokenChain Tokens { get; private set; }

        private OperationsRegister operations = new OperationsRegister();

        private CodeParser parser = new CodeParser();

        public object DefaultResult { get; set; } = null;

        public string Execute(string code)
        {
            Memory.Clear();

            Tokens = new TokenChain(parser.Parse(code));

            while (Tokens.TryGetNext(out var token))
            {
                ProcessToken(token);
            }

            if (Memory.Count == 0)
            {
                return DefaultResult != null ? DefaultResult.ToString() : String.Empty;
            }

            return Memory.Pop().ToString();
        }

        internal void ExecuteSubroutine(TokenChain tokens, string terminator = ";")
        {
            while (Tokens.TryGetNext(out var token))
            {
                if (token.Pattern == terminator)
                {
                    return;
                }

                ProcessToken(token);
            }
        }

        private void ProcessToken(Token token)
        {
            if (token.TokenType == TokenType.Value)
            {
                Memory.Push(token.Pattern);
            }
            else if (token.TokenType == TokenType.Operation)
            {
                Debug.WriteLine($"Execute: {token.Pattern}");

                var operation = operations.GetOperation(token.Pattern);

                var arguments = PopArguments(operation.Arity);

                var results = operation.Execute(arguments, this);

                if (results != null)
                {
                    foreach (var result in results)
                    {
                        Memory.Push(result);
                    }
                }
            }
        }

        private Arguments PopArguments(int count)
        {
            object[] data = new object[count];

            for (int i = 0; i < count; i++)
            {
                data[i] = Memory.Pop();
            }

            return new Arguments(data);
        }
    }
}
