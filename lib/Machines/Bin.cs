namespace Machines
{
	/// <summary>
   /// Minimalny model pojemnika, czyli plastikowego kosza, w kt�rym
   /// umieszczane s� surowce do produkcji fajerwerk�w.
	/// </summary>
	public class Bin
	{
        private int _id;
        /// <summary>
        /// Tworzy pojemnik o podanym identyfikatorze.
        /// </summary>
        /// <param name="id">unikalny identyfikator dla tego pojemnika</param>
        public Bin(int id)
        {
            _id = id;
        }
	}
}
