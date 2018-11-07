using System;
namespace Filters
{
    /// <summary>
    /// Filtr wprowadzaj¹cy losow¹ wielkoœæ otrzymywanych znaków.
    /// </summary>
    public class RandomCaseFilter : OozinozFilter 
    {
        protected Random ran = new Random();
        /// <summary>
        /// Konstrukcja filtra przekazuj¹cego znaki o losowej wielkoœci
        /// do wskazanego strumienia.
        /// </summary>
        /// <param name="writer">strumieñ docelowy</param>
        public RandomCaseFilter(ISimpleWriter writer) : base (writer)
        {
        }  
        
        /// <summary>
        /// Przekazuje ma³¹ wersjê podanego znaku do strumienia podstawowego.
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
