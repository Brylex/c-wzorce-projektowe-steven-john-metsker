using System;
using System.Windows.Forms;

/// <summary>
/// Pole tekstowe œledz¹ce i wyœwietlaj¹ce wartoœæ z obiektu ValueHolder.
/// </summary>
public class ValueTextBox : TextBox
{
    private PropertyHolder _ph;
    public ValueTextBox(PropertyHolder ph)
    {
        _ph = ph;
        _ph.Change += new ChangeHandler(PropertyChange);
    }
    private void PropertyChange()
    {
        Text = _ph.Value.ToString();
    }
}