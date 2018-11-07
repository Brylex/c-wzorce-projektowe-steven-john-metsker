using System;
using System.Windows.Forms;
using Machines;
    /// <summary>
    /// Klasa-goœæ tworz¹ca strukturê TreeNode stanowi¹c¹ odzwierciedlenie 
    /// zawartoœci odwiedzanego kompozytu.
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
    /// Odwiedzenie maszyny: dodanie obiektu TreeNode w bie¿¹cym miejscu
    /// w drzewie.
    /// </summary>
    /// <param name="m">odwiedzana maszyna</param>
    public void Visit(Machine m)
    {
        AddNode(m);
    }
    /// <summary>
    /// Odwiedzenie kompozytu maszyn: dodanie obiektu TreeNode w bie¿¹cym 
    /// miejscu w drzewie, ustawienie tego nowego wêz³a jako bie¿¹cego,
    /// odwiedzenie wszystkich potomków w ramach kompozytu i przywrócenie
    /// pierwotnego wêz³a bie¿¹cego.
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
    /// Dodaje wêze³ drzewa dla wskazanego komponentu.
    /// </summary>
    /// <param name="m">dodawany komponent</param>
    /// <returns>nowy wêze³ drzewa</returns>
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