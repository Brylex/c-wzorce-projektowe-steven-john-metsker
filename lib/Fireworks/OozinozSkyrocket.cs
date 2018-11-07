using System;
using Simulation;

namespace Fireworks
{
	/// <summary>
	/// Instancje tej klasy funkcjonuj� jako obiekty klasy Skyrocket, ale
	/// u�ywaj� informacji z obiektu PhysicalRocket. Klasa jest adapterem
	/// obiektu, adaptuj�cym klas� PhysicalRocket do potrzeb klient�w klasy
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
        /// Modeluje mas� rakiety podczas symulacji na podstawie danych
        /// z obiektu PhysicalRocket.
        /// </summary>
        /// <returns>mas�</returns>
        public override double GetMass()   
        {
            return _rocket.GetMass(_simTime);
        }

        /// <summary>
        /// Modeluje ci�g rakiety podczas symulacji na podstawie danych
        /// z obiektu PhysicalRocket.
        /// </summary>
        /// <returns>ci�g</returns>
        public override double GetThrust()  
        {
            return _rocket.GetThrust(_simTime);
        }
	}
}
