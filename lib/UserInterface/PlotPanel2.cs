using System;
using System.Drawing;  
using System.Windows.Forms;
using Functions;
namespace UserInterface
{
    /// <summary>
    /// Klasa wyœwietla parê funkcji na panelu. S¹ to funkcje x i y,
    /// parametryzowane przez czas t. Podczas nanoszenia wykresu na panel,
    /// czas przebiega od 0 do 1.
    /// </summary>
    public class PlotPanel2 : Panel 
    {
        private int _nPoint;
        private Point[] points;
        private Frapper _x;
        private Frapper _y;
        
        double minx, miny, maxx, maxy;
        double aspectRatio;
        double left, bottom, right, top;

        /// <summary>
        /// Tworzy wykres wyliczony na podstawie dostarczonych funkcji x i y.
        /// S¹ to funkcje czasu, przebiegaj¹cego od 0 do 1.
        /// </summary>
        /// <param name="nPoint">liczba nanoszonych punktów</param>
        /// <param name="xFunc">funkcja x</param>
        /// <param name="yFunc">funkcja y</param>
        public PlotPanel2(int nPoint, Frapper x, Frapper y)
        {  
            _nPoint = nPoint;
            points = new Point[_nPoint];
            _x = x;
            _y = y;   
            BackColor = Color.White;
            Dock = DockStyle.Fill;
            FindExtrema();
            FindAspectRatio();
        }
        /// <summary>
        /// Znajduje ekstrema dostarczonych funkcji.
        /// </summary>
        protected void FindExtrema()
        {
            minx = maxx = _x.F(0);
            miny = maxy = _y.F(0);
            for (int i = 0; i < _nPoint; i++) 
            {
                double t = ((double) i) / (_nPoint - 1);
                double x = _x.F(t);
                double y = _y.F(t);

                minx = Math.Min(minx, x);
                miny = Math.Min(miny, y);
                maxx = Math.Max(maxx, x);
                maxy = Math.Max(maxy, y);
            }
        }
        /// <summary>
        /// Znajduje proporcje szerokoœci i wysokoœci wykresu.
        /// </summary>
        protected void FindAspectRatio()
        {   
            double numer = maxx - miny;
            double denom = maxy - miny;
            if (numer == 0 || denom == 0) 
            {
                aspectRatio = 1;
            } 
            else 
            {
                aspectRatio = numer / denom;
            }
        }
        // Rysowanie wykresów po¿¹danych funkcji
        protected override void OnPaint(PaintEventArgs pea)
        {
            SetCanvasArea();
            Scale sx = new Scale(minx, _x, maxx, left, right);
            Scale sy = new Scale(miny, _y, maxy, bottom, top);

            for (int i = 0; i < _nPoint; i++)
            {
                double t = ((double) i) / (_nPoint - 1);
                points[i].X = (int) sx.F(t);
                points[i].Y = (int) sy.F(t);
            }
            
            Pen pen = new Pen(ForeColor);
            Graphics g = pea.Graphics;
            g.DrawLines(pen, points); 
        }
        /// <summary>
        /// Ustawienie rozmiarów panelu rysowania na najwiêksz¹ mo¿liw¹
        /// powierzchniê odpowiadaj¹c¹ proporcjom wykresu.
        /// </summary>
        protected void SetCanvasArea()
        {
            double w = Width - 1;
            double h = Height - 1;

            /* Mo¿emy narysowaæ wykres korzystaj¹c z pe³nej szerokoœci lub 
             * wysokoœci panelu, wyliczaj¹c drugi wymiar. Na pocz¹tek przyjmiemy
             * rysowanie wykresu dla pe³nej szerokoœci. Jeœli oka¿e siê za 
             * wysoki, przejdziemy na pe³n¹ wysokoœæ.
             */
            double thickness = w;
            double tallness = thickness / aspectRatio;
            if (tallness > h) // niedobrze, za wysoko
            {
                tallness = h;
                thickness = tallness * aspectRatio;
            }
         
            left   = w / 2 - thickness / 2;
            bottom = h / 2 + tallness / 2;
            right  = w / 2 + thickness / 2;
            top    = h / 2 - tallness / 2;
        }
        // Przerysowanie panelu w razie zmiany rozmiaru.
        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);
            Refresh();
        }
    }
}
