using System;
using System.Drawing;
/// <summary>
/// Program z rozdzia�u 14 - niestety niedzia�aj�cy.
/// </summary>
public class ShowStructs
{ 
    static void Main(string[] args)
    {
        Point[] points = new Point[1];
        DateTime[] times = new DateTime[1];
        String[] strings = new String[1];

        Console.WriteLine("Kt�re z poni�szych polece� powoduje awari� programu?");
        Console.WriteLine(points[0].ToString());
        Console.WriteLine(times[0].ToString());
        Console.WriteLine(strings[0].Length); 
    }
}