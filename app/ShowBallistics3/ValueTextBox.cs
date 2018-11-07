using System;
using System.Windows.Forms;

/// <summary>
/// Pole tekstowe �ledz�ce i wy�wietlaj�ce warto�� obiektu Tpeak.
/// </summary>
public class ValueTextBox : TextBox
{
    private Tpeak _tPeak;
    public ValueTextBox(Tpeak valueHolder)
    {
        _tPeak = valueHolder;
        _tPeak.Change += new ChangeHandler(ValueChange);
    }
    private void ValueChange()
    {
        Text = _tPeak.Value.ToString();
    }
}