using System;
using System.Windows.Forms;
namespace UserInterface
{
    /// <summary>
    /// Klasa pokazuj�ca spos�b �atwego dostarczenia metody Copy(). Jednak
    /// przedstawiona tu implementacja jest zbyt niebezpieczna ze wzgl�du
    /// na liczne zmienne instancji dziedziczone z klasy GroupBox.
    /// </summary>
    public class OzGroupBox : GroupBox
    {
        // niebezpieczne!
        public OzGroupBox Copy()
        {
            return (OzGroupBox) this.MemberwiseClone();
        }
        public OzGroupBox Copy2()
        {
            OzGroupBox gb = new OzGroupBox();
            gb.BackColor = BackColor;
            gb.Dock = Dock;
            gb.Font = Font;
            gb.ForeColor = ForeColor;
            return gb;
        }
    }
}
