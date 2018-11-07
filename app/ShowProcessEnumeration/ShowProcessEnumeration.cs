using System;
using Enumerators;
using Processes;
/// <summary>
/// Klasa pokazuj¹ca wykorzystanie iteratora kompozytu na przyk³adzie
/// procesu produkcji fajerwerków.
/// </summary>
public class ShowProcessEnumeration 
{
    public static void Main() 
    {
        foreach (ProcessComponent pc in ShellProcess.Make())
        {
            Console.WriteLine(pc);
        }
    }
}