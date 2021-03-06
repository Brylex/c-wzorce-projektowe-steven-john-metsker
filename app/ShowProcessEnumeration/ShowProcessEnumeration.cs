using System;
using Enumerators;
using Processes;
/// <summary>
/// Klasa pokazująca wykorzystanie iteratora kompozytu na przykładzie
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