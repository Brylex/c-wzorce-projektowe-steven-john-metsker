using System; 
using System.Windows.Forms;
using DataLayer;
using Fireworks;
using UserInterface;

/// <summary>
/// Pokazuje efekt wczytania listy rakiet do obiektu DataGrid.
/// </summary>
public class ShowRocketsFromList : Form
{

    public ShowRocketsFromList()
    {
        DataGrid g = UI.NORMAL.CreateGrid();
        Controls.Add(g);     
        g.DataSource = DataServices.FindAll(typeof(Rocket));     
        Font = UI.NORMAL.Font;
        Text = "Poka¿ rakiety";    
    } 
    public static void Main()
    {
        Application.Run(new ShowRocketsFromList());
    }
}