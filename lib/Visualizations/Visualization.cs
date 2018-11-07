using System;
using System.Drawing;
using System.Windows.Forms;
using UserInterface;

namespace Visualizations
{
    /// <summary>
    /// Klasa obs�uguj�ca symulacj� fabryki, kt�ra zawiera maszyny
    /// przemieszczane materia�y. Obecnie zaimplementowana jest jedynie
    /// mo�liwo�� tworzenia i przesuwania maszyn. Dalsze mo�liwo�ci modelowania
    /// operacyjnego zostan� dodane w miar� przysz�ych potrzeb.
    /// </summary>
    public class Visualization : Form
    {
        protected UI _ui;
        protected Panel _machinePanel;
        protected Panel _buttonPanel;
        protected Button _addButton;
        protected Button _undoButton;         
        protected Image _image = UI.GetImage("machine.png"); 
        protected FactoryModel _factoryModel = new FactoryModel();
        protected VisMediator _mediator; 

        /// <summary>
        /// Tworzy now� symulacj� fabryki.
        /// </summary>
        public Visualization(UI ui)
        { 
            _ui = ui;
            _factoryModel.AddEvent += new AddHandler(HandleAdd);
            _factoryModel.DragEvent += new DragHandler(HandleDrag);
            _factoryModel.RebuildEvent += new RebuildHandler(HandleUndo);
            _mediator = new VisMediator(_factoryModel);
            Controls.Add(MachinePanel());
            Controls.Add(ButtonPanel());
            Text = "Operational Model";
        } 

        // panel do dodawania i przesuwania maszyn
        protected Panel MachinePanel()
        {
            if (_machinePanel == null)
            {
                _machinePanel = new Panel();
                _machinePanel.BackColor = Color.White;            
                _machinePanel.Dock = DockStyle.Fill;
            }
            return _machinePanel;
        }
	 
        // panel zawieraj�cy przyciski aplikacji
        protected Panel ButtonPanel()
        {
            if (_buttonPanel == null) 
            {
                _buttonPanel = new Panel();
                _buttonPanel.Controls.Add(AddButton());
                _buttonPanel.Controls.Add(UndoButton());
                _buttonPanel.Dock = DockStyle.Bottom;
                _buttonPanel.Height = (int)(AddButton().Height * 1.10);
            }
            return _buttonPanel;
        }

        // przycisk "Dodaj"
        protected Button AddButton()
        {
            if (_addButton == null)
            {
                _addButton = _ui.CreateButtonOk();
                _addButton.Dock = DockStyle.Left;
                _addButton.Text = "Dodaj";
                _addButton.Click += new System.EventHandler(_mediator.Add);
            }
            return _addButton;
        }

        // przycisk "Cofnij"
        protected Button UndoButton()
        {
            if (_undoButton == null)
            {
                _undoButton = _ui.CreateButtonCancel();
                _undoButton.Dock = DockStyle.Right;
                _undoButton.Text = "Cofnij";
                _undoButton.Click += new System.EventHandler(_mediator.Undo);
                _undoButton.Enabled = false;
            }
            return _undoButton;
        }


        // Dodaje now� maszyn� we wskazanym miejscu.
        protected void HandleAdd(Point p)
        {
            PictureBox pb = CreatePictureBox(p);
            MachinePanel().Controls.Add(pb);
            pb.BringToFront();
            UndoButton().Enabled = true;
        }

        // Przesuni�cie maszyny powoduje umieszczenie jej przed kontrolkami
        // w panelu maszyn i aktualizacj� pozycji maszyny
        protected void HandleDrag(Point oldP, Point newP)
        { 
            foreach (PictureBox pb in MachinePanel().Controls)
            {
                if (pb.Location.Equals(newP)) 
                {
                    pb.BringToFront();
                    return;
                } 
            }
        }

        // Gdy u�ytkownik kliknie przycisk Cofnij, odbudowujemy fabryk�
        // z zapami�tanego modelu.
        protected void HandleUndo()
        { 
            MachinePanel().Controls.Clear();      
            foreach (Point p in _factoryModel.Locations)
            {   
                MachinePanel().Controls.Add(CreatePictureBox(p));
            }       
            UndoButton().Enabled = _factoryModel.MementoCount > 1;
        }

        // Tworzy standardow� ikon� maszyny.
        protected PictureBox CreatePictureBox(Point p)
        { 
            PictureBox pb = new PictureBox();
            pb.Image = _image;
            pb.Size = _image.Size; 
            pb.MouseDown += new MouseEventHandler(_mediator.MouseDown); 
            pb.MouseMove += new MouseEventHandler(_mediator.MouseMove);
            pb.MouseUp   += new MouseEventHandler(_mediator.MouseUp);
            pb.Location = p; 
            return pb;
        }
    }
}