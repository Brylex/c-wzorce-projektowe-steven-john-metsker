using System;
using System.Drawing;
using System.Windows.Forms;
using UserInterface;

namespace rubadub
{
    /// <summary>
    /// Wyœwietla aplikacjê wystêpuj¹c¹ jako mediator.
    /// </summary>
    public class PlaceATub : Form
    {
        private TextBox _textBox;
        private Panel _buttonPanel;
        private Button _button;
        private ListBox _listBox;

        /// <summary>
        /// Konstruktor tworz¹cy i uk³adaj¹cy GUI.
        /// </summary>
        public PlaceATub()
        {
            Font = UI.NORMAL.Font;
            Controls.Add(ListBox());
            Controls.Add(ButtonPanel());
            Controls.Add(TextBox());
            Text = "Ustaw pojemnik";
        }
        private TextBox TextBox()
        {
            if (_textBox == null) 
            {
                _textBox = new TextBox();
                _textBox.Dock = DockStyle.Top;
                _textBox.TabIndex = 1;
                _textBox.Text = "T230502";
            }
            return _textBox;
        }
        private ListBox ListBox() 
        {
            if (_listBox == null) 
            {
                _listBox = new ListBox();
                _listBox.Dock = DockStyle.Fill;
                _listBox.TabIndex = 2;
                _listBox.Items.AddRange(MachineList());
            }
            return _listBox;
        }
        private Panel ButtonPanel()
        {
            if (_buttonPanel == null) 
            {
                _buttonPanel = new Panel();
                _buttonPanel.Controls.Add(Button());
                _buttonPanel.Dock = DockStyle.Bottom;
                _buttonPanel.DockPadding.All = UI.NORMAL.Pad;
                _buttonPanel.Height = Font.Height * 2;
                _buttonPanel.TabIndex = 3;
            }
            return _buttonPanel;
        }
        private Button Button()
        {
            if (_button == null) 
            {
                _button = new Button();
                _button.Dock = DockStyle.Right;
                _button.TabIndex = 3;
                _button.Text = "Ok";
                _button.Click += new EventHandler(AssignTub);
            }
            return _button;
        }

        // Prawdziwa aplikacja dokona³aby aktualizacji stanu odpowiednich 
        // obiektów biznesowych i prawdopodobnie zapisa³aby zmiany w bazie
        // danych.
        private void AssignTub(object sender, EventArgs args)
        {
            Application.Exit();
        }
        /// <summary>
        /// Punkt wejœcia aplikacji.
        /// </summary>
        static void Main() 
        {
            Application.Run(new PlaceATub());
        }
        private static string[] MachineList()
        {
            return new string[]{
                "Mixer-2201",
                "Mixer-2202",
                "StarPress-2401",
                "StarPress-2402",
                "ShellAssembler-2301",
                "Fuser-2101"};
        }
    }
}
