using System;

public delegate void ChangeHandler();
/// <summary>
/// Klasa u¿ywana przejœciowo w rodziale Observer w trakcie przechodzenia
/// na model MVC. Jest ona szybko przekszta³cana do klasy ValueHolder.
/// </summary>
public class Tpeak
{
    private double _value = 0;
    public event ChangeHandler Change;

    public double Value 
    {
        get 
        { 
            return _value; 
        }
        set
        {
            _value = value;
            if (Change != null) 
            {
                Change();
            }
        }
    }
}