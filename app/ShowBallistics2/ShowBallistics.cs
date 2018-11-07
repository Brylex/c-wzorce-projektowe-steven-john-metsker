using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using UserInterface;
using Functions;

/// <summary>
/// Klasa jest przyk�adem zastosowania wzorca Observer. Kod z projektu
/// ShowBallistics1 zosta� przekszta�cony tak, by zwolni� aplikacj� z obowi�zku
/// rejestrowania zdarze� Scroll i powiadamiania o nich wszystkich zainteresowanych
/// kontrolek. Przekszta�cenie polega na tym, �e funkcje tempa spalania i ci�gu 
/// �ledz� zmiany suwaka, a panele wykres�w �ledz� zmiany tych funkcji.
/// </summary>
public class ShowBallistics : Form
{
    private int INITIAL_WIDTH = 800;
    private int INITIAL_HEIGHT = 400;
    private int NPOINT = 101; // punkty do nanoszenia wykresu
    // panel sterowania, zawiera lewy panel sterowania i suwak
    private Panel _controlPanel;
    private TrackBar _slider;
    // lewy panel sterowania zawiera etykiet� i pole tekstowe
    private Panel _leftControlPanel;
    private Label _tPeakLabel;
    private TextBox _valueTextBox;
    // g�rny panel zawiera ramki tempa spalania i ci�gu (kt�re z kolei
    // zawieraj� panele)
    private Panel _upperPanel;
    private Panel _burnRatePanel;
    private GroupBox _burnRateBox;
    private Panel _thrustPanel;
    private GroupBox _thrustBox;
    /// <summary>
    /// Utworzenie instancji i inicjalizacja komponent�w GUI.
    /// </summary>
    public ShowBallistics()
    {            
        InitializeComponent();
    }
    private void InitializeComponent()
    {
        Font = UI.NORMAL.Font;
        Controls.Add(UpperPanel());
        Controls.Add(ControlPanel());

        ClientSize = new System.Drawing.Size(INITIAL_WIDTH, INITIAL_HEIGHT);
        Text = "Efekt tPeak(2)";
    }
    // panel zawieraj�cy dwa wykresy
    private Panel UpperPanel() 
    {
        if (_upperPanel == null) 
        {
            _upperPanel = new Panel();
            _upperPanel.Dock = DockStyle.Fill;
            _upperPanel.DockPadding.All = UI.NORMAL.Pad;
            _upperPanel.Controls.Add(ThrustBox());
            _upperPanel.Controls.Add(BurnRateBox());
        }
        return _upperPanel;
    }	 
    // ramka grupuj�ca zawieraj�ca panel tempa spalania i nadaj�ca mu tytu�
    private GroupBox BurnRateBox()
    {
        if(_burnRateBox == null) 
        {
            _burnRateBox = UI.NORMAL.CreateGroupBox(" Tempo spalania", BurnRatePanel());
            // Istotnym szczeg�em jest dokowanie do lewej (DockStyle.Left).
            // Na og� pierwsza kontrolka jest dokowana do lewej, potem 
            // opcjonalny separator, a potem druga kontrolka na pe�n� szeroko��.
            _burnRateBox.Dock = DockStyle.Left;
            _burnRateBox.Width = INITIAL_WIDTH / 2;
        }
        return _burnRateBox;
    }
    // panel wy�wietlaj�cy tempo spalania
    private Panel BurnRatePanel()
    {
        if (_burnRatePanel == null) 
        {
            _burnRatePanel = UI.NORMAL.CreatePaddedPanel(
                new AlertPlotPanel(NPOINT, new BurnRate(0, Slider())));
        }
        return _burnRatePanel;
    }
    private GroupBox ThrustBox()
    {
        if(_thrustBox == null) 
        {
            _thrustBox = UI.NORMAL.CreateGroupBox(" Ci�g", ThrustPanel());
            _thrustBox.Dock = DockStyle.Fill;
        }
        return _thrustBox;
    }
    private Panel ThrustPanel()
    {
        if (_thrustPanel == null) 
        {
            _thrustPanel = UI.NORMAL.CreatePaddedPanel(
                new AlertPlotPanel(NPOINT, new Thrust(0, Slider())));
        }
        return _thrustPanel;
    }
    private Panel ControlPanel() 
    {
        if (_controlPanel == null)
        {
            _controlPanel = new Panel();
            _controlPanel.Controls.Add(Slider());
            _controlPanel.Controls.Add(LeftControlPanel());
            _controlPanel.Dock = DockStyle.Bottom;
            _controlPanel.DockPadding.All = 10;
        }
        return _controlPanel;
    }
    private Panel LeftControlPanel()
    {
        if (_leftControlPanel == null) 
        {
            _leftControlPanel = new Panel();
            _leftControlPanel.Controls.Add(TpeakLabel());
            _leftControlPanel.Controls.Add(ValueTextBox());
            _leftControlPanel.Dock = DockStyle.Left;
            _leftControlPanel.DockPadding.All = 10;
        }
        return _leftControlPanel;
    }
    private Label TpeakLabel()
    {
        if (_tPeakLabel == null) 
        {
            _tPeakLabel = new Label(); 
            _tPeakLabel.Text = "tPeak";
            _tPeakLabel.TextAlign = ContentAlignment.TopLeft;
            _tPeakLabel.Dock = DockStyle.Left;
            _tPeakLabel.Width = Font.Height / 2 * 5;
        }
        return _tPeakLabel;
    }
    private TextBox ValueTextBox()
    {
        if (_valueTextBox == null)
        {
            _valueTextBox = new ValueTextBox(Slider()); 
            _valueTextBox.Dock = DockStyle.Right;
            _valueTextBox.TextAlign = HorizontalAlignment.Center;
            _valueTextBox.Text = "" + Slider().Minimum;
        }
        return _valueTextBox;
    }
    private TrackBar Slider() 
    {
        if (_slider == null)
        {
            _slider = new TrackBar();  
            _slider.Maximum = 100;
            _slider.Dock = DockStyle.Fill;
            _slider.TickFrequency = 5;
        }
        return _slider;
    }
    /// <summary>
    /// Punkt wej�cia aplikacji.
    /// </summary>
    static void Main() 
    {
        Application.Run(new ShowBallistics());
    }
    // Przerysowuje panel w razie zmiany rozmiaru.
    protected override void OnResize(EventArgs e)
    {
        base.OnResize(e);
        BurnRateBox().Width = Width / 2;
        Refresh();
    }
}