using System;
namespace Filters
{
    /// <summary>
    /// Filtr zamieniaj�cy otrzymywane znaki na wielkie litery.
    /// </summary>
    public class UpperCaseFilter : OozinozFilter 
    {
        /// <summary>
        /// Konstrukcja filtra przekazuj�cego znaki zamienione na wielkie
        /// litery do wskazanego strumienia.
        /// </summary>
        /// <param name="writer">strumie� docelowy</param>
        public UpperCaseFilter(ISimpleWriter writer) : base (writer)
        {
        }  
        
        /// <summary>
        /// Przekazuje wielk� wersj� otrzymanego znaku do strumienia bazowego.
        /// </summary>
        /// <param name="c">the character</param>
        public override void Write(char c) 
        {
            _writer.Write(Char.ToUpper(c));
        }
    }
}
