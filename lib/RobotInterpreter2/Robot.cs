using System;
using Machines;
namespace RobotInterpreter2
{
    /// <summary>
    /// Klasa modeluj¹ca robota poruszaj¹cego siê po szynach, zbieraj¹cego
    /// i odstawiaj¹cego pojemniki materia³ów dla maszyn.
    /// </summary>
    public class Robot 
    {
        public static readonly Robot singleton = new Robot();
        private Robot()
        {
        }

        /// <summary>
        /// Przesuniêcie do maszyny, podniesienie pojemnika, przesuniêcie
        /// do innej maszyny i postawienie pojemnika.
        /// </summary>
        /// <param name="m1">maszyna pocz¹tkowa</param>
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
