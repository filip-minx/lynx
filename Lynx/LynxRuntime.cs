using System.Collections.Generic;
using System.Diagnostics;

namespace Lynx
{
    public class LynxRuntime
    {
        public StackMemory Stack { get; private set; } = new StackMemory();
        public RegisterMemory Register { get; private set; } = new RegisterMemory();

        internal TokenChain Tokens { get; set; }

        public void Execute(TokenChain tokens)
        {
            Tokens = tokens;

            while (tokens.TryGetNext(out var token))
            {
                ProcessToken(token);
            }
        }

        internal void ExecuteSubroutine(string terminator = ";")
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

        internal void SkipSubroutine(string terminator = ";")
        {
            while (Tokens.TryGetNext(out var token))
            {
                if (token.Pattern == terminator)
                {
                    return;
                }
            }
        }

        private void ProcessToken(Token token)
        {
            if (token.TokenType == TokenType.Value)
            {
                Stack.Push(token.Pattern);
            }
            else if (token.TokenType == TokenType.Operation)
            {
                Debug.WriteLine($"Execute: {token.Pattern}");

                var operation = OperationsRegister.GetOperation(token.Pattern);

                var arguments = PopArguments(operation.Arity);

                var results = operation.Execute(arguments, this);

                if (results != null)
                {
                    foreach (var result in results)
                    {
                        Stack.Push(result);
                    }
                }
            }
        }

        private Arguments PopArguments(int count)
        {
            object[] data = new object[count];

            for (int i = 0; i < count; i++)
            {
                data[i] = Stack.Pop();
            }

            return new Arguments(data);
        }
    }
}
