using System;
using Machines;
namespace RobotInterpreter2
{
    /// <summary>
    /// Klasa modeluj�ca robota poruszaj�cego si� po szynach, zbieraj�cego
    /// i odstawiaj�cego pojemniki materia��w dla maszyn.
    /// </summary>
    public class Robot 
    {
        public static readonly Robot singleton = new Robot();
        private Robot()
        {
        }

        /// <summary>
        /// Przesuni�cie do maszyny, podniesienie pojemnika, przesuni�cie
        /// do innej maszyny i postawienie pojemnika.
        /// </summary>
        /// <param name="m1">maszyna pocz�tkowa</param>
        /// <param name="m2">maszyna docelowa</param>
        public void Carry(Machine m1, Machine m2)
        {
            Console.WriteLine("Robot przenosi z " + m1 + " do " + m2);
            Bin b = m1.Unload();
            if (b != null) 
            {
                m2.Load(b);
            }
        }
    }
}
