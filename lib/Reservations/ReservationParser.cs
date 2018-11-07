using System;
using System.Text.RegularExpressions;

namespace Reservations
{
    /// <summary>
    /// Klasa przetwarzaj¹ca tekst zg³oszenia pokazu fajerwerków. Zg³oszenie
    /// musi byæ rozdzielan¹ przecinkami list¹ nazw i wartoœci parametrów.
    /// Oczekiwane parametry dla pokazu fajerwerków to: data, iloœæ widzów,
    /// miasto, cena od osoby i konkretna lokalizacja. Oto przyk³ad poprawnego
    /// zg³oszenia:
    /// 
    /// <blockquote><pre>
    ///   Date, November 5, Headcount, 250, City, Springfield,
    ///   DollarsPerHead, 9.95, HasSite, No      	   
    ///</pre></blockquote>
    ///
    /// Format daty to nazwa miesi¹ca i dzieñ. Parser przyjmuje, ¿e rok 
    /// jest rokiem najbli¿szego wyst¹pienia podanej daty.
    /// </summary>
    public class ReservationParser 
    {
        private ReservationBuilder _builder;
        /// <summary>
        /// Parsuje zg³oszenie rezerwacji i przekazuje pobrane dane do obiektu
        /// buduj¹cego rezerwacjê.
        /// </summary>
        /// <param name="s">tekst zg³oszenia</param>
        public void Parse(String s)
        {         
            string[] tokens = new Regex(@",\s*").Split(s);
            for (int i = 0; i < tokens.Length; i += 2 ) 
            {
                String type = tokens[i];
                String val = tokens[i + 1];

                if (String.Compare("date", type, true) == 0)
                { 
                    DateTime d = DateTime.Parse(val);
                    _builder.Date = ReservationBuilder.Futurize(d);
                }
                else if (String.Compare("headcount", type, true) == 0)
                {
                    _builder.Headcount = Int32.Parse(val);
                }
                else if (String.Compare("City", type, true) == 0)
                {
                    _builder.City = val.Trim();
                }
                else if (String.Compare("DollarsPerHead", type, true) == 0)
                {
                    _builder.DollarsPerHead = (decimal)Double.Parse(val);
                }
                else if (String.Compare("HasSite", type, true) == 0)
                {
                    _builder.HasSite = Boolean.Parse(val);
                     
                } 
            }
        }
        /// <summary>
        /// Tworzy parser przekazuj¹cy pobrane dane do wskazanego obiektu
        /// buduj¹cego rezerwacjê.
        /// </summary>
        /// <param name="builder">docelowy obiekt buduj¹cy</param>
        public ReservationParser(ReservationBuilder builder) 
        {
            _builder = builder;
        }
    }
}
