using System;
namespace RobotInterpreter2
{
    /// <summary>
    /// Klasa niepodejmuj¹ca ¿adnych dzia³añ.
    /// </summary>
    public class NullCommand : Command 
    {
        /// <summary>
        /// Nic nie robi.
        /// </summary>
        public override void Execute()
        {
        }
    }
}
