using System;
using Filters;
/// <summary>
/// Przyk�ad u�ycia filtra dla ma�ych liter.
/// </summary>
public class ShowLowerCase
{
    /// <summary>
    /// Punkt wej�cia aplikacji.
    /// </summary>
    static void Main(string[] args)
    {
        ISimpleWriter w = new SimpleStreamWriter("sample.txt");
        ISimpleWriter x = new LowerCaseFilter(w);
        x.Write("Przyk�adowy Tekst, co ciekawe CA�Y Ma�ymI liteRamI!");
        x.Close();
    }
}