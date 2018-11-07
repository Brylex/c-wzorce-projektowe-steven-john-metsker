using System;
using System.Windows.Forms;
using Machines;
    /// <summary>
    /// Klasa-go�� tworz�ca struktur� TreeNode stanowi�c� odzwierciedlenie 
    /// zawarto�ci odwiedzanego kompozytu.
    /// </summary>
public class TreeNodeVisitor : IMachineVisitor
{
    private TreeNode _tree = null;
    private TreeNode _current = null;
    /// <summary>
    /// Wynikowy obiekt TreeNode.
    /// </summary>
    public TreeNode TreeNode 
    {
        get 
        {
            return _tree;
        }
    }
    /// <summary>
    /// Odwiedzenie maszyny: dodanie obiektu TreeNode w bie��cym miejscu
    /// w drzewie.
    /// </summary>
    /// <param name="m">odwiedzana maszyna</param>
    public void Visit(Machine m)
    {
        AddNode(m);
    }
    /// <summary>
    /// Odwiedzenie kompozytu maszyn: dodanie obiektu TreeNode w bie��cym 
    /// miejscu w drzewie, ustawienie tego nowego w�z�a jako bie��cego,
    /// odwiedzenie wszystkich potomk�w w ramach kompozytu i przywr�cenie
    /// pierwotnego w�z�a bie��cego.
    /// </summary>
    /// <param name="c">odwiedzany kompozyt</param>
    public void Visit(MachineComposite c)
    {
        TreeNode oldCurrent = _current;
        _current = AddNode(c);
        foreach (MachineComponent mc in c.Children)
        {
            mc.Accept(this);
        }
        _current = oldCurrent;
    }
    /// <summary>
    /// Dodaje w�ze� drzewa dla wskazanego komponentu.
    /// </summary>
    /// <param name="m">dodawany komponent</param>
    /// <returns>nowy w�ze� drzewa</returns>
    protected TreeNode AddNode(MachineComponent m) 
    {
        TreeNode newNode = new TreeNode(m.ToString());
        if (_current == null) 
        {
            _tree = newNode;
        }
        else
        {
            _current.Nodes.Add(newNode);
        }
        return newNode;
    }
}