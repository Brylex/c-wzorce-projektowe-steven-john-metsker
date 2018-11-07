using System;
using System.Drawing;
using System.Windows.Forms;
using UserInterface;

/// <summary>
/// Wyœwietla przyk³ad zmiany wygl¹du i zachowania aplikacji poprzez
/// zmianê zestawu kontrolek GUI dla fabryki abstrakcji.
/// </summary>
public class BetaUI : UI
{        
    public BetaUI ()
    {
        Font f = Font;
        _font = new Font(f, f.Style ^ FontStyle.Italic);
    }
    /// <summary>
    /// Tworzy standardowy przycisk Ok! (potwierdzenia).
    /// </summary>
    /// <returns>standardowy przycisk Ok! (potwierdzenia)</returns>
    public override Button CreateButtonOk()
    {
        Button b = base.CreateButtonOk();
        b.Image = GetImage("cherry-large.gif");
        return b;
    }
    /// <summary>
    /// Tworzy standardowy przycisk Anuluj! (anulowania).
    /// </summary>
    /// <returns>standardowy przycisk Anuluj! (anulowania)</returns>
    public override Button CreateButtonCancel()
    {
        Button b = base.CreateButtonCancel();
        b.Image = GetImage("cherry-large-down.gif");
        return b;
    }
}