using System;
using System.Drawing;  
using System.Windows.Forms;
using Functions;
namespace UserInterface
{
    /// <summary>
    /// Klasa wy�wietla par� funkcji na panelu. S� to funkcje x i y,
    /// parametryzowane przez czas t. Podczas nanoszenia wykresu na panel,
    /// czas przebiega od 0 do 1.
    /// </summary>
    public class PlotPanel : Panel 
    {
        private int _nPoint;
        private Point[] points;
        private Function _xFunc;
        private Function _yFunc;
        /// <summary>
        /// Nanosi wykres funkcji y wzgl�dem czasu (przebiegaj�cego od 0 do 1).
        /// </summary>
        /// <param name="nPoint">liczba nanoszonych punkt�w</param>
        /// <param name="yFunc">funkcja y</param>
        public PlotPanel (int nPoint, Function yFunc) : 
            this (nPoint, new Function(T), yFunc)
        {
        }
        /// <summary>
        /// Tworzy wykres wyliczony na podstawie dostarczonych funkcji x i y.
        /// S� to funkcje czasu, przebiegaj�cego od 0 do 1.
        /// </summary>
        /// <param name="nPoint">liczba nanoszonych punkt�w</param>
        /// <param name="xFunc">funkcja x</param>
        /// <param name="yFunc">funkcja y</param>
        public PlotPanel(int nPoint, Function xFunc, Function yFunc)
        {  
            _nPoint = nPoint;
            points = new Point[_nPoint];
            _xFunc = xFunc;
            _yFunc = yFunc;   
            BackColor = Color.White;
			Dock = DockStyle.Fill;
        }
        // Rysowanie wykres�w po��danych funkcji
        protected override void OnPaint(PaintEventArgs pea)
        {
            double w = Width - 1;
            double h = Height - 1;
            for (int i = 0; i < _nPoint; i++)
            {
                double t = ((double) i) / (_nPoint - 1);
                points[i].X = (int) (_xFunc(t) * w);
                points[i].Y = (int) (h * (1 - _yFunc(t)));
            }
            
            Pen p = new Pen(ForeColor);
            Graphics g = pea.Graphics;
            g.DrawLines(p, points); 
        }
        // Przerysowanie panelu w razie zmiany rozmiaru
        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);
            Refresh();
        }
        // domy�lnie warto�ciami osi x s� warto�ci t
        private static double T(double t)
        {
            return t;
        }
    }
}
