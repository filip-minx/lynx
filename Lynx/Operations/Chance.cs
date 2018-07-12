using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lynx.Operations
{
    public class Chance : Operation
    {
        public override string Identifier => "°";

        public override string VerboseIdentifier => "Chance";

        public override int Arity => 1;

        private static Random random = new Random();

        public override object[] Execute(Arguments arguments, LynxRuntime runtime)
        {
            var probability = arguments.Get<double>(0);

            var randNumber = random.NextDouble();

            return new object[] { randNumber <= probability ? 1 : 0 };
        }
    }
}
