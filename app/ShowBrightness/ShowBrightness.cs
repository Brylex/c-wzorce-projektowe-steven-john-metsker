using System;
using System.Windows.Forms;
using Functions;
using UserInterface;

/// <summary>
/// Przyk³ad z rozdzia³u Decorator. Klasa pokazuj¹ca, ¿e mo¿na stworzyæ
/// z³o¿on¹ now¹ funkcjê w czasie wykonania.
/// </summary>
public class ShowBrightness
{
    /// <summary>
    /// Punkt wejœcia aplikacji.
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
        GroupBox gb = UI.NORMAL.CreateGroupBox("Jasnoœæ i ca³kowity czas spalania", p2); 
        gb.Font = UI.NORMAL.Font;
        Form f = new Form();
        f.DockPadding.All = 10;
        f.Text = "Jasnoœæ";  
        f.Controls.Add(gb);  
        Application.Run(f);
    } 
}