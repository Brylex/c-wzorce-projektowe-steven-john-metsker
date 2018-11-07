using System;
using Machines;
/// <summary>
/// Demonstruje wyliczenie z pomoc¹ foreach.
/// </summary>
class ShowEnumeration2
{
    /// <summary>
    /// Punkt wejœcia aplikacji.
    /// </summary>
    static void Main()
    {
        Machine[] machines = {new Machine(1), new Machine(2)};
        foreach (Machine m in machines) 
        {
            Console.WriteLine(m.ID);
        }
    }
}