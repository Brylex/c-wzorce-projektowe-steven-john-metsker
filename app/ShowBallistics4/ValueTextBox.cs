using System;
using System.Windows.Forms;

/// <summary>
/// Pole tekstowe śledzące i wyświetlające wartość z obiektu ValueHolder.
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