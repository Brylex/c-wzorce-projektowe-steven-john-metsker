using System.IO;
namespace Filters
{
	/// <summary>
	/// Klasa dostarcza wersj� klasy StreamWriter implementuj�c� ISimpleWriter. Instancje
	/// tej klasy mog� by� u�ywane w konstruktorach klas potomnych OozinozFilter.
	/// SimpleStreamWriter dziedziczy z klasy StreamWriter metody Write() wymagane przez
	/// interfejs ISimpleWriter.
	/// </summary>
	public class SimpleStreamWriter : StreamWriter, ISimpleWriter
	{
        /// <summary>
        /// Konstruktor umo�liwia stworzenie obiektu SimpleStreamWriter
        /// z dowolnego typu strumienia.
        /// </summary>
        /// <param name="s">bazowy strumie� docelowy dla ��da� zapisu</param>
        public SimpleStreamWriter(Stream s) : base (s) 
        {
        }
        /// <summary>
        /// Ten konstruktor s�u�y wy��cznie wygodzie. Nadklasa utworzy obiekt
        /// FileStream na podstawie dostarczonej �cie�ki.
        /// </summary>
        /// <param name="path">nazwa pliku docelowego do zapisu</param>
        public SimpleStreamWriter(string path) : base (path)
        {
        }
	}
}
