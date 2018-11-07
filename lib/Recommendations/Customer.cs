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
        /// Zwraca true je�li klient zarejestrowa� sw�j profil preferencji.
        /// </summary>
        /// <returns>true je�li klient zarejestrowa� sw�j profil preferencji.
        /// Metoda nie jest zaimplementowana.</returns>
        public bool IsRegistered()
        {
            return false;
        }

        /// <summary>
        /// W poni�szy spos�b upewniam si�, �e korzystam z w�a�ciwego
        /// pliku zawieraj�cego strategiczn� promocj�. Je�li do systemowej
        /// �cie�ki klas (classpath) dodasz katalog "oozinoz" z tymi przyk�adami,
        /// ten program odnajdzie plik strategy.xml zawieraj�cy dane promowanego
        /// fajerwerku. Kr�tko m�wi�c, jest to przyk�ad znalezienia
        /// i wczytania pliku w�a�ciwo�ci.
        /// </summary>
        public static void Main() 

        {
            new Customer().GetRecommended();
        }

        /// <summary>
        /// Zwraca sum� wydatk�w klienta w Oozinoz od podanej daty.
        /// </summary>
        /// <param name="date">Data pocz�tkowa</param>
        /// <returns>sum� wydatk�w klienta w Oozinoz od podanej daty;
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
            // je�li promowany jest konkretny fajerwerk, nale�y do zwr�ci�
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

            // je�li klient jest zarejestrowany, trzeba go por�wna� z innymi
            if (IsRegistered())
            {
                return (Firework) Rel8.Advise(this);
            }
            // sprawdzenie wydatk�w z ubieg�ego roku
            if (SpendingSince(DateTime.Now.AddYears(-1)) > 1000)
            {
                return (Firework) LikeMyStuff.Suggest(this);
            }
            // trudno - b�dzie losowy
            return Firework.GetRandom();
        }

        /// <summary>
        /// Zwraca fajerwerk polecany klientowi.
        /// </summary>
        /// <returns>fajerwerk polecany klientowi. Metoda przekszta�cona do
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
