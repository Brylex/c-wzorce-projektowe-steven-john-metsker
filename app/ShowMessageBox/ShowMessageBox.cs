using System.Windows.Forms;
/// <summary>
/// Minimalistyczna demonstracja u�ycia klasy MessageBox. Pytanie brzmi:
/// czy MessageBox jest fasad�?
/// </summary>
public class ShowMessageBox
{
    public static void Main() 
    {
        DialogResult dr;
        do 
        {
            dr = MessageBox.Show(
                "Masz ju� do��?",
                " Uparte okno dialogowe",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);
        } 
        while (dr == DialogResult.No);
    }
}