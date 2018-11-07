using System;
using Simulation;

namespace Fireworks
{
	/// <summary>
	/// Instancje tej klasy funkcjonuj¹ jako obiekty klasy Skyrocket, ale
	/// u¿ywaj¹ informacji z obiektu PhysicalRocket. Klasa jest adapterem
	/// obiektu, adaptuj¹cym klasê PhysicalRocket do potrzeb klientów klasy
	/// Skyrocket.
	/// </summary>
	public class OozinozSkyrocket : Skyrocket
    {
        private PhysicalRocket _rocket;
        public OozinozSkyrocket(PhysicalRocket r) : 
            base (r.GetMass(0), r.GetThrust(0), r.GetBurnTime())
		{
            _rocket = r;
		}
        /// <summary>
        /// Modeluje masê rakiety podczas symulacji na podstawie danych
        /// z obiektu PhysicalRocket.
        /// </summary>
        /// <returns>masê</returns>
        public override double GetMass()   
        {
            return _rocket.GetMass(_simTime);
        }

        /// <summary>
        /// Modeluje ci¹g rakiety podczas symulacji na podstawie danych
        /// z obiektu PhysicalRocket.
        /// </summary>
        /// <returns>ci¹g</returns>
        public override double GetThrust()  
        {
            return _rocket.GetThrust(_simTime);
        }
	}
}
