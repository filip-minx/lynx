using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace Lynx
{
    public class LynxRuntime
    {
        internal Memory Memory = new Memory();
        internal LynxAssembly Assembly { get; private set; }
        internal TokenChain Tokens => Assembly.Tokens;

        private CodeParser parser = new CodeParser();

        public object DefaultResult { get; set; } = null;

        public string Execute(LynxAssembly assembly)
        {
            assembly.Tokens.Position = 0;
            Memory.Clear();

            Assembly = assembly;

            while (assembly.Tokens.TryGetNext(out var token))
            {
                ProcessToken(token);
            }

            if (Memory.Count == 0)
            {
                return DefaultResult != null ? DefaultResult.ToString() : String.Empty;
            }

            return Memory.Pop().ToString();
        }

        internal void ExecuteSubroutine(string terminator = ";")
        {
            while (Assembly.Tokens.TryGetNext(out var token))
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

                var operation = OperationsRegister.GetOperation(token.Pattern);

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
