using System;
using System.Drawing;
/// <summary>
/// Program z rozdzia³u 14 - niestety niedzia³aj¹cy.
/// </summary>
public class ShowStructs
{ 
    static void Main(string[] args)
    {
        Point[] points = new Point[1];
        DateTime[] times = new DateTime[1];
        String[] strings = new String[1];

        Console.WriteLine("Które z poni¿szych poleceñ powoduje awariê programu?");
        Console.WriteLine(points[0].ToString());
        Console.WriteLine(times[0].ToString());
        Console.WriteLine(strings[0].Length); 
    }
}