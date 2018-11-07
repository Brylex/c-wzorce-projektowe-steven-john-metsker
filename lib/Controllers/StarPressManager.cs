using System;

namespace Controllers
{
	/// <summary>
    /// Mened¿er maszyny adaptuj¹cy wspólny interfejs klasy MachineManager
    /// do konkretnego protoko³u komunikacyjnego kontrolera prasy gwiazdowej.
	/// </summary>
	public class StarPressManager : MachineManager
	{
        private StarPressController _controller = new StarPressController();
        public override void StartMachine() 
        {
            _controller.Start();
        }
        public override void StopMachine() 
        {
            _controller.Stop();
        }
        public override void StartProcess() 
        {
            _controller.StartProcess();
        }
        public override void StopProcess() 
        {
            _controller.EndProcess();
        }
        public override void ConveyIn() 
        {
            _controller.Index();
        }
        public override void ConveyOut() 
        {
            _controller.Discharge();
        }
	}
}
