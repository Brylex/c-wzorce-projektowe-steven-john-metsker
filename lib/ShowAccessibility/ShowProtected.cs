/// <summary>
/// Klasa u�ywana w �wiczeniu na kontrol� dost�pu z rozdzia�u 7.
/// </summary>
public class Machine
{
    protected void Unload() {}
}
/// <summary>
/// Klasa u�ywana w �wiczeniu na kontrol� dost�pu z rozdzia�u 7.
/// </summary>
public class Hopper : Machine
{
    public void Show()
    {
        Hopper h = new Hopper();
        h.Unload();
        Machine m = new Machine();
        //m.Unload();
    }
}