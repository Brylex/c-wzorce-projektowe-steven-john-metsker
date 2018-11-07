using System;
using System.IO;
using System.Xml.Serialization;
using Fireworks;
using Utilities;
namespace Recommendations
{
    /// <summary>
    ///  Implementacja interfejsu Advisor, polecaj¹ca aktualnie promowany
    ///  fajerwerk.
    /// </summary>
    public class PromotionAdvisor : Advisor 
    {
        public static readonly PromotionAdvisor singleton =
            new PromotionAdvisor();
        private Firework _promoted;
        // wyszukanie promowanego fajerwerku
        private PromotionAdvisor()
        {
            try
            {
                String s = FileFinder.GetFileName("config", "strategy.xml");
                StreamReader r = new StreamReader(s);
                XmlSerializer xs = new XmlSerializer(typeof(String));
                String name = (String) xs.Deserialize(r);
                r.Close();
                _promoted = Firework.Lookup(name);
            }
            catch {}
        }

        /// <summary>
        /// Zwraca true jeœli konstruktor znalaz³ promowany fajerwerk.
        /// </summary>
        /// <returns>true jeœli konstruktor znalaz³ promowany fajerwerk</returns>
        public bool HasItem()
        {
            return _promoted != null;
        }

        /// <summary>
        /// Poleca klientowi odpowiedni produkt z aktualnej promocji.
        /// </summary>
        /// <param name="c">klient</param>
        /// <returns>polecany produkt</returns>
        public Firework Recommend(Customer c)
        {
            return _promoted;
        }
    }
}
