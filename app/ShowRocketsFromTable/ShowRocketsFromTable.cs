using System.Windows.Forms;
using DataLayer;
using UserInterface;

/// <summary>
/// Pokazuje efekt wczytania rakiet z bazy do obiektu DataGrid.
/// </summary>
public class ShowRocketsFromTable : Form
{
    public ShowRocketsFromTable()
    {  
        DataGrid g = UI.NORMAL.CreateGrid();
        g.DataSource = DataServices.CreateTable(
            "SELECT Name, Apogee, Price, Thrust FROM Rocket");
        Controls.Add(g);  
   
        Text = "Poka¿ fasadê"; 
        Font = UI.NORMAL.Font;
    } 

    public static void Main()
    {
        Application.Run(new ShowRocketsFromTable());
    }
}