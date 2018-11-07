using System;
using System.Windows.Forms;
using Functions;
using UserInterface;
/// <summary>
/// Przekszta�cona wersja klasy ShowFlight zawiera jedynie niewielk� metod�
/// Main() oraz funkcje X i Y wsp�rz�dnych toru lotu niewypa�u.
/// </summary>
public class ShowFlight2
{
    private static double X(double t)
    {
        return t;
    }
    private static double Y(double t)
    {
        // y r�wne 0 dla t = 0, 1; y r�wne 1 dla t = 0.5
        return 4 * t * (1 - t);
    }
    /// <summary>
    /// Pokazuje tor lotu niewypa�u petardy powietrznej. 
    /// </summary>
    public static void Main()
    {
        PlotPanel p = new PlotPanel(
            101, new Function(X), new Function(Y)); 
        Panel p2 = UI.NORMAL.CreatePaddedPanel(p);
        GroupBox gb = 
            UI.NORMAL.CreateGroupBox("Tor lotu", p2); 
        Form f = new Form();
        f.DockPadding.All = 10; 
        f.Font = UI.NORMAL.Font;
        f.Text = "Tor lotu niewypa��w";  
        f.Controls.Add(gb);      

        Application.Run(f);
    } 
}