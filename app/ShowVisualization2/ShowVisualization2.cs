using System;
using System.Windows.Forms;
using UserInterface;
using Visualizations;

	/// <summary>
	/// Pokazuje wykorzystanie innego zestawu GUI (innej fabryki abstrakcji).
	/// </summary>
public class ShowVisualization2
{
    /// <summary>
    /// Punkt wejœcia aplikacji.
    /// </summary> 
    static void Main() 
    {
        Application.Run(new Visualization2(UI.NORMAL));
    }
}