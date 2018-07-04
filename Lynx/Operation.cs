using System;

namespace Lynx
{
    public abstract class Operation : IEquatable<Operation>
    {
        public abstract string Identifier { get; }
        public abstract string VerboseIdentifier { get; }
        public abstract int Arity { get; }

        public bool Equals(Operation other)
        {
            if (other == null) return false;

            // Identifier should be globally unique
            // so there is no need to check anything else.
            return Identifier == other.Identifier;
        }

        public abstract object[] Execute(Arguments arguments, LynxRuntime runtime);
    }
}
