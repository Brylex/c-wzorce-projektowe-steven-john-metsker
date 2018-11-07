/// <summary>
/// Klasa WebAd przekszta�cona do postaci u�ywaj�cej w�a�ciwo�ci C#.
/// </summary>
public class WebAd2 : IAdvertisement2
{
    private int _id;
    private string _adCopy = "";
    public WebAd2 (int id) 
    {
        _id = id;
    } 
    public int ID 
    {
        get { return _id; }
    }
    public string AdCopy 
    {
        get { return _adCopy; }
        set { _adCopy = value; }
    } 
}