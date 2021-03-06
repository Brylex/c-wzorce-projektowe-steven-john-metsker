using System;
namespace Filters
{
    /// <summary>
    /// Filtr zamieniający otrzymywane znaki na wielkie litery.
    /// </summary>
    public class UpperCaseFilter : OozinozFilter 
    {
        /// <summary>
        /// Konstrukcja filtra przekazującego znaki zamienione na wielkie
        /// litery do wskazanego strumienia.
        /// </summary>
        /// <param name="writer">strumień docelowy</param>
        public UpperCaseFilter(ISimpleWriter writer) : base (writer)
        {
        }  
        
        /// <summary>
        /// Przekazuje wielką wersję otrzymanego znaku do strumienia bazowego.
        /// </summary>
        /// <param name="c">the character</param>
        public override void Write(char c) 
        {
            _writer.Write(Char.ToUpper(c));
        }
    }
}
