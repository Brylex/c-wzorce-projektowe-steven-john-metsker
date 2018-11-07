using System;
using Filters;
/// <summary>
/// Przyk³ad u¿ycia filtra dla ma³ych liter.
/// </summary>
public class ShowLowerCase
{
    /// <summary>
    /// Punkt wejœcia aplikacji.
    /// </summary>
    static void Main(string[] args)
    {
        ISimpleWriter w = new SimpleStreamWriter("sample.txt");
        ISimpleWriter x = new LowerCaseFilter(w);
        x.Write("Przyk³adowy Tekst, co ciekawe CA£Y Ma£ymI liteRamI!");
        x.Close();
    }
}