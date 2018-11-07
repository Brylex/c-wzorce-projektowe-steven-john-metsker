using System;

/// <summary>
/// Klasa demonstracyjna z rozdzia�u Observer. Zadaniem klasy jest
/// sk�adowanie w�a�ciwo�ci czasu szczytowego obserwowanej przez GUI.
/// </summary>
class Engine
{
    private double _tPeak;
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
}