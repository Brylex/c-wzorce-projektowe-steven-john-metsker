using System;
using System.Drawing;
using System.IO;
using System.Reflection;
using System.Windows.Forms;
using Functions;
using Utilities;

namespace UserInterface
{
    /// <summary>
    /// Narz�dzia do tworzenia interfejsu u�ytkownika.
    /// </summary>
    public class UI
    {
        protected Font _font = new Font("Book Antiqua", 18F);
        public static readonly int STANDARD_PAD = 10;
        public static readonly UI NORMAL = new UI();
        /// <summary>
        /// Ustawia standardow� czcionk�, kt�r� klasy potomne mog� przes�ania�.
        /// </summary>
        public virtual Font Font
        {
            get
            {
                return _font;
            }
        }
        /// <summary>
        /// Ustawia standardowy odst�p, kt�ry klasy potomne mog� przes�ania�.
        /// </summary>
        public virtual int Pad
        {
            get
            {
                return STANDARD_PAD;
            }
        }
        /// <summary>
        /// Tworzy standardowy przycisk potwierdzenia.
        /// </summary>
        /// <returns>standardowy przycisk potwierdzenia</returns>
        public virtual Button CreateButtonOk()
        {
            Button b = CreateButton();
            b.Image = GetImage("rocket-large.gif");
            b.Text = "OK!";
            return b;
        }
        /// <summary>
        /// Tworzy standardowy przycisk anulowania.
        /// </summary>
        /// <returns>standardowy przycisk anulowania</returns>
        public virtual Button CreateButtonCancel()
        {
            Button b = CreateButton();
            b.Image = GetImage("rocket-large-down.gif");
            b.Text = "Anuluj!";
            return b;
        }
        
        /// <summary>
        /// Tworzy standardowy przycisk.
        /// </summary>
        /// <returns>standardowy przycisk</returns>
        public virtual Button CreateButton()
        {
            Button b = new Button();
            b.Size = new Size(128, 128);
            b.ImageAlign = ContentAlignment.TopCenter;
            b.Font = Font;
            b.TextAlign = ContentAlignment.BottomCenter;
            return b;
        }
		/// <summary>
		/// Tworzy panel dodaj�cy standardowy odst�p wok� kontrolek w nim 
		/// umieszczanych.
		/// </summary>
		/// <returns>panel</returns>
		public virtual Panel CreatePaddedPanel()
		{
			Panel p = new Panel();
			p.Dock = DockStyle.Fill;
			p.DockPadding.All = Pad;
			return p;
		} 
		/// <summary>
		/// Tworzy panel dodaj�cy standardowy odst�p wok� przekazanej kontrolki.
		/// </summary>
		/// <param name="c">the control</param>
		/// <returns>the panel</returns>
		public virtual Panel CreatePaddedPanel(Control c)
		{
			Panel p = CreatePaddedPanel(); 
			p.Controls.Add(c);
			return p;
		}  
        /// <summary>
        /// Tworzy ramk� grupuj�c� umieszczaj�c� ramk� z tytu�em wok�
        /// wskazanego komponentu.
        /// </summary>
        /// <param name="title">Tekst wy�wietlany w tytule ramki</param>
        /// <param name="control">Obramowana kontrolka</param>
        /// <returns>ramk� grupuj�c� z tytu�em, umieszczon� wok� dostarczonej
        /// kontrolki</returns>
        public virtual GroupBox CreateGroupBox(
            String title, Control control)
        {
            GroupBox gb = new GroupBox();
            gb.Text = title;
			gb.Dock = DockStyle.Fill;
            gb.Controls.Add(control);
            return gb;
        }        
        /// <summary>
        /// Tworzy standardowy panel kre�l�cy y jako funkcj� czasu t.
        /// </summary>
        /// <param name="nPoint">Liczba nanoszonych punkt�w</param>
        /// <param name="yFunc">Funkcja y</param>
        /// <returns>panel wykresu</returns>
        public virtual PlotPanel CreatePlotPanel(int nPoint, Function yFunc)
        {
            PlotPanel pp = new PlotPanel(nPoint, yFunc);
            pp.BackColor = Color.White;
            return pp;
        }  
        /// <summary>
        /// Tworzy standardowy panel kre�l�cy x i y jako parametryczne 
        /// funkcje czasu t.
        /// </summary>
        /// <param name="nPoint">Liczba nanoszonych punkt�w</param>
        /// <param name="xFunc">Funkcja x</param>
        /// <param name="yFunc">Funkcja y</param>
        /// <returns>panel wykresu</returns>
        public virtual PlotPanel CreatePlotPanel(int nPoint, Function xFunc, Function yFunc)
        {
            PlotPanel pp = new PlotPanel(nPoint, xFunc, yFunc);
            pp.BackColor = Color.White;
            return pp;
        }  
        /// <summary>
        /// Tworzy standardow� siatk� do wy�wietlania danych, przede
        /// wszystkim pobranych z tabel bazy.
        /// </summary>
        /// <returns>standardow� siatk� danych</returns>
        public virtual DataGrid CreateGrid()
        {			
            DataGrid g = new DataGrid();
            g.Dock = DockStyle.Fill;
            g.CaptionVisible = false;
            return g;
        }
        /// <summary>
        /// Tworzy standardow� list�, kt�rej ka�demu elementowi towarzyszy
        /// ikona.
        /// </summary>
        /// <param name="size">rozmiar ikon</param>
        /// <param name="images">obrazy ikon</param>
        /// <returns>standardow� list�</returns>
        public virtual ListView CreateListView(Size size, params Image[] images)
        {
            ListView lv = new ListView();
            lv.Font = Font;
            lv.View = View.Details;
            lv.Columns.Add(new ColumnHeader());
            lv.Columns[0].Width = -2; // autosize
            lv.HeaderStyle = ColumnHeaderStyle.None;
            lv.SmallImageList = CreateImageList(size, images);
            return lv;
        }
        // Tworzy list� obraz�w na podstawie przekazanych obraz�w i ich 
        // po��danych rozmiar�w.
        protected virtual ImageList CreateImageList (Size size, params Image[] images) 
        { 
            ImageList il = new ImageList();
            il.ColorDepth = ColorDepth.Depth32Bit;
            il.ImageSize = size;
            foreach (Image i in images) 
            {
                il.Images.Add(i);
            }
            return il; 
        } 
        /// <summary>
        /// Metoda wyszukuj�ca wskazany plik graficzny i zwracaj�ca jego 
        /// zawarto��. Metoda szuka wszystkich obraz�w w podkatalogu images
        /// katalogu, w kt�rym znajduje si� ta jednostka kompilacji.
        /// </summary>
        /// <param name="imageName">nazwa pliku graficznego</param>
        /// <returns>obraz</returns>
        public static Image GetImage(String imageName) 
        {
            return Image.FromFile(FileFinder.GetFileName("images", imageName));
        }
    }
}
