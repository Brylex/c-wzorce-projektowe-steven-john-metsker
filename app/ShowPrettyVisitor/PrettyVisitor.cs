using System;
using System.Text;
using Processes;
using Utilities;
/// <summary>
/// Klasa u�ywa mechanizmu go�cia z hierarchii proces�w w celu dodania
/// mo�liwo�ci ozdobnego wypisania zawarto�ci kompozytu procesu. Ozdoby
/// polegaj� w gruncie rzeczy na wci�ciach, cho� alternacje s� dodatkowo
/// oznaczane znakami zapytania.
/// 
/// Klasa go�cia uwa�a, by �adnego komponentu nie wydrukowa� dwukrotnie 
/// (w przypadku natrafienia na komponent cykliczny. Przy powt�rnym napotkaniu
/// elementu, aplikacja wypisuje wielokropek (...) jako znak pomini�cia. 
/// </summary>
public class PrettyVisitor : IProcessVisitor 
{
    public static readonly string INDENT_STRING = "    ";
    private StringBuilder _buf;
    private int _depth;
    private Set _visited;    
    /// <summary>
    /// Zwraca ozdobny (czyli powcinany) opis zadanego komponentu procesu.
    /// </summary>
    /// <param name="pc">wy�wietlany komponent procesu</param>
    /// <returns>zawarto�� zadanego komponentu wraz z wci�ciami</returns>
    public StringBuilder GetPretty(ProcessComponent pc)
    {
        _buf = new StringBuilder();
        _visited = new Set();
        _depth = 0;
        pc.Accept(this);
        return _buf;
    }
    protected void PrintIndentedString(String s)
    {
        for (int i = 0; i < _depth; i++)
        {
            _buf.Append(INDENT_STRING);
        }
        _buf.Append(s);
        _buf.Append("\n");
    }
    /// <summary>
    /// Dodaje kolejny etap do bufora wyj�ciowego.
    /// </summary>
    /// <param name="s">etap</param>
    public void Visit(ProcessStep s)
    {
        PrintIndentedString(s.Name);
    }
    /// <summary>
    /// Dodaje alternacj� do bufora wyj�ciowego.
    /// </summary>
    /// <param name="a">alternacja</param>
    public void Visit(ProcessAlternation a)
    {
        VisitComposite("?", a);
    }
    /// <summary>
    /// Dodaje sekwencj� operacji do bufora wyj�ciowego.
    /// </summary>
    /// <param name="s">sekwencja</param>
    public void Visit(ProcessSequence s)
    {
        VisitComposite("", s);
    }
    /// <summary>
    /// Wypisuje przedrostek i nazw� kompozytu, a nast�pnie wypisuje jego
    /// potomk�w. Je�li element by� ju� wypisany, wypisuje znak pomini�cia
    /// zamiast od nowa wy�wietla� wszystkich potomk�w.
    /// </summary>
    /// <param name="prefix">mo�liwy prefiks</param>
    /// <param name="c">wy�wietlany kompozyt</param>
    protected void VisitComposite(String prefix, ProcessComposite c)
    {
        if (_visited.Contains(c))
        {
            PrintIndentedString(prefix + c.Name + "...");
        }
        else
        {
            _visited.Add(c);
            PrintIndentedString(prefix + c.Name);
            _depth++;
            foreach (ProcessComponent child in c.Children)
            {
                child.Accept(this);
            }
            _depth--;
        }
    }
}