using System;

namespace Controllers
{
	/// <summary>
	/// Przyk�ad z rozdzia�u Bridge. Jest to klasa abstrakcyjna, a zarazem
	/// przyk�ad abstrakcji - klasy zawieraj�cej metody konkretne zale�ne
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
