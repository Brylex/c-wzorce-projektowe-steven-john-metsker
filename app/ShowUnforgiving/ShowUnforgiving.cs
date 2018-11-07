using System;
using Reservations;
/// <summary>
/// Klasa pokazuje obiekt buduj�cy, kt�ry zwraca wyj�tek w razie stwierdzenia
/// jakichkolwiek nieprawid�owo�ci w danych wej�ciowych.
/// </summary>
public class ShowUnforgiving 
{    
    public static void Main() 
    {
        String sample =
            "Date, November 5, Headcount, 250, "
            + "City, Springfield, DollarsPerHead, 9.95, "
            + "HasSite, False";
        ReservationBuilder b = new UnforgivingBuilder();
        new ReservationParser(b).Parse(sample);
        try 
        {
            Reservation r = b.Build();
            Console.WriteLine(r);
        } 
        catch (BuilderException e) 
        {
            Console.WriteLine(e.Message);
        }
    }
}