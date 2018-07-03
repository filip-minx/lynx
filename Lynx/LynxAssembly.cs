using System.Collections.Generic;

namespace Lynx
{
    public class LynxAssembly
    {
        public TokenChain Tokens { get; private set;  }

        public LynxAssembly(IEnumerable<Token> tokens)
        {
            Tokens = new TokenChain(tokens);
        }
    }
}