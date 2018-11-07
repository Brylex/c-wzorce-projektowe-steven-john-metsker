using System;
using Processes;
/// <summary>
/// Demonstruje wykorzystanie klasy PrettyVisitor.
/// </summary>
public class ShowPrettyVisitor
{    
    /// <summary>
    /// Punkt wejœcia aplikacji.
    /// </summary>
    public static void Main()
    {
        ProcessComponent p = ShellProcess.Make();
        PrettyVisitor v = new PrettyVisitor();
        Console.WriteLine(v.GetPretty(p));
    }
}