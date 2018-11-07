using System;
namespace Filters
{
    /// <summary>
    /// Filtr przekazuj¹cy znaki i ci¹gi znaków na konsolê.
    /// </summary>
    public class ConsoleWriter : ISimpleWriter
    {
        public void Write(char c)
        {
            Console.Write(c);
        }       
        public void Write(string s)
        {
            Console.Write(s);
        }
        public void WriteLine()
        {
            Console.WriteLine();
        }
        public void Close()
        {
        }
    }
}
