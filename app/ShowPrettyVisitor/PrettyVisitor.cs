using System;
using System.Text;
using Processes;
using Utilities;
/// <summary>
/// Klasa u¿ywa mechanizmu goœcia z hierarchii procesów w celu dodania
/// mo¿liwoœci ozdobnego wypisania zawartoœci kompozytu procesu. Ozdoby
/// polegaj¹ w gruncie rzeczy na wciêciach, choæ alternacje s¹ dodatkowo
/// oznaczane znakami zapytania.
/// 
/// Klasa goœcia uwa¿a, by ¿adnego komponentu nie wydrukowaæ dwukrotnie 
/// (w przypadku natrafienia na komponent cykliczny. Przy powtórnym napotkaniu
/// elementu, aplikacja wypisuje wielokropek (...) jako znak pominiêcia. 
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
    /// <param name="pc">wyœwietlany komponent procesu</param>
    /// <returns>zawartoœæ zadanego komponentu wraz z wciêciami</returns>
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
    /// Dodaje kolejny etap do bufora wyjœciowego.
    /// </summary>
    /// <param name="s">etap</param>
    public void Visit(ProcessStep s)
    {
        PrintIndentedString(s.Name);
    }
    /// <summary>
    /// Dodaje alternacjê do bufora wyjœciowego.
    /// </summary>
    /// <param name="a">alternacja</param>
    public void Visit(ProcessAlternation a)
    {
        VisitComposite("?", a);
    }
    /// <summary>
    /// Dodaje sekwencjê operacji do bufora wyjœciowego.
    /// </summary>
    /// <param name="s">sekwencja</param>
    public void Visit(ProcessSequence s)
    {
        VisitComposite("", s);
    }
    /// <summary>
    /// Wypisuje przedrostek i nazwê kompozytu, a nastêpnie wypisuje jego
    /// potomków. Jeœli element by³ ju¿ wypisany, wypisuje znak pominiêcia
    /// zamiast od nowa wyœwietlaæ wszystkich potomków.
    /// </summary>
    /// <param name="prefix">mo¿liwy prefiks</param>
    /// <param name="c">wyœwietlany kompozyt</param>
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