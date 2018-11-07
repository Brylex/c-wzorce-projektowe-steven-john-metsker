using System;
using System.Drawing;
using System.Windows.Forms;
using UserInterface;
/// <summary>	
/// Klasa demonstruj¹ca zastosowanie wzorca Proxy wraz z klas¹ 
/// PictureBoxProxy. Co istotne, tekst rozdzia³u Proxy przedstawia argumenty
/// przeciwko stosowaniu takiego podejœcia.
/// </summary>
public class ShowProxy : Form
{
    private Button _button;
    private Panel _buttonPanel;
    private UI _ui;
    private PictureBoxProxy _pictureProxy; 
    private static readonly String IMAGE_ABSENT = "absent.gif";
    private static readonly String IMAGE_FEST   = "fest.gif";
    /// <summary>
    /// Dodanie kontrolek do aplikacji.
    /// </summary>
    public ShowProxy(UI ui)
    {
        _ui = ui;
        Text = "Poka¿ poœrednika";
        Controls.Add(PictureBoxProxy());
        Controls.Add(ButtonPanel()); 
    }

    private Panel ButtonPanel()
    {
        if (_buttonPanel == null)
        {
            _buttonPanel = new Panel();
            _buttonPanel.Dock = DockStyle.Bottom;
            _buttonPanel.Controls.Add(Button());
        }
        return _buttonPanel;
    }
	 
    private Button Button ()
    {
        if (_button == null)
        {
            _button = _ui.CreateButtonOk();  
            _button.Dock = DockStyle.Right;
            _button.Text = "Test";
            _button.Click += new System.EventHandler(LoadImage);
        }
        return _button;
    }
    private PictureBoxProxy PictureBoxProxy ()
    {
        if (_pictureProxy == null) 
        {
            PictureBox under = new PictureBox();
            under.Image = UI.GetImage(IMAGE_ABSENT);
            _pictureProxy = new PictureBoxProxy(under, IMAGE_FEST);
            _pictureProxy.Dock = DockStyle.Fill;
        }
        return _pictureProxy;
    } 

    /// <summary>
    /// Punkt wejœcia aplikacji.
    /// </summary>
    static void Main() 
    {
        Application.Run(new ShowProxy(UI.NORMAL));
    }

    // Klikniêcie przycisku powoduje za³adowanie nowego, du¿ego obrazu
    // i odpowiednie dostosowanie obszaru aplikacji.
    private void LoadImage(object sender, System.EventArgs e)
    {
        _pictureProxy.Load();
        int w = _pictureProxy.Image.Width;
        int h = _pictureProxy.Image.Height;
        ClientSize = new Size(w, h + _button.Height);
        _button.Enabled = false;
        Refresh();
    }
}