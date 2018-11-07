using System;
namespace Filters
{
    /// <summary>
    /// Filtr przekazuj�cy znaki i ci�gi znak�w na konsol�.
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
