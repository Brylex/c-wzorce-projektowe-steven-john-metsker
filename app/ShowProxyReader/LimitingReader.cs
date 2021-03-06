using System;
using System.Data;
using DataLayer;

/// <summary>
/// Demonstracja przechwycenia żądania do obiektu czytającego dane.
/// </summary>
public class LimitingReader : DataReaderProxy
{
    /// <summary>
    /// Przechwycenie obiektu
    /// </summary>
    /// <param name="subject">zastępowany przez pośrednika obiekt czytający</param>
    public LimitingReader(IDataReader subject) : base (subject)
    {
    }
    /// <summary>
    /// Pokazuje przykładowe przechwycenie żądania danych o apogeum rakiety.
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