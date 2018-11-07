using System;
using Filters;

/// <summary>
/// Pokazuje efekt wprowadzenia losowej wielkoœci liter.
/// </summary>
public class ShowRandom
{
    public static void Main()
    {
        ISimpleWriter w = new RandomCaseFilter(
            new ConsoleWriter());
        w.Write(
            "kup dwie paczki a otrzymasz " + 
            "rakietê kieszonkow¹ zippie gratis!");
        w.WriteLine();
        w.Close();
    }
}