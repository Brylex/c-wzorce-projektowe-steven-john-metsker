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
    /// Narzêdzia do tworzenia interfejsu u¿ytkownika.
    /// </summary>
    public class UI
    {
        protected Font _font = new Font("Book Antiqua", 18F);
        public static readonly int STANDARD_PAD = 10;
        public static readonly UI NORMAL = new UI();
        /// <summary>
        /// Ustawia standardow¹ czcionkê, któr¹ klasy potomne mog¹ przes³aniaæ.
        /// </summary>
        public virtual Font Font
        {
            get
            {
                return _font;
            }
        }
        /// <summary>
        /// Ustawia standardowy odstêp, który klasy potomne mog¹ przes³aniaæ.
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
		/// Tworzy panel dodaj¹cy standardowy odstêp wokó³ kontrolek w nim 
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
		/// Tworzy panel dodaj¹cy standardowy odstêp wokó³ przekazanej kontrolki.
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
        /// Tworzy ramkê grupuj¹c¹ umieszczaj¹c¹ ramkê z tytu³em wokó³
        /// wskazanego komponentu.
        /// </summary>
        /// <param name="title">Tekst wyœwietlany w tytule ramki</param>
        /// <param name="control">Obramowana kontrolka</param>
        /// <returns>ramkê grupuj¹c¹ z tytu³em, umieszczon¹ wokó³ dostarczonej
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
        /// Tworzy standardowy panel kreœl¹cy y jako funkcjê czasu t.
        /// </summary>
        /// <param name="nPoint">Liczba nanoszonych punktów</param>
        /// <param name="yFunc">Funkcja y</param>
        /// <returns>panel wykresu</returns>
        public virtual PlotPanel CreatePlotPanel(int nPoint, Function yFunc)
        {
            PlotPanel pp = new PlotPanel(nPoint, yFunc);
            pp.BackColor = Color.White;
            return pp;
        }  
        /// <summary>
        /// Tworzy standardowy panel kreœl¹cy x i y jako parametryczne 
        /// funkcje czasu t.
        /// </summary>
        /// <param name="nPoint">Liczba nanoszonych punktów</param>
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
        /// Tworzy standardow¹ siatkê do wyœwietlania danych, przede
        /// wszystkim pobranych z tabel bazy.
        /// </summary>
        /// <returns>standardow¹ siatkê danych</returns>
        public virtual DataGrid CreateGrid()
        {			
            DataGrid g = new DataGrid();
            g.Dock = DockStyle.Fill;
            g.CaptionVisible = false;
            return g;
        }
        /// <summary>
        /// Tworzy standardow¹ listê, której ka¿demu elementowi towarzyszy
        /// ikona.
        /// </summary>
        /// <param name="size">rozmiar ikon</param>
        /// <param name="images">obrazy ikon</param>
        /// <returns>standardow¹ listê</returns>
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
        // Tworzy listê obrazów na podstawie przekazanych obrazów i ich 
        // po¿¹danych rozmiarów.
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
        /// Metoda wyszukuj¹ca wskazany plik graficzny i zwracaj¹ca jego 
        /// zawartoœæ. Metoda szuka wszystkich obrazów w podkatalogu images
        /// katalogu, w którym znajduje siê ta jednostka kompilacji.
        /// </summary>
        /// <param name="imageName">nazwa pliku graficznego</param>
        /// <returns>obraz</returns>
        public static Image GetImage(String imageName) 
        {
            return Image.FromFile(FileFinder.GetFileName("images", imageName));
        }
    }
}
