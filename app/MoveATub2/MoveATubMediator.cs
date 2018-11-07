using System;
using System.Windows.Forms;
using System.Drawing;

   /// <summary>
    /// Klasa obs³uguje dzia³ania obiektu aplikacji MoveATub.
    /// </summary>
public class MoveATubMediator
{
    private MoveATub2 _gui;
    private String _selectedMachineName;
    private String _selectedTubName;
    /// <summary>
    /// Tworzy mediatora dla danej aplikacji MoveATub.
    /// </summary>
    /// <param name="gui">obiekt aplikacji</param>
    public MoveATubMediator(MoveATub2 gui)
    {
        _gui = gui;
    }
    /// <summary>
    /// Najechanie kursorem myszy na kontrolkê wywo³uj¹c¹ powoduje
    /// usuniêcie pogrubienia tekstów ramek, a pogrubienie tekstu ramki
    /// wywo³uj¹cej. Zawartoœæ listy pojemników zmienia siê tak, by
    /// pokazywaæ pojemniki aktualnie znajduj¹ce siê przy maszynie, której
    /// odpowiada najechana ramka.
    /// </summary>
    /// <param name="sender">najechana kursorem ramka grupuj¹ca</param>
    /// <param name="e">ignorowany</param>
    internal void HoverBox(object sender, EventArgs e)
    {
        foreach (Control x in _gui.Boxes()) 
        {
            if (x.Font.Bold) 
            {
                x.Font = new Font(x.Font, FontStyle.Regular);
            }
        }
        Control c = (Control)sender;
        c.Font = new Font(c.Font, c.Font.Style | FontStyle.Bold);

        UpdateTubList(c.Text);
    }
    // aktualizacja listy pojemników dla wskazanej maszyny
    private void UpdateTubList(string machineName)
    {
        _gui.TubList().Items.Clear();
        foreach (string s in NameBase.TubNames(machineName)) 
        {
            _gui.TubList().Items.Add(new ListViewItem(s, 0));
        } 
    }
    /// <summary>
    /// Przesuniêcie wybranego pojemnika do wybranej maszyny.
    /// </summary>
    /// <param name="sender">ignorowany, ale raczej bêdzie to przycisk przypisania</param>
    /// <param name="e">ignorowany</param>
    internal void AssignClick(object sender, EventArgs e)
    {
        if (_selectedMachineName == null || _selectedTubName == null) return;
        string fromMachineName = (string) NameBase.TubMachine()[_selectedTubName];
        NameBase.TubMachine()[_selectedTubName] = _selectedMachineName;
        UpdateTubList(fromMachineName);
        _gui.AssignButton().Enabled = false;
    }
    /// <summary>
    /// W³¹czenie przycisku przypisania w momencie, gdy u¿ytkownik wybierze
    /// pojemnik lub maszynê i na obu listach zaznaczony jest element.
    /// </summary>
    /// <param name="sender">ignorowany</param>
    /// <param name="e">ignorowany</param>
    internal void SelectChanged(object sender, EventArgs e)
    { 
        ListView lv = (ListView) sender;
        ListView.SelectedListViewItemCollection c = lv.SelectedItems;
     
        foreach (ListViewItem i in lv.Items)
        {  
            if (c.Contains(i)) 
            {
                i.BackColor = SystemColors.Highlight;
                i.ForeColor = SystemColors.HighlightText;
                if (sender.Equals(_gui.MachineList())) _selectedMachineName = i.Text;
                if (sender.Equals(_gui.TubList())) _selectedTubName = i.Text;
            }
            else
            {
                i.BackColor = Color.Empty; 
                i.ForeColor = Color.Empty;
            }
        }
        _gui.AssignButton().Enabled = 
            _gui.MachineList().SelectedItems.Count > 0 && 
            _gui.TubList().SelectedItems.Count > 0;
    }
}