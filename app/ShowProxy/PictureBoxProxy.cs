using System;
using System.Drawing;
using System.Windows.Forms;
using UserInterface;
/// <summary>
/// Klasa demonstruj¹ca zastosowanie wzorca Proxy. Co istotne, tekst rozdzia³u
/// Proxy przedstawia argumenty przeciwko stosowaniu takiego podejœcia.
/// </summary>
public class PictureBoxProxy : Control
{
    private PictureBox _pictureBox;
    private string _imageName;
    private Image _image; 
    /// <summary>
    /// Tworzy poœrednika dla obiektu PictureBox, ³adowanego w oczekiwaniu na
    /// za³adowanie tego ostatniego.
    /// </summary>
    /// <param name="pictureBox">obiekt PictureBox zastêpowany przez poœrednika</param>
    /// <param name="imageName">nazwa obrazu</param>
    /// 
    public PictureBoxProxy(PictureBox pictureBox, string imageName)
    {
        _pictureBox = pictureBox;
        _imageName = imageName;
    }
    /// <summary>
    /// Zwraca obraz podstawowy.
    /// </summary>
    public Image Image 
    {
        get 
        {
            if (_image == null) 
                return _pictureBox.Image; 
            else 
                return _image;
        }
    }
    /// <summary>
    /// Poniesienie kosztu za³adowania obrazu docelowego.
    /// </summary>
    public void Load() 
    {
        _image = UI.GetImage(_imageName);
    }
    protected override void OnPaint(PaintEventArgs pea) 
    {
        Graphics g = pea.Graphics;
        g.DrawImage(Image, 0, 0);
    }
}