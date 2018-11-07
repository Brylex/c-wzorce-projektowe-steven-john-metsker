using System;
namespace Filters
{
    /// <summary>
    /// Filtr wstawiaj¹cy przecinki miêdzy kolejnymi zapisami.
    /// </summary>
    public class CommaListFilter : OozinozFilter 
    {
        protected bool needComma = false;
        /// <summary>
        /// Konstrukcja filtra przekazuj¹cego znaki o losowej wielkoœci
        /// do dostarczonego strumienia.
        /// </summary>
        /// <param name="writer">strumieñ docelowy</param>
        public CommaListFilter(ISimpleWriter writer) : base (writer)
        {
        }  
        
        /// <summary>
        ///  W miarê potrzeby wstawia przecinek i spacjê przed podanym znakiem.
        /// </summary>
        /// <param name="c">znak</param>
        public override void Write(char c) 
        {
            if (needComma) 
            {
                _writer.Write(',');
                _writer.Write(' ');
            }
            _writer.Write(c);
            needComma = true;
        }
        /// <summary>
        /// W miarê potrzeby wstawia przecinek i spacjê przed podanym ci¹giem.
        /// </summary>
        /// <param name="s">ci¹g docelowy</param>
        public override void Write(string s)
        {
            if (needComma) 
            {
                _writer.Write(", ");
            }
            _writer.Write(s);
            needComma = true;
        }
    }
}
