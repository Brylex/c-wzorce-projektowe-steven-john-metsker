/// <summary>
/// Klasa u�ywana w �wiczeniu na kontrol� dost�pu z rozdzia�u 7.
/// </summary>
public class Firework
{
    private double price = 0;
    private double compare(Firework f) 
    {
        return price - f.price;
    }
}