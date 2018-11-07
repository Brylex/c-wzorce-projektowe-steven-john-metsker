using System;
using System.Windows.Forms;
using Machines;
using UserInterface;
/// <summary>
/// Przyk�ad u�ycia klasy TreeNodeVisitor.
/// </summary>
public class ShowTreeNodeVisitor : Form
{
    public ShowTreeNodeVisitor()
    {
        TreeView view = new TreeView();
        view.Dock = DockStyle.Fill;
        view.Font = UI.NORMAL.Font; 
        TreeNodeVisitor v = new TreeNodeVisitor();
        v.Visit(ExampleMachine.Dublin());
        view.Nodes.Add(v.TreeNode);
        Controls.Add(view);        
        Text = "Widok w�z��w drzewa"; 
    }
    /// <summary>
    /// Punkt wej�cia aplikacji.
    /// </summary>
    public static void Main() 
    {
        Application.Run(new ShowTreeNodeVisitor());
    }
}