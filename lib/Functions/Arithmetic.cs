using System;
namespace Functions
{
    /// <summary>
    /// Opakowuje funkcj� arytmetyczn� wok� podanej pary funkcji �r�d�owych.
    /// </summary>
    public class Arithmetic : Frapper 
    {
        protected char _op;
        /// <summary>
        /// Konstrukcja funkcji arytmetycznej do��czanej do dostarczonych funkcji
        /// �r�d�owych.
        /// </summary>
        /// <param name="f1">Inna klasa opakowuj�ca funkcj�</param>
        /// <param name="f2">Jeszcze inna klasa opakowuj�ca funkcj�</param>
        public Arithmetic(Char op, Frapper f1, Frapper f2) : base (new Frapper[]{f1, f2})
        {
            _op = op;
        }
        /// <summary>
        /// Zwraca operacj� arytmetyczn� (co wida� w konstruktorze) zastosowan�
        /// do warto�ci funkcji �r�d�owych w momencie t.
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
