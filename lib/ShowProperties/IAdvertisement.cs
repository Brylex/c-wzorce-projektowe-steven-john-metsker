using System; 
/// <summary>
/// Przyk³ad interfejsu, który nie u¿ywa w³aœciwoœci (a móg³by).
/// </summary>
public interface IAdvertisement
{
    int GetID();
    string GetAdCopy();
    void SetAdCopy (string text);
}