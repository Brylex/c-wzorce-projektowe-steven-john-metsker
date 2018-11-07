using System;
namespace Filters
{
    /// <summary>
    /// Klasa obs³uguj¹ca mechanizm przekazywania wywo³añ metody Write() filtrowi
    /// wewnêtrznemu, wymagaj¹ca podania w konstruktorze innego filtra. Klasa
    /// implementuje równie¿ metodê Write(string), wymagan¹ przez interfejs
    /// ISimpleWriter. Metoda Write(char) pozostaje jednak abstrakcyjna, gdy¿ tê 
    /// w³aœnie metodê klasy potomne bêd¹ implementowaæ na ró¿ne ciekawe sposoby.
    /// </summary>
    public abstract class OozinozFilter : ISimpleWriter 
    {
        protected ISimpleWriter _writer;

        /// <summary>
        /// Konstrukcja filtra przekazuj¹cego znaki do wskazanego strumienia.
        /// </summary>
        /// <param name="writer">docelowy obiekt pisz¹cy</param>
        public OozinozFilter(ISimpleWriter writer) 
        {
            _writer = writer;
        }  
        /// <summary>
        /// Przekazanie ¿¹dania strumieniowi potomnemu.
        /// </summary>
        public abstract void Write(char c);

        /// <summary>
        /// Zapisuje ci¹g znaków, przekazuj¹c go strumieniowi potomnemu.
        /// </summary>
        /// <param name="s">zapisywany ci¹g znaków</param>
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
        /// Zamkniêcie filtra wewnêtrznego.
        /// </summary>
        public virtual void Close()
        {
            _writer.Close();
        }
    }
}
