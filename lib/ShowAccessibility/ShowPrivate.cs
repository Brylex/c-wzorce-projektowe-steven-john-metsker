/// <summary>
/// Klasa u¿ywana w æwiczeniu na kontrolê dostêpu z rozdzia³u 7.
/// </summary>
public class Firework
{
    private double price = 0;
    private double compare(Firework f) 
    {
        return price - f.price;
    }
}