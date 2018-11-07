/// <summary>
/// Klasa WebAd przekszta³cona do postaci u¿ywaj¹cej w³aœciwoœci C#.
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