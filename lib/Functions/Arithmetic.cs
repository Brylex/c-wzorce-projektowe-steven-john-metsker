using System;
namespace Functions
{
    /// <summary>
    /// Opakowuje funkcjê arytmetyczn¹ wokó³ podanej pary funkcji Ÿród³owych.
    /// </summary>
    public class Arithmetic : Frapper 
    {
        protected char _op;
        /// <summary>
        /// Konstrukcja funkcji arytmetycznej do³¹czanej do dostarczonych funkcji
        /// Ÿród³owych.
        /// </summary>
        /// <param name="f1">Inna klasa opakowuj¹ca funkcjê</param>
        /// <param name="f2">Jeszcze inna klasa opakowuj¹ca funkcjê</param>
        public Arithmetic(Char op, Frapper f1, Frapper f2) : base (new Frapper[]{f1, f2})
        {
            _op = op;
        }
        /// <summary>
        /// Zwraca operacjê arytmetyczn¹ (co widaæ w konstruktorze) zastosowan¹
        /// do wartoœci funkcji Ÿród³owych w momencie t.
        /// </summary>
        /// <param name="t">czas</param>
        /// <returns>wynik operacji arytmetycznej dla momentu t</returns>
        public override double F(double t)
        {
            switch (_op)
            {
                case '+' :
                    return _sources[0].F(t) + _sources[1].F(t);
                case '-' :
                    return _sources[0].F(t) - _sources[1].F(t);
                case '*' :
                    return _sources[0].F(t) * _sources[1].F(t);
                case '/' :
                    return _sources[0].F(t) / _sources[1].F(t);
                default :
                    return 0;
            }
        }
    }
}
