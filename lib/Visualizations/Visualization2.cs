using System;
using System.Collections;
using System.Windows.Forms;
using UserInterface;

namespace Visualizations
{
    /// <summary>
    /// Wersja symulacji dodaj¹ca menu obs³uguj¹ce zapis i przywracanie
    /// stanu symulacji z pliku.
    /// </summary>
    public class Visualization2 : Visualization
    {
        public Visualization2(UI ui) : base (ui)
        {
            Menu = ApplicationMenu();
        }
        protected MainMenu ApplicationMenu()
        {
            MenuItem fileMenu = new MenuItem("File", new MenuItem[]
            {
                new MenuItem(
                "Save As...", 
                new EventHandler(_mediator.Save)),
                new MenuItem(
                "Restore From...", 
                new EventHandler(_mediator.Restore))             
            });
            return new MainMenu(new MenuItem[]{fileMenu});
        }
    }
}