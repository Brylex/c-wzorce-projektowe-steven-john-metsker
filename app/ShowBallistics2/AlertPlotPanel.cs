using System;
using Functions;
using UserInterface;

/// <summary>
/// Klasa dziedzicząca z PlotPanel, nasłuchująca zdarzeń Change
/// pochodzących z obiektu TpeakFunction.
/// </summary>
public class AlertPlotPanel : PlotPanel
{
    /// <summary>
    /// Tworzy nasłuchujący zmian panel wykresu.
    /// </summary>
    /// <param name="nPoint">ilość nanoszonych punktów</param>
    /// <param name="tf">nanoszona funkcja</param>
    public AlertPlotPanel(int nPoint, TpeakFunction tf) : 
        base (nPoint, new Function(tf.F))
    {
        tf.Change += new EventHandler(FunctionChange);
    }
    private void FunctionChange(object sender, EventArgs e)
    {
        Refresh();
    }
}