using System;
using Filters;

/// <summary>
/// Pokazuje efekt wprowadzenia losowej wielko�ci liter.
/// </summary>
public class ShowRandom
{
    public static void Main()
    {
        ISimpleWriter w = new RandomCaseFilter(
            new ConsoleWriter());
        w.Write(
            "kup dwie paczki a otrzymasz " + 
            "rakiet� kieszonkow� zippie gratis!");
        w.WriteLine();
        w.Close();
    }
}