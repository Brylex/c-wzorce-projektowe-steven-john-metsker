using System;
namespace RobotInterpreter2
{
    /// <summary>
    /// Klasa niepodejmuj�ca �adnych dzia�a�.
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
