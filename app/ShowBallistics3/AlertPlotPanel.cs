using System;
using Functions;
using UserInterface;

/// <summary>
/// Klasa dziedzicząca z PlotPanel, nasłuchująca zdarzeń Change zgłaszanych
/// przez obiekt ValueHolder.
/// </summary>
public class AlertPlotPanel : PlotPanel
{
    /// <summary>
    /// Tworzy nasłuchujący zmian panel wykresu.
    /// </summary>
    /// <param name="nPoint">ilość nanoszonych punktów</param>
    /// <param name="tf">nanoszona funkcja</param>
    public AlertPlotPanel(int nPoint, TpeakFunction tf, Tpeak tp) : 
        base (nPoint, new Function(tf.F))
    {
        tp.Change += new ChangeHandler(FunctionChange);
    }
    private void FunctionChange()
    {
        Refresh();
    }
}