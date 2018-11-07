using System;
using System.Text;

namespace Functions
{
    /// <summary>
    /// Abstrakcyjna nadklasa definiuj¹ca rolê funkcji opakowuj¹cej (dekoruj¹cej)
    /// inn¹ funkcjê.
    /// 
    /// Metody funkcji w tej hierarchii wszystkie maj¹ sygnaturê 
    /// double F(double time). Ka¿da klasa definiuje funkcjê w sposób
    /// zgodny z nazw¹ tej klasy.
    /// 
    /// Argument czasu "time" jest wartoœci¹ od 0 do 1, odpowiadaj¹c¹
    /// momentowi w znormalizowanym przedziale czasu. Na przyk³ad dla krzywej
    /// paraboli czas przebiega od 0 do 1, gdy x przebiega od 0 do podstawy
    /// krzywej, a y przebiega od 0 do apogeum (dla t = 0.5) i ponownie do 0.
    /// </summary>
    public abstract class Frapper 
    {
        protected Frapper[] _sources;
        /// <summary>
        /// Konstrukcja funkcji opakowuj¹cej dostarczone funkcje Ÿród³owe.
        /// </summary>
        /// <param name="sources">funkcje Ÿród³owe opakowywane przez tê funkcjê</param>
        public Frapper(Frapper[] sources)
        {
            _sources = sources;
        }
        /// <summary>
        /// Konstrukcja funkcji opakowuj¹cej dostarczon¹ funkcjê Ÿród³ow¹.
        /// </summary>
        /// <param name="f">funkcja Ÿród³owa opakowywana przez tê funkcjê</param>
        public Frapper(Frapper f) : this(new Frapper[] { f })
        {   
        }
        /// <summary>
        /// Funkcja implementowana przez klasy potomne - przyk³ady jej
        /// implementacji znajduj¹ siê w klasach potomnych.
        /// </summary>
        /// <param name="t">znormalizowana wartoœæ czasu z przedzia³u od 0 do 1</param>
        /// <returns>wartoœæ funkcji</returns>
        public abstract double F(double t);

        /// <summary>
        /// Zwraca tekstow¹ reprezentacjê tej funkcji.
        /// </summary>
        /// <returns>tekstow¹ reprezentacjê tej funkcji</returns>
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
