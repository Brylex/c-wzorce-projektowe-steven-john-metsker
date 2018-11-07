using System;
namespace Filters
{
    /// <summary>
    /// Filtr zmieniaj�cy wielko�� otrzymywanych znak�w tak, by ka�dy znak
    /// pisany po bia�ym znaku by� wielk� liter�.
    /// </summary>
    public class TitleCaseFilter : OozinozFilter 
    {
        protected bool inWhite = true;
        /// <summary>
        /// Konstrukcja filtra przekazuj�cego znaki odpowiedniej wielko�ci
        /// do wskazanego obiektu pisz�cego.
        /// </summary>
        /// <param name="writer">docelowy obiekt pisz�cy</param>
        public TitleCaseFilter(ISimpleWriter writer) : base (writer)
        {
        }  
        
        /// <summary>
        /// Przekazuje otrzymany znak o odpowiedniej wielko�ci do strumienia
        /// bazowego.
        /// </summary>
        /// <param name="c">znak</param>
        public override void Write(char c) 
        {
            _writer.Write(inWhite
                ? Char.ToUpper(c)
                : Char.ToLower(c));
            inWhite = Char.IsWhiteSpace(c) || c == '\"';
        }
        /// <summary>
        /// Przes�oni�cie tej metody tylko po to, by zaznaczy�, �e
        /// powoduje ona powr�t do bia�ych znak�w.
        /// </summary>
        public override void WriteLine()
        {
            base.WriteLine();
            inWhite = true;
        }
    }
}
