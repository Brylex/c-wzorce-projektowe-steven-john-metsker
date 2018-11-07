using System;
namespace Filters
{
    /// <summary>
    /// Filtr zamieniaj�cy przetwarzane znaki na ma�e.
    /// </summary>
    public class LowerCaseFilter : OozinozFilter 
    {
        /// <summary>
        /// Konstrukcja filtra przekazuj�cego ma�e znaki do wskazanego
        /// strumienia.
        /// </summary>
        /// <param name="writer">docelowy obiekt pisz�cy</param>
        public LowerCaseFilter(ISimpleWriter writer) : base (writer)
        {
        }  
        
        /// <summary>
        /// Przekazuje ma�� wersj� podanego znaku do strumienia podstawowego.
        /// </summary>
        /// <param name="c">znak</param>
        public override void Write(char c) 
        {
            _writer.Write(char.ToLower(c));
        }
    }
}
