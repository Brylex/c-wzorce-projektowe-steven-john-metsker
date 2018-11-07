using System;
using System.Text;

namespace Functions
{
    /// <summary>
    /// Abstrakcyjna nadklasa definiuj�ca rol� funkcji opakowuj�cej (dekoruj�cej)
    /// inn� funkcj�.
    /// 
    /// Metody funkcji w tej hierarchii wszystkie maj� sygnatur� 
    /// double F(double time). Ka�da klasa definiuje funkcj� w spos�b
    /// zgodny z nazw� tej klasy.
    /// 
    /// Argument czasu "time" jest warto�ci� od 0 do 1, odpowiadaj�c�
    /// momentowi w znormalizowanym przedziale czasu. Na przyk�ad dla krzywej
    /// paraboli czas przebiega od 0 do 1, gdy x przebiega od 0 do podstawy
    /// krzywej, a y przebiega od 0 do apogeum (dla t = 0.5) i ponownie do 0.
    /// </summary>
    public abstract class Frapper 
    {
        protected Frapper[] _sources;
        /// <summary>
        /// Konstrukcja funkcji opakowuj�cej dostarczone funkcje �r�d�owe.
        /// </summary>
        /// <param name="sources">funkcje �r�d�owe opakowywane przez t� funkcj�</param>
        public Frapper(Frapper[] sources)
        {
            _sources = sources;
        }
        /// <summary>
        /// Konstrukcja funkcji opakowuj�cej dostarczon� funkcj� �r�d�ow�.
        /// </summary>
        /// <param name="f">funkcja �r�d�owa opakowywana przez t� funkcj�</param>
        public Frapper(Frapper f) : this(new Frapper[] { f })
        {   
        }
        /// <summary>
        /// Funkcja implementowana przez klasy potomne - przyk�ady jej
        /// implementacji znajduj� si� w klasach potomnych.
        /// </summary>
        /// <param name="t">znormalizowana warto�� czasu z przedzia�u od 0 do 1</param>
        /// <returns>warto�� funkcji</returns>
        public abstract double F(double t);

        /// <summary>
        /// Zwraca tekstow� reprezentacj� tej funkcji.
        /// </summary>
        /// <returns>tekstow� reprezentacj� tej funkcji</returns>
        public override String ToString()
        {
            String name = this.GetType().Name;
            StringBuilder buf = new StringBuilder(name);
            if (_sources.Length > 0)
            {
                buf.Append('(');
                for (int i = 0; i < _sources.Length; i++)
                {
                    if (i > 0)
                    {
                        buf.Append(", ");
                    }
                    buf.Append(_sources[i]);
                }
                buf.Append(')');
            }
            return buf.ToString();
        }
    }
}
