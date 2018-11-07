using System;

namespace Controllers
{
    /// <summary>
    /// Mened¿er maszyny adaptuj¹cy wspólny interfejs klasy MachineManager
    /// do konkretnego protoko³u komunikacyjnego maszyny do monta¿u lontów.
    /// </summary>
    public class FuserManager : MachineManager
    {
        private FuserController _controller = new FuserController();
        public override void StartMachine() 
        {
            _controller.StartMachine();
        }
        public override void StopMachine() 
        {
            _controller.StopMachine();
        }
        public override void StartProcess() 
        {
            _controller.Begin();
        }
        public override void StopProcess() 
        {
            _controller.End();
        }
        public override void ConveyIn() 
        {
            _controller.ConveyIn();
        }
        public override void ConveyOut() 
        {
            _controller.ConveyOut();
        }
        public void SwitchSpool()
        {
            _controller.SwitchSpool();
        }
    }
}
