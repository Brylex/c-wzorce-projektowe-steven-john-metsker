using System;
namespace Filters
{
    /// <summary>
    /// Filtr wprowadzaj�cy losow� wielko�� otrzymywanych znak�w.
    /// </summary>
    public class RandomCaseFilter : OozinozFilter 
    {
        protected Random ran = new Random();
        /// <summary>
        /// Konstrukcja filtra przekazuj�cego znaki o losowej wielko�ci
        /// do wskazanego strumienia.
        /// </summary>
        /// <param name="writer">strumie� docelowy</param>
        public RandomCaseFilter(ISimpleWriter writer) : base (writer)
        {
        }  
        
        /// <summary>
        /// Przekazuje ma�� wersj� podanego znaku do strumienia podstawowego.
        /// </summary>
        /// <param name="c">znak</param>
        public override void Write(char c) 
        {
            _writer.Write(ran.NextDouble() > .5
                ? Char.ToLower(c)
                : Char.ToUpper(c));
        }
    }
}
