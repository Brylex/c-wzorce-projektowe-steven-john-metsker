using System;

   /// <summary>
    /// Klasa abstrakcyjna definiuj¹ca funkcjê zale¿n¹ nie tylko od czasu,
    /// ale równie¿ wartoœci tPeak, czyli momentu, w którym wystêpuje
    /// szczytowa powierzchnia spalania i tempo spalania paliwa sta³ego 
    /// dla rakiety.
    /// </summary>
public abstract class TpeakFunction
{
    private double _tPeak;

    /// <summary>
    /// Tworzy funkcjê zale¿n¹ od wartoœci tPeak.
    /// </summary>
    /// <param name="tPeak">wartoœæ pocz¹tkowa</param>
    public TpeakFunction(double tPeak)
    {
        Tpeak = tPeak;
    }
    /// <summary>
    /// Wartoœæ tPeak, czyli moment wystêpowania maksymalnej powierzchni
    /// i tempa spalania.
    /// </summary>
    public double Tpeak 
    {
        get 
        {
            return _tPeak;
        }
        set
        {
            _tPeak = value;
        }
    }
    /// <summary>
    /// Funkcja implementowana przez podklasy konkretne.
    /// </summary>
    /// <param name="t">parametr czasu</param>
    /// <returns>wartoœæ funkcji</returns>
    public abstract double F(double t);
}
    /// <summary>
    /// Tempo spalania paliwa rakiety jest wyra¿one równaniem chemicznym
    /// (z rozdzia³u Observer). Klasa stanowi równie¿ przyk³ad dostarczenia
    /// standardowej funkcji samego tylko czasu, choæ pierwotne równanie
    /// zale¿y te¿ od drugiego parametru tPeak. 
    /// Chcemy skorzystaæ z delegacji o nazwie Function, oczekuj¹cej funkcji
    /// o sygnaturze z jednym argumentem typu double. Jednak funkcja tempa
    /// spalania jest zale¿na od dwóch argumentów: czasu i wartoœci tPeak.
    /// Dlatego te¿ sk³adujemy tPeak jako zmienn¹ instancji, do której
    /// odwo³uje siê funkcja tempa spalania. Aplikacja "ShowBallistics"
    /// ilustruje sposób tworzenia instancji delegacji za pomoc¹ odwo³ania
    /// do obiektu.
    /// </summary>
public class BurnRate : TpeakFunction
{
    /// <summary>
    /// Tworzy obiekt tempa spalania.
    /// </summary>
    /// <param name="tPeak">wartoœæ pocz¹tkowa</param>
    public BurnRate(double tPeak) : base(tPeak)
    {
    }
    /// <summary>
    /// Tempo spalania jako funkcja czasu.
    /// </summary>
    /// <param name="t">Czas (przebiega od 0 do 1 w miarê spalania paliwa)</param>
    /// <returns>Tempo spalania</returns>
    public override double F(double t) 
    {
        return F(t, Tpeak);
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
    /// Ci¹g rakiety jest wyra¿ony równaniem chemicznym (z rozdzia³u
    /// Observer).
    /// </summary>
public class Thrust : TpeakFunction
{
    /// <summary>
    /// Tworzy obiekt ci¹gu.
    /// </summary>
    /// <param name="tPeak">wartoœæ pocz¹tkowa</param>
    public Thrust(double tPeak) : base(tPeak)
    {
    }
    /// <summary>
    /// Ci¹g jako funkcja czasu.
    /// </summary>
    /// <param name="t">Czas (przebiega od 0 do 1 w miarê spalania paliwa)</param>
    /// <returns>Ci¹g</returns>
    public override double F(double t) 
    {
        return F(t, Tpeak);
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