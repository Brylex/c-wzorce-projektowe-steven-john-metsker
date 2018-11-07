using System;
using System.Windows.Forms;
using Functions;
using UserInterface;

/// <summary>
/// Przyk�ad z rozdzia�u Decorator. Klasa pokazuj�ca, �e mo�na stworzy�
/// z�o�on� now� funkcj� w czasie wykonania.
/// </summary>
public class ShowBrightness
{
    /// <summary>
    /// Punkt wej�cia aplikacji.
    /// </summary>
    public static void Main()
    {
        Frapper brightness =
            new Arithmetic(
            '*',
            new Exp(
                 new Arithmetic(
                      '*', new Constant(-4), new T())),
            new Sin(
                 new Arithmetic(
                      '*', new Constant(Math.PI), new T())));
           
        PlotPanel2 p = new PlotPanel2(100, new T(), brightness); 
		Panel p2 = UI.NORMAL.CreatePaddedPanel(p);
        GroupBox gb = UI.NORMAL.CreateGroupBox("Jasno�� i ca�kowity czas spalania", p2); 
        gb.Font = UI.NORMAL.Font;
        Form f = new Form();
        f.DockPadding.All = 10;
        f.Text = "Jasno��";  
        f.Controls.Add(gb);  
        Application.Run(f);
    } 
}