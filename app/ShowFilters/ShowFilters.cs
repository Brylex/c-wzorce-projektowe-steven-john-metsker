using System;
using System.IO;
using Filters;
/// <summary>
/// Klasa pokazuje kilka przyk³adów tworzenia filtrów.
/// </summary>
public class ShowFilters
{
    static void Main(string[] args)
    {
        if (args.Length < 2)
        {
            Console.WriteLine("U¿ycie: ShowFilters wejœcie wyjœcie");
            return;
        }
        StreamReader   r = new StreamReader(args[0]);
        ISimpleWriter w1 = new SimpleStreamWriter(args[1]);
        ISimpleWriter w2 = new TitleCaseFilter(w1);
        WrapFilter    w3 = new WrapFilter(w2, 40);
        w3.Center = true;
        String line;
        while ((line = r.ReadLine()) != null)
        {
            w3.Write(line);
        }
        r.Close();
        w3.Close();
    }
}