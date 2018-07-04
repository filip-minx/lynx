using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Lynx
{
    public class TokenChain : IEnumerable<Token>
    {
        private readonly List<Token> tokens;

        public int Position { get; set; }

        public int Count => tokens.Count;

        public Token this[int index]
        {
            get
            {
                return tokens[index];
            }
            set
            {
                tokens[index] = value;
            }
        }

        public TokenChain(IEnumerable<Token> tokens)
        {
            this.tokens = tokens.ToList();
        }

        public Token GetNext()
        {
            if (Position + 1 > Count - 1)
            {
                return null;
            }

            return tokens[Position++];
        }

        public bool TryGetNext(out Token token)
        {
            if (Position > Count - 1)
            {
                token = null;
                return false;
            }

            token = tokens[Position++];
            return true;
        }

        public override string ToString()
        {
            return string.Join(" ", tokens);
        }

        public IEnumerator<Token> GetEnumerator()
        {
            return ((IEnumerable<Token>)tokens).GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return ((IEnumerable<Token>)tokens).GetEnumerator();
        }
    }
}
