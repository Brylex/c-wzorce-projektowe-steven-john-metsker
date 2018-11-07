using System;
namespace Filters
{
    /// <summary>
    /// Klasa obs�uguj�ca mechanizm przekazywania wywo�a� metody Write() filtrowi
    /// wewn�trznemu, wymagaj�ca podania w konstruktorze innego filtra. Klasa
    /// implementuje r�wnie� metod� Write(string), wymagan� przez interfejs
    /// ISimpleWriter. Metoda Write(char) pozostaje jednak abstrakcyjna, gdy� t� 
    /// w�a�nie metod� klasy potomne b�d� implementowa� na r�ne ciekawe sposoby.
    /// </summary>
    public abstract class OozinozFilter : ISimpleWriter 
    {
        protected ISimpleWriter _writer;

        /// <summary>
        /// Konstrukcja filtra przekazuj�cego znaki do wskazanego strumienia.
        /// </summary>
        /// <param name="writer">docelowy obiekt pisz�cy</param>
        public OozinozFilter(ISimpleWriter writer) 
        {
            _writer = writer;
        }  
        /// <summary>
        /// Przekazanie ��dania strumieniowi potomnemu.
        /// </summary>
        public abstract void Write(char c);

        /// <summary>
        /// Zapisuje ci�g znak�w, przekazuj�c go strumieniowi potomnemu.
        /// </summary>
        /// <param name="s">zapisywany ci�g znak�w</param>
        public virtual void Write(string s)
        {
            foreach(char c in s.ToCharArray())
            {
                Write(c);
            }
        }
        /// <summary>
        /// Wstawienie znaku nowej linii.
        /// </summary>
        public virtual void WriteLine()
        {
            _writer.WriteLine();
        }
        /// <summary>
        /// Zamkni�cie filtra wewn�trznego.
        /// </summary>
        public virtual void Close()
        {
            _writer.Close();
        }
    }
}
