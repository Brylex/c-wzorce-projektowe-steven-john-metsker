using System;
using System.IO;
//using System.Xml;
using System.Xml.Serialization;
using Fireworks;
using Utilities;
 
namespace Recommendations
{
    /// <summary>
    /// Modeluje klienta.
    /// </summary>
    public class Customer 
    {
        private Advisor _advisor;
        public static readonly int BIG_SPENDER_DOLLARS = 1000;

        /// <summary>
        /// Zwraca true jeœli klient zarejestrowa³ swój profil preferencji.
        /// </summary>
        /// <returns>true jeœli klient zarejestrowa³ swój profil preferencji.
        /// Metoda nie jest zaimplementowana.</returns>
        public bool IsRegistered()
        {
            return false;
        }

        /// <summary>
        /// W poni¿szy sposób upewniam siê, ¿e korzystam z w³aœciwego
        /// pliku zawieraj¹cego strategiczn¹ promocjê. Jeœli do systemowej
        /// œcie¿ki klas (classpath) dodasz katalog "oozinoz" z tymi przyk³adami,
        /// ten program odnajdzie plik strategy.xml zawieraj¹cy dane promowanego
        /// fajerwerku. Krótko mówi¹c, jest to przyk³ad znalezienia
        /// i wczytania pliku w³aœciwoœci.
        /// </summary>
        public static void Main() 

        {
            new Customer().GetRecommended();
        }

        /// <summary>
        /// Zwraca sumê wydatków klienta w Oozinoz od podanej daty.
        /// </summary>
        /// <param name="date">Data pocz¹tkowa</param>
        /// <returns>sumê wydatków klienta w Oozinoz od podanej daty;
        /// metoda nie jest zaimplementowana.
        /// </returns>
        public double SpendingSince(DateTime date)
        {
            return 1000;
        }


        private Advisor GetAdvisor()
        {
            if (_advisor == null)
            {
                if (PromotionAdvisor.singleton.HasItem())
                {
                    _advisor = PromotionAdvisor.singleton;
                }
                else if (IsRegistered())
                {
                    _advisor = GroupAdvisor.singleton;
                }
                else if (IsBigSpender())
                {
                    _advisor = ItemAdvisor.singleton;
                }
                else
                {
                    _advisor = RandomAdvisor.singleton;
                }
            }
            return _advisor;
        }

        /// <summary>
        /// Zwraca fajerwerk polecany klientowi.
        /// </summary>
        /// <returns>fajerwerk polecany klientowi</returns>
        public Firework GetRecommended()
        {
            // jeœli promowany jest konkretny fajerwerk, nale¿y do zwróciæ
            try
            {
                String s = FileFinder.GetFileName("config", "strategy.xml");
                StreamReader r = new StreamReader(s);
                XmlSerializer xs = new XmlSerializer(typeof(String));
                String promotedName = (String) xs.Deserialize(r);
                r.Close();

                Firework f = Firework.Lookup(promotedName);
                if (f != null)
                {
                    return f;
                }
            }
            catch {}

            // jeœli klient jest zarejestrowany, trzeba go porównaæ z innymi
            if (IsRegistered())
            {
                return (Firework) Rel8.Advise(this);
            }
            // sprawdzenie wydatków z ubieg³ego roku
            if (SpendingSince(DateTime.Now.AddYears(-1)) > 1000)
            {
                return (Firework) LikeMyStuff.Suggest(this);
            }
            // trudno - bêdzie losowy
            return Firework.GetRandom();
        }

        /// <summary>
        /// Zwraca fajerwerk polecany klientowi.
        /// </summary>
        /// <returns>fajerwerk polecany klientowi. Metoda przekszta³cona do
        /// wzorca Strategy.</returns>
        public Firework GetRecommended_2()
        {
            return GetAdvisor().Recommend(this);
        }

        private bool IsBigSpender()
        {
            return SpendingSince(DateTime.Now.AddYears(-1)) > BIG_SPENDER_DOLLARS;
        }
    }
}
