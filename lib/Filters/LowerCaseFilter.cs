using System;
namespace Filters
{
    /// <summary>
    /// Filtr zamieniaj¹cy przetwarzane znaki na ma³e.
    /// </summary>
    public class LowerCaseFilter : OozinozFilter 
    {
        /// <summary>
        /// Konstrukcja filtra przekazuj¹cego ma³e znaki do wskazanego
        /// strumienia.
        /// </summary>
        /// <param name="writer">docelowy obiekt pisz¹cy</param>
        public LowerCaseFilter(ISimpleWriter writer) : base (writer)
        {
        }  
        
        /// <summary>
        /// Przekazuje ma³¹ wersjê podanego znaku do strumienia podstawowego.
        /// </summary>
        /// <param name="c">znak</param>
        public override void Write(char c) 
        {
            _writer.Write(char.ToLower(c));
        }
    }
}
