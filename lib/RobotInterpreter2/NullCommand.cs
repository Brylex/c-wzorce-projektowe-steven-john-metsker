using System;
namespace RobotInterpreter2
{
    /// <summary>
    /// Klasa niepodejmująca żadnych działań.
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
