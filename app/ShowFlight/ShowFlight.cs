using System;
using System.Drawing;  
using System.Windows.Forms;
using UserInterface;
/// <summary>
/// Klasa wy�wietla tor lotu niewypa�u, ale w obecnej postaci wymaga
/// przekszta�cenia. W trakcie przekszta�cania powinna zacz�� si� pojawia�
/// fasada do wy�wietlania kontrolek okna.
/// </summary>
public class ShowFlight : Panel 
{
    public ShowFlight()
    {  
        BackColor = Color.White;
        Dock = DockStyle.Fill;
    }
    /// <summary>
    /// Tworzy nowy panel dodaj�cy zatytu�owan� ramk� wok� panelu wyr�wnuj�cego,
    /// a nast�pnie dodaje ten ostatni wok� wskazanej kontrolki.
    /// </summary>
    /// <param name="title">Tekst wy�wietlany w tytule ramki</param>
    /// <param name="control">Kontrolka opakowywana w ramk�</param>
    /// <returns>Zatytu�owany panel ramki grupuj�cej umieszczony wok� wskazanej
    /// kontrolki</returns>
    public static GroupBox CreateGroupBox(String title, Control control)
    {
        GroupBox gb = new GroupBox();
        gb.Text = title;
        gb.Dock = DockStyle.Fill;
                
        Panel p = new Panel();
        p.Dock = DockStyle.Fill;
        p.DockPadding.All = 10;
        p.Controls.Add(control);

        gb.Controls.Add(p);
        return gb;
    }  
    // Rysuje parabol�. W ten metodzie, t przebiega od 0 do 1, a x od 0 do w
    // (szeroko�ci obszaru rysowania).
    // Warto�� y musi by� r�wna h w punktach t = 0 i t = 1, a r�wna 0 dla t = 0.5.
    protected override void OnPaint(PaintEventArgs pea)
    {
        int nPoint = 101;
        double w = Width - 1;
        double h = Height - 1;
        Point[] points = new Point[nPoint];
        for (int i = 0; i < nPoint; i++)
        {
            double t = ((double) i) / (nPoint - 1);
            points[i].X = (int) (t * w);
            points[i].Y = (int) (4 * h * (t - .5) * (t - .5));
        }            
        Pen p = new Pen(ForeColor);
        Graphics g = pea.Graphics;
        g.DrawLines(p, points); 
    }
    // Przerysowanie panelu w razie zmiany rozmiaru.
    protected override void OnResize(System.EventArgs e)
    {
        base.OnResize(e);
        Refresh();
    }
    /// <summary>
    /// Pokazuje tor lotu niewypa�u petardy powietrznej.
    /// </summary>
    public static void Main()
    {
        ShowFlight sf = new ShowFlight(); 
        GroupBox gb = CreateGroupBox("Tor lotu", sf);
        Form f = new Form();
        f.DockPadding.All = 10;
        f.Text = "Tor lotu niewypa��w";  
        f.Font = UI.NORMAL.Font;
        f.Controls.Add(gb);      

        Application.Run(f);
    } 
}