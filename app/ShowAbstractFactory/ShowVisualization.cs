using System;
using System.Windows.Forms;
using UserInterface;
using Visualizations;

	/// <summary>
	/// Demonstruje u�ycie innego zestawu kontrolek GUI (innej fabryki
	/// abstrakcji).
	/// </summary>
public class ShowVisualization
{
    /// <summary>
    /// Punkt wej�cia aplikacji.
    /// </summary> 
    static void Main() 
    {
        Application.Run(new Visualization(UI.NORMAL));
    }
}