using System;
using Machines;
/// <summary>
/// Demonstruje wyliczenie z pomoc� foreach.
/// </summary>
class ShowEnumeration2
{
    /// <summary>
    /// Punkt wej�cia aplikacji.
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