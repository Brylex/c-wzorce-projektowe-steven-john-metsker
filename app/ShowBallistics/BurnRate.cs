using System;

   /// <summary>
    /// Klasa abstrakcyjna definiuj�ca funkcj� zale�n� nie tylko od czasu,
    /// ale r�wnie� warto�ci tPeak, czyli momentu, w kt�rym wyst�puje
    /// szczytowa powierzchnia spalania i tempo spalania paliwa sta�ego 
    /// dla rakiety.
    /// </summary>
public abstract class TpeakFunction
{
    private double _tPeak;

    /// <summary>
    /// Tworzy funkcj� zale�n� od warto�ci tPeak.
    /// </summary>
    /// <param name="tPeak">warto�� pocz�tkowa</param>
    public TpeakFunction(double tPeak)
    {
        Tpeak = tPeak;
    }
    /// <summary>
    /// Warto�� tPeak, czyli moment wyst�powania maksymalnej powierzchni
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
    /// <returns>warto�� funkcji</returns>
    public abstract double F(double t);
}
    /// <summary>
    /// Tempo spalania paliwa rakiety jest wyra�one r�wnaniem chemicznym
    /// (z rozdzia�u Observer). Klasa stanowi r�wnie� przyk�ad dostarczenia
    /// standardowej funkcji samego tylko czasu, cho� pierwotne r�wnanie
    /// zale�y te� od drugiego parametru tPeak. 
    /// Chcemy skorzysta� z delegacji o nazwie Function, oczekuj�cej funkcji
    /// o sygnaturze z jednym argumentem typu double. Jednak funkcja tempa
    /// spalania jest zale�na od dw�ch argument�w: czasu i warto�ci tPeak.
    /// Dlatego te� sk�adujemy tPeak jako zmienn� instancji, do kt�rej
    /// odwo�uje si� funkcja tempa spalania. Aplikacja "ShowBallistics"
    /// ilustruje spos�b tworzenia instancji delegacji za pomoc� odwo�ania
    /// do obiektu.
    /// </summary>
public class BurnRate : TpeakFunction
{
    /// <summary>
    /// Tworzy obiekt tempa spalania.
    /// </summary>
    /// <param name="tPeak">warto�� pocz�tkowa</param>
    public BurnRate(double tPeak) : base(tPeak)
    {
    }
    /// <summary>
    /// Tempo spalania jako funkcja czasu.
    /// </summary>
    /// <param name="t">Czas (przebiega od 0 do 1 w miar� spalania paliwa)</param>
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
    /// Ci�g rakiety jest wyra�ony r�wnaniem chemicznym (z rozdzia�u
    /// Observer).
    /// </summary>
public class Thrust : TpeakFunction
{
    /// <summary>
    /// Tworzy obiekt ci�gu.
    /// </summary>
    /// <param name="tPeak">warto�� pocz�tkowa</param>
    public Thrust(double tPeak) : base(tPeak)
    {
    }
    /// <summary>
    /// Ci�g jako funkcja czasu.
    /// </summary>
    /// <param name="t">Czas (przebiega od 0 do 1 w miar� spalania paliwa)</param>
    /// <returns>Ci�g</returns>
    public override double F(double t) 
    {
        return F(t, Tpeak);
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