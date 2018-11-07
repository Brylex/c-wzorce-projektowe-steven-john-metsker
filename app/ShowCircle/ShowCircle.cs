using System;
using System.Drawing;  
using System.Windows.Forms;

    /// <summary>
    /// Pokazuje dzia�anie r�wna� parametrycznych rysuj�cych okr�g.
    /// </summary>
public class ShowCircle : Form
{
    // Rysuje okr�g (w miar� mo�liwo�ci).
    protected override void OnPaint(PaintEventArgs pea)
    {   
        int nPoint = 101;
        double w = ClientSize.Width - 1;
        double h = ClientSize.Height - 1;
        double r = Math.Min(w, h) / 2.0 - 10.0;
        Point[] points = new Point[nPoint];
        for (int i = 0; i < nPoint; i++) 
        {
            double t = ((double) i) / (nPoint - 1);
            double theta = Math.PI * 2.0 * t;
            points[i].X = (int) (w / 2 + r * Math.Cos(theta));
            points[i].Y = (int) (h / 2 - r * Math.Sin(theta));
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
    /// Punkt wej�cia aplikacji rysuj�cej okr�g.
    /// </summary>
    public static void Main()
    {
        Form f = new ShowCircle(); 
        f.ClientSize = new Size(500, 500);
        f.Text = "Okr�g za pomoc� r�wna� parametrycznych";
        Application.Run(f);
    }   
}