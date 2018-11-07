using System;
using System.Text.RegularExpressions;

namespace Reservations
{
    /// <summary>
    /// Klasa przetwarzaj�ca tekst zg�oszenia pokazu fajerwerk�w. Zg�oszenie
    /// musi by� rozdzielan� przecinkami list� nazw i warto�ci parametr�w.
    /// Oczekiwane parametry dla pokazu fajerwerk�w to: data, ilo�� widz�w,
    /// miasto, cena od osoby i konkretna lokalizacja. Oto przyk�ad poprawnego
    /// zg�oszenia:
    /// 
    /// <blockquote><pre>
    ///   Date, November 5, Headcount, 250, City, Springfield,
    ///   DollarsPerHead, 9.95, HasSite, No      	   
    ///</pre></blockquote>
    ///
    /// Format daty to nazwa miesi�ca i dzie�. Parser przyjmuje, �e rok 
    /// jest rokiem najbli�szego wyst�pienia podanej daty.
    /// </summary>
    public class ReservationParser 
    {
        private ReservationBuilder _builder;
        /// <summary>
        /// Parsuje zg�oszenie rezerwacji i przekazuje pobrane dane do obiektu
        /// buduj�cego rezerwacj�.
        /// </summary>
        /// <param name="s">tekst zg�oszenia</param>
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
        /// Tworzy parser przekazuj�cy pobrane dane do wskazanego obiektu
        /// buduj�cego rezerwacj�.
        /// </summary>
        /// <param name="builder">docelowy obiekt buduj�cy</param>
        public ReservationParser(ReservationBuilder builder) 
        {
            _builder = builder;
        }
    }
}
