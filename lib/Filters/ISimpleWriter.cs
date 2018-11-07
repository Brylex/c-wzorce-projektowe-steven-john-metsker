namespace Filters
{
    /// <summary>
    /// Interfejs definiuj�cy metody, jakie musz� obs�ugiwa� filty Oozinoz.
    /// </summary>
    public interface ISimpleWriter
    {
        void Write(char c);
        void Write(string s);
        void WriteLine();
        void Close();
    }
}
