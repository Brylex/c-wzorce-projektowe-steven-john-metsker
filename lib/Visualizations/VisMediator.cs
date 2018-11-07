using System;
using System.Collections;
using System.Drawing;
using System.IO;
using System.Runtime.Serialization.Formatters.Soap; 
using System.Windows.Forms;

namespace Visualizations
{
    /// <summary>
    /// Klasa obs�uguj�ca zdarzenia interfejsu u�ytkownika z klasy Visualization
    /// </summary>
    public class VisMediator 
    {
        protected int initX;
        protected int initY;
        protected Point initLocation;
        protected bool isMouseDown = false;
         
        protected FactoryModel _factoryModel;

        /// <summary>
        /// Tworzy nowego mediatora dla symulacji korzystaj�cej ze wskazanego
        /// modelu fabryki.
        /// </summary>
        /// <param name="m">model �ledz�cy lokalizacj� maszyn</param>
        public VisMediator(FactoryModel m)
        {
            _factoryModel = m; 
        } 

        // U�ytkownik klikn�� "Dodaj"
        internal void Add(object sender, System.EventArgs e)
        {
            _factoryModel.AddMachine();
        }

        // U�ytkownik klikn�� "Cofnij"
        internal void Undo(object sender, System.EventArgs e)
        {
            _factoryModel.Pop();
        }

        // Klikni�cie na ikonie maszyny
        internal void MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left) 
            { 
                PictureBox pb = (PictureBox) sender;
                initLocation = pb.Location;
                initX = Control.MousePosition.X;
                initY = Control.MousePosition.Y;             
                isMouseDown = true;
            }    
        }

        // Przesuni�cie myszy podczas klikni�cia na ikonie maszyny
        internal void MouseMove(object sender, MouseEventArgs e)
        {
            if (isMouseDown) 
            {
             
                PictureBox pb = (PictureBox) sender;
                pb.Location = new Point(initLocation.X + Control.MousePosition.X - initX,
                    initLocation.Y + Control.MousePosition.Y - initY);
            }
        }

        // U�ytkownik upu�ci� ikon� maszyny. Powiadomienie modelu o zmianie
        internal void MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left) 
            {
                isMouseDown = false;
                PictureBox pb = (PictureBox) sender;
                _factoryModel.Drag(initLocation, pb.Location); 
            }
        }

        // U�ytkownik klikn�� pozycj� menu "Zapisz jako..."
        internal void Save(object sender, System.EventArgs e)
        {
            SaveFileDialog d = new SaveFileDialog();
            if (d.ShowDialog() == DialogResult.OK)
            {   
                using (FileStream fs = File.Create(d.FileName))
                {
                    new SoapFormatter().Serialize(fs, _factoryModel.Locations);
                }             
            }
        }

        // U�ytkownik klikn�� pozycj� menu "Przywr�� z..."
        internal void Restore(object sender, System.EventArgs e)
        {
            OpenFileDialog d = new OpenFileDialog();
            if (d.ShowDialog() == DialogResult.OK)
            {
                using (FileStream fs = File.Open(d.FileName, FileMode.Open))
                {
                    IList list = (IList)(new SoapFormatter().Deserialize(fs));    
                    _factoryModel.Push(list);             
                } 
            }
        }
    }
}