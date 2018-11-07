using System;
using System.Data;
using DataLayer;

/// <summary>
/// Demonstracja przechwycenia ¿¹dania do obiektu czytaj¹cego dane.
/// </summary>
public class LimitingReader : DataReaderProxy
{
    /// <summary>
    /// Przechwycenie obiektu
    /// </summary>
    /// <param name="subject">zastêpowany przez poœrednika obiekt czytaj¹cy</param>
    public LimitingReader(IDataReader subject) : base (subject)
    {
    }
    /// <summary>
    /// Pokazuje przyk³adowe przechwycenie ¿¹dania danych o apogeum rakiety.
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