using System;

/// <summary>
/// Klasa demonstracyjna z rozdziału Observer. Zadaniem klasy jest
/// składowanie właściwości czasu szczytowego obserwowanej przez GUI.
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