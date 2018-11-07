using System;
using Functions;
using UserInterface;

/// <summary>
/// Klasa dziedzicz¹ca z PlotPanel, nas³uchuj¹ca zdarzeñ Change zg³aszanych
/// przez obiekt ValueHolder.
/// </summary>
public class AlertPlotPanel : PlotPanel
{
    /// <summary>
    /// Tworzy nas³uchuj¹cy zmian panel wykresu.
    /// </summary>
    /// <param name="nPoint">iloœæ nanoszonych punktów</param>
    /// <param name="tf">nanoszona funkcja</param>
    public AlertPlotPanel(int nPoint, TpeakFunction tf, PropertyHolder ph) : 
        base (nPoint, new Function(tf.F))
    {
        ph.Change += new ChangeHandler(FunctionChange);
			
    }
    private void FunctionChange()
    {
        Refresh();
    }
}