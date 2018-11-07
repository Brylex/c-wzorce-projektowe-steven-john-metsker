using System;
using System.Windows.Forms;

/// <summary>
/// Wersja klasy TpeakFunction zale¿na od obiektu ValueHolder zamiast suwaka.
/// </summary>
public abstract class TpeakFunction
{
    protected PropertyHolder _ph;
    /// <summary>
    /// Tworzy funkcjê zale¿n¹ od wartoœci szczytowej
    /// </summary>
    /// <param name="tPeak">pocz¹tkowa wartoœæ tPeak</param>
    public TpeakFunction(PropertyHolder ph)
    {
        _ph = ph;
    }
    public abstract double F(double t);
}
/// <summary>
/// Wersja klasy BurnRate zgodna z modelem MVC.
/// </summary>
public class BurnRate : TpeakFunction
{
    public BurnRate(PropertyHolder ph) : base(ph)
    {
    }
    /// <summary>
    /// Tempo spalania jako funkcja czasu.
    /// </summary>
    /// <param name="t">Czas (przebiega od 0 do 1 w miarê spalania paliwa)</param>
    /// <returns>Tempo spalania</returns>
    public override double F(double t) 
    {
        return F(t, (double) _ph.Value);
    }
    /// <summary>
    /// Tempo spalania jako funkcja czasu i tPeak.
    /// </summary>
    /// <param name="t">Czas</param>
    /// <param name="tPeak">tPeak (moment maksymalnej powierzchni spalania)</param>
    /// <returns>Tempo spalania</returns>
    public static double F(double t, double tPeak)
    {
        return .5 * Math.Pow(25, -Math.Pow((t - tPeak), 2));
    }
}
    /// <summary>
    /// Ci¹g rakiety jest wyra¿ony równaniem podanym w rozdziale Observer.
    /// </summary>
public class Thrust : TpeakFunction
{
    public Thrust(PropertyHolder ph) : base(ph)
    {
    }
    /// <summary>
    /// Ci¹g jako funkcja czasu.
    /// </summary>
    /// <param name="t">Czas (przebiega od 0 do 1 w miarê spalania paliwa)</param>
    /// <returns>Ci¹g</returns>
    public override double F(double t) 
    {
        return F(t, (double) _ph.Value);
    }
    /// <summary>
    /// Ci¹g jako funkcja czasu i tPeak.
    /// </summary>
    /// <param name="t">Czas</param>
    /// <param name="tPeak">tPeak (moment maksymalnej powierzchni spalania)</param>
    /// <returns>Thrust</returns>
    public static double F(double t, double tPeak) 
    {
        return 1.7 * Math.Pow((BurnRate.F(t, tPeak) / .6), (1 / .3));
    }
}