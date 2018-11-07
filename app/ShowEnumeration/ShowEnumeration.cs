using System;
using System.Collections;
using Machines;
/// <summary>
/// Demonstruje rêczne wyliczenie.
/// </summary>
class ShowEnumeration
{
    /// <summary>
    /// Punkt wejœcia aplikacji.
    /// </summary>
    static void Main()
    {
        Machine[] machines = {new Machine(1), new Machine(2)};
        IEnumerator e = machines.GetEnumerator();
        while (e.MoveNext())
        {
            Machine m = (Machine) e.Current;
            Console.WriteLine(m.ID);
        }
    }
}