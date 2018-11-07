using System;

namespace Fireworks
{
    /// <summary>
    /// Obiekty tej klasy odpowiadaj¹ ró¿nym typom fajerwerków.
    /// </summary>
    public class Firework
    {
        private string _name;
        private double _mass;
        private decimal _price;
        /// <summary>
        /// Umo¿liwia tworzenie pustych obiektów w celu obs³u¿enia rekonstrukcji
        /// z pamiêci trwa³ej.
        /// </summary>
        public Firework()
        {
        }
        /// <summary>
        /// Tworzy fajerwerk z podanego kompletu w³aœciwoœci.
        /// </summary>
        /// <param name="name">Unikalna nazwa tego typu fajerwerku</param>
        /// <param name="mass">Masa (w kilogramach) dla jednej instancji tego typu</param>
        /// <param name="price">Cena (w dolarach) dla jednej instancji tego typu</param>
        public Firework (string name, double mass, decimal price)
        {
            Name = name;
            Mass = mass;
            Price = price;
        }       
        /// <summary>
        /// Unikalna nazwa tego typu fajerwerku
        /// </summary>
        public string Name 
        {
            get
            {
                return _name;
            }
            set  
            {
                _name = value;
            }
        }
        /// <summary>
        /// Masa (w kilogramach) dla jednej instancji tego typu
        /// </summary>
        public double Mass
        {
            get 
            {
                return _mass;
            }
            set 
            { 
                _mass = value;
            }
        }
        /// <summary>
        /// Cena (w dolarach) dla jednej instancji tego typu
        /// </summary>
        public decimal Price 
        {
            get
            {
                return _price;
            }
            set  
            {
                _price = value;
            }
        }    
        /// <summary>
        /// Tekstowa reprezentacja fajerwerku.
        /// </summary>
        /// <returns>nazwê fajerwerku</returns>
        public override string ToString() 
        {
            return Name;
        }

        /// <summary>
        /// Zwraca fajerwerk o zadanej nazwie. Metoda jest wykorzystywana
        /// w przyk³adzie dla wzorca Strategy, ale nie jest zaimplementowana.
        /// </summary>
        /// <param name="name">nazwa szukanego fajerwerku</param>
        /// <returns>fajerwerk o zadanej nazwie; nieimplementowana</returns>
        public static Firework Lookup(String name)
        {
            return new Firework();
        }
 
        /// <summary>
        /// Zwraca losowo wybrany fajerwerk. Metoda nie jest implementowana
        /// i jest u¿ywana jedynie jako przyk³ad wzorca Strategy.
        /// </summary>
        /// <returns></returns>
        public static Firework GetRandom()
        {
            return new Firework();
        }
    }
}
