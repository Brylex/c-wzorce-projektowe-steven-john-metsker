using System;
using Functions;
using UserInterface;

/// <summary>
/// Klasa dziedzicz¹ca z PlotPanel, nas³uchuj¹ca zdarzeñ Change
/// pochodz¹cych z obiektu TpeakFunction.
/// </summary>
public class AlertPlotPanel : PlotPanel
{
    /// <summary>
    /// Tworzy nas³uchuj¹cy zmian panel wykresu.
    /// </summary>
    /// <param name="nPoint">iloœæ nanoszonych punktów</param>
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