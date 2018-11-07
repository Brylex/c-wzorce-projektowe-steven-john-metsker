using System;

/// <summary>
/// Klasa demonstracyjna z rozdzia³u Observer. Zadaniem klasy jest
/// sk³adowanie w³aœciwoœci czasu szczytowego obserwowanej przez GUI.
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