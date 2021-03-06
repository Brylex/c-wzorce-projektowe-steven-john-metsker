using System;
using System.Drawing;
using System.Windows.Forms;
using UserInterface;
/// <summary>
/// Klasa demonstrująca zastosowanie wzorca Proxy. Co istotne, tekst rozdziału
/// Proxy przedstawia argumenty przeciwko stosowaniu takiego podejścia.
/// </summary>
public class PictureBoxProxy : Control
{
    private PictureBox _pictureBox;
    private string _imageName;
    private Image _image; 
    /// <summary>
    /// Tworzy pośrednika dla obiektu PictureBox, ładowanego w oczekiwaniu na
    /// załadowanie tego ostatniego.
    /// </summary>
    /// <param name="pictureBox">obiekt PictureBox zastępowany przez pośrednika</param>
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
    /// Poniesienie kosztu załadowania obrazu docelowego.
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