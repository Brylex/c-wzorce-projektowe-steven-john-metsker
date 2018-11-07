using System;
using Enumerators;
using Processes;
/// <summary>
/// Klasa pokazuj�ca wykorzystanie iteratora kompozytu na przyk�adzie
/// procesu produkcji fajerwerk�w.
/// </summary>
public class ShowProcessEnumeration2
{
    public static void Main() 
    {
        CompositeEnumerator e = (CompositeEnumerator) ShellProcess.Make().GetEnumerator();
        while (e.MoveNext())
        {
            for (int i = 0; i < e.Depth(); i ++)
            {
                Console.Write("    ");
            }
            Console.WriteLine(e.Current);
        }
    }
}