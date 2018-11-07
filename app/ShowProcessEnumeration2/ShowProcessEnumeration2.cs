using System;
using Enumerators;
using Processes;
/// <summary>
/// Klasa pokazuj¹ca wykorzystanie iteratora kompozytu na przyk³adzie
/// procesu produkcji fajerwerków.
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