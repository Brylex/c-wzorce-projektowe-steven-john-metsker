using System;

namespace Controllers
{
	/// <summary>
	/// Przyk³ad z rozdzia³u Bridge. Jest to klasa abstrakcyjna, a zarazem
	/// przyk³ad abstrakcji - klasy zawieraj¹cej metody konkretne zale¿ne
	/// od metod abstrakcyjnych.
	/// </summary>
	public abstract class MachineManager
    {
        public abstract void StartMachine();
        public abstract void StopMachine();
        public abstract void StartProcess();
        public abstract void StopProcess();
        public abstract void ConveyIn();
        public abstract void ConveyOut();
        public void Shutdown() 
        {
            StopProcess();
            ConveyOut();
            StopMachine();
        }
	}
}
