using System;
namespace Filters
{
    /// <summary>
    /// Filtr zmieniaj¹cy wielkoœæ otrzymywanych znaków tak, by ka¿dy znak
    /// pisany po bia³ym znaku by³ wielk¹ liter¹.
    /// </summary>
    public class TitleCaseFilter : OozinozFilter 
    {
        protected bool inWhite = true;
        /// <summary>
        /// Konstrukcja filtra przekazuj¹cego znaki odpowiedniej wielkoœci
        /// do wskazanego obiektu pisz¹cego.
        /// </summary>
        /// <param name="writer">docelowy obiekt pisz¹cy</param>
        public TitleCaseFilter(ISimpleWriter writer) : base (writer)
        {
        }  
        
        /// <summary>
        /// Przekazuje otrzymany znak o odpowiedniej wielkoœci do strumienia
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
        /// Przes³oniêcie tej metody tylko po to, by zaznaczyæ, ¿e
        /// powoduje ona powrót do bia³ych znaków.
        /// </summary>
        public override void WriteLine()
        {
            base.WriteLine();
            inWhite = true;
        }
    }
}
