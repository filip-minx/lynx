namespace Lynx
{
    public interface ILanguageProvider
    {
        TokenChain Compile(string code);
        string GenerateCode(TokenChain assembly);
    }
}
