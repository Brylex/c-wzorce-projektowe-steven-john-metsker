using System;
using System.Data;
using DataLayer;

/// <summary>
/// Demonstracja przechwycenia ��dania do obiektu czytaj�cego dane.
/// </summary>
public class LimitingReader : DataReaderProxy
{
    /// <summary>
    /// Przechwycenie obiektu
    /// </summary>
    /// <param name="subject">zast�powany przez po�rednika obiekt czytaj�cy</param>
    public LimitingReader(IDataReader subject) : base (subject)
    {
    }
    /// <summary>
    /// Pokazuje przyk�adowe przechwycenie ��dania danych o apogeum rakiety.
    /// </summary>
    public override object this [string name]
    {
        get
        {
            if (String.Compare(name, "apogee", true) == 0)
            {
                return 0;
            }
            else 
            {
                return base [name];
            }
        }
    }
}