using System;
namespace Filters
{
    /// <summary>
    /// Filtr wstawiaj�cy przecinki mi�dzy kolejnymi zapisami.
    /// </summary>
    public class CommaListFilter : OozinozFilter 
    {
        protected bool needComma = false;
        /// <summary>
        /// Konstrukcja filtra przekazuj�cego znaki o losowej wielko�ci
        /// do dostarczonego strumienia.
        /// </summary>
        /// <param name="writer">strumie� docelowy</param>
        public CommaListFilter(ISimpleWriter writer) : base (writer)
        {
        }  
        
        /// <summary>
        ///  W miar� potrzeby wstawia przecinek i spacj� przed podanym znakiem.
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
        /// W miar� potrzeby wstawia przecinek i spacj� przed podanym ci�giem.
        /// </summary>
        /// <param name="s">ci�g docelowy</param>
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
