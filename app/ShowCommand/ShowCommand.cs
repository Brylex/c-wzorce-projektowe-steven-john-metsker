using System;
using System.Windows.Forms;

/// <summary>
/// Pokazuje jak u³o¿yæ menu i zastosowaæ wzorzec Command.
/// </summary>
public class ShowCommand : Form
{
    public ShowCommand()
    {
        MenuItem exitItem = new MenuItem();
        exitItem.Text = "Wyjœcie";
        exitItem.Click += new EventHandler(ExitApp);

        MenuItem fileItem = new MenuItem();
        fileItem.Text = "Plik";
        fileItem.MenuItems.Add(exitItem);
 
        Menu = new MainMenu();
        Menu.MenuItems.Add(fileItem);
        Text = "Poka¿ polecenie";
    }
 
    static void Main() 
    {
        Application.Run(new ShowCommand());
    }

    private void ExitApp(object o, EventArgs e)
    {
        Application.Exit();            
    }
}