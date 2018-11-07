using System;
using Functions;
using UserInterface;

/// <summary>
/// Klasa dziedzicz�ca z PlotPanel, nas�uchuj�ca zdarze� Change
/// pochodz�cych z obiektu TpeakFunction.
/// </summary>
public class AlertPlotPanel : PlotPanel
{
    /// <summary>
    /// Tworzy nas�uchuj�cy zmian panel wykresu.
    /// </summary>
    /// <param name="nPoint">ilo�� nanoszonych punkt�w</param>
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