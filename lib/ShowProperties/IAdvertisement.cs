using System; 
/// <summary>
/// Przyk�ad interfejsu, kt�ry nie u�ywa w�a�ciwo�ci (a m�g�by).
/// </summary>
public interface IAdvertisement
{
    int GetID();
    string GetAdCopy();
    void SetAdCopy (string text);
}