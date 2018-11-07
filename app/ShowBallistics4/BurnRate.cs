using System;
using System.Windows.Forms;

/// <summary>
/// Wersja klasy TpeakFunction zale�na od obiektu ValueHolder zamiast suwaka.
/// </summary>
public abstract class TpeakFunction
{
    protected PropertyHolder _ph;
    /// <summary>
    /// Tworzy funkcj� zale�n� od warto�ci szczytowej
    /// </summary>
    /// <param name="tPeak">pocz�tkowa warto�� tPeak</param>
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
    /// <param name="t">Czas (przebiega od 0 do 1 w miar� spalania paliwa)</param>
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
    /// Ci�g rakiety jest wyra�ony r�wnaniem podanym w rozdziale Observer.
    /// </summary>
public class Thrust : TpeakFunction
{
    public Thrust(PropertyHolder ph) : base(ph)
    {
    }
    /// <summary>
    /// Ci�g jako funkcja czasu.
    /// </summary>
    /// <param name="t">Czas (przebiega od 0 do 1 w miar� spalania paliwa)</param>
    /// <returns>Ci�g</returns>
    public override double F(double t) 
    {
        return F(t, (double) _ph.Value);
    }
    /// <summary>
    /// Ci�g jako funkcja czasu i tPeak.
    /// </summary>
    /// <param name="t">Czas</param>
    /// <param name="tPeak">tPeak (moment maksymalnej powierzchni spalania)</param>
    /// <returns>Thrust</returns>
    public static double F(double t, double tPeak) 
    {
        return 1.7 * Math.Pow((BurnRate.F(t, tPeak) / .6), (1 / .3));
    }
}