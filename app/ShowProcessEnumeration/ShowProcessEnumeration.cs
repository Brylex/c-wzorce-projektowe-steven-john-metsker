using System;
using Enumerators;
using Processes;
/// <summary>
/// Klasa pokazuj�ca wykorzystanie iteratora kompozytu na przyk�adzie
/// procesu produkcji fajerwerk�w.
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