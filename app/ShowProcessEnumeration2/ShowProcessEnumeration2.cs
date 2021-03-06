using System;
using Enumerators;
using Processes;
/// <summary>
/// Klasa pokazująca wykorzystanie iteratora kompozytu na przykładzie
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