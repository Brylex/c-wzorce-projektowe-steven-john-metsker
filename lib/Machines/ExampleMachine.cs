using System;
using System.Collections;
namespace Machines
{
    /// <summary>
    /// Klasa dostarcza modele obiektowe struktury maszyn kilku dla fabryk Oozinoz.
    /// </summary>
    public class ExampleMachine 
    {
        /// <summary>
        /// Zwraca fabrykê niebêd¹c¹ drzewem.
        /// </summary>
        /// <returns>fabrykê niebêd¹c¹ drzewem</returns>
        public static MachineComposite Plant()
        {
            MachineComposite plant = new MachineComposite(100);
            MachineComposite bay = new MachineComposite(101);
            Machine m = new Mixer(102);
            Machine n = new StarPress(103);
            Machine o = new ShellAssembler(104);
            bay.Add(m);
            bay.Add(n);
            bay.Add(o);
            plant.Add(m);
            plant.Add(bay);
            return plant;
        }

        /// <summary>
        /// Zwraca przyk³adow¹ liniê produkcyjn¹.
        /// </summary>
        /// <returns>przyk³adow¹ liniê produkcyjn¹</returns>
        public static MachineComposite DublinLine1()
        {
            MachineComposite c = new MachineComposite(1000, "Linia 1"); 
            c.Add(new Mixer(1201));
            c.Add(new StarPress(1401));
            c.Add(new ShellAssembler(1301));
            c.Add(new Fuser(1101));
            c.Add(new UnloadBuffer(1501));
            return c;
        }
        /// <summary>
        /// Zwraca drug¹ przyk³adow¹ liniê produkcyjn¹.
        /// </summary>
        /// <returns>przyk³adow¹ liniê produkcyjn¹</returns>
        public static MachineComposite DublinLine2()
        {
            MachineComposite c = new MachineComposite(2000, "Linia 2"); 
            c.Add(new Mixer(2201));
            c.Add(new Mixer(2202));
            c.Add(new StarPress(2401));
            c.Add(new StarPress(2402));
            c.Add(new ShellAssembler(2301));
            c.Add(new Fuser(2101));
            c.Add(new UnloadBuffer(2501));
            return c;
        }
        /// <summary>
        /// Zwraca trzeci¹ przyk³adow¹ liniê produkcyjn¹.
        /// </summary>
        /// <returns>przyk³adow¹ liniê produkcyjn¹</returns>
        public static MachineComposite DublinLine3()
        {
            MachineComposite c = new MachineComposite(3000, "Linia 3"); 
            c.Add(new Mixer(3201));
            c.Add(new Mixer(3202));
            c.Add(new Mixer(3203));
            c.Add(new Mixer(3204));
            c.Add(new StarPress(3401));
            c.Add(new StarPress(3402));
            c.Add(new StarPress(3403));
            c.Add(new StarPress(3404));
            c.Add(new ShellAssembler(3301));
            c.Add(new ShellAssembler(3302));
            c.Add(new Fuser(3101));
            c.Add(new Fuser(3102));
            c.Add(new UnloadBuffer(3501));
            return c;
        }
        /// <summary>
        /// Zwraca model maszyn w fabryce w Dublinie.
        /// </summary>
        /// <returns>model maszyn w fabryce w Dublinie</returns>
        public static MachineComposite Dublin()
        {
            MachineComposite c = new MachineComposite(0, "Fabryka Dublin"); 
            c.Add(DublinLine1());
            c.Add(DublinLine2());
            c.Add(DublinLine3());
            return c;
        }
    }
}
