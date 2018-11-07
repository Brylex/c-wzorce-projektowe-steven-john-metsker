using System.Windows.Forms;
using System.Data;
using System.Data.OleDb;
using DataLayer;
using UserInterface;
/// <summary>
/// Wype³nia obiekt DataGrid danymi pobranymi za poœrednictwem
/// adaptera OleDbDataAdapter.
/// </summary>
public class ShowAdapter : Form
{
    public ShowAdapter() 
    {       
        DataSet d = new DataSet();

        string s = "SELECT * FROM Rocket";
        OleDbDataAdapter a = DataServices.CreateAdapter(s);
        a.Fill(d, "Rocket");
        a.Dispose();
            
        DataGrid g = UI.NORMAL.CreateGrid();
        g.SetDataBinding(d, "Rocket");
        Controls.Add(g); 

        Text = "Wszystkie moje rakiety";
        Font = UI.NORMAL.Font;
    }
    static void Main() 
    {
        Application.Run(new ShowAdapter());
    }
}