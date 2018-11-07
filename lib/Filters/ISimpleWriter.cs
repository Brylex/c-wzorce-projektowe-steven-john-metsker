namespace Filters
{
    /// <summary>
    /// Interfejs definiuj¹cy metody, jakie musz¹ obs³ugiwaæ filty Oozinoz.
    /// </summary>
    public interface ISimpleWriter
    {
        void Write(char c);
        void Write(string s);
        void WriteLine();
        void Close();
    }
}
