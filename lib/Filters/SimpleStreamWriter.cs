using System.IO;
namespace Filters
{
	/// <summary>
	/// Klasa dostarcza wersjê klasy StreamWriter implementuj¹c¹ ISimpleWriter. Instancje
	/// tej klasy mog¹ byæ u¿ywane w konstruktorach klas potomnych OozinozFilter.
	/// SimpleStreamWriter dziedziczy z klasy StreamWriter metody Write() wymagane przez
	/// interfejs ISimpleWriter.
	/// </summary>
	public class SimpleStreamWriter : StreamWriter, ISimpleWriter
	{
        /// <summary>
        /// Konstruktor umo¿liwia stworzenie obiektu SimpleStreamWriter
        /// z dowolnego typu strumienia.
        /// </summary>
        /// <param name="s">bazowy strumieñ docelowy dla ¿¹dañ zapisu</param>
        public SimpleStreamWriter(Stream s) : base (s) 
        {
        }
        /// <summary>
        /// Ten konstruktor s³u¿y wy³¹cznie wygodzie. Nadklasa utworzy obiekt
        /// FileStream na podstawie dostarczonej œcie¿ki.
        /// </summary>
        /// <param name="path">nazwa pliku docelowego do zapisu</param>
        public SimpleStreamWriter(string path) : base (path)
        {
        }
	}
}
