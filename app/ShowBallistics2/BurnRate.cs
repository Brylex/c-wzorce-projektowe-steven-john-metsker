using System;
using System.Windows.Forms;

/// <summary>
/// Wersja klasy TpeakFunction �ledz�ca zmiany pozycji suwaka.
/// </summary>
public abstract class TpeakFunction
{
    private double _tPeak;
    private TrackBar _slider;
    public event EventHandler Change;

    /// <summary>
    /// Tworzy funkcj� aktualizuj�c� sw�j stan i powiadamiaj�c�
    /// zainteresowane obiekty o zmianach pozycji suwaka.
    /// </summary>
    /// <param name="tPeak">pocz�tkowa warto�� tPeak</param>
    /// <param name="slider">obserwowany suwak</param>
    public TpeakFunction(double tPeak, TrackBar slider)
    {
        Tpeak = tPeak;
        _slider = slider;
        slider.Scroll += new EventHandler(SliderScroll);
    }
    public double Tpeak 
    {
        get 
        {
            return _tPeak;
        }
        set
        {
            _tPeak = value;
            if (Change != null) 
            {
                Change(this, EventArgs.Empty);
            }
        }
    }
    private void SliderScroll(object sender, EventArgs e)
    {
        double val = _slider.Value;
        Tpeak = (val - _slider.Minimum) / (_slider.Maximum - _slider.Minimum);
    }
    public abstract double F(double t);
}
    /// <summary>
    /// Tempo spalania paliwa rakiety jest wyra�one r�wnaniem podanym
    /// w rozdziale Observer. Klasa stanowi r�wnie� przyk�ad dostarczenia
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
    public BurnRate(double tPeak, TrackBar slider) : base(tPeak, slider)
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
    /// Ci�g rakiety jest wyra�ony r�wnaniem podanym w rozdziale Observer.
    /// </summary>
public class Thrust : TpeakFunction
{
    public Thrust(double tPeak, TrackBar slider) : base(tPeak, slider)
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