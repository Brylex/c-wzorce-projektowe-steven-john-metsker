using System;
using Functions;
using UserInterface;

/// <summary>
/// Klasa dziedzicz�ca z PlotPanel, nas�uchuj�ca zdarze� Change zg�aszanych
/// przez obiekt ValueHolder.
/// </summary>
public class AlertPlotPanel : PlotPanel
{
    /// <summary>
    /// Tworzy nas�uchuj�cy zmian panel wykresu.
    /// </summary>
    /// <param name="nPoint">ilo�� nanoszonych punkt�w</param>
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