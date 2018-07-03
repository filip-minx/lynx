using System.Collections.Generic;

namespace Lynx
{
    interface ICodeParser
    {
        IEnumerable<Token> Parse(string code);
    }
}
