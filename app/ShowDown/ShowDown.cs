using System;
using Machines;
using RobotInterpreter2;
/// <summary>
/// Pokazuje konstrukcjê i wykorzystanie maleñkiego interpretera
/// wy³¹czaj¹cego wszystkie maszyny w danej fabryce.
/// </summary>
class ShowDown
{
    /// <summary>
    /// Punkt wejœcia aplikacji.
    /// </summary>
    static void Main()
    {
        MachineComposite dublin = ExampleMachine.Dublin();
        Variable v = new Variable("machine");
        Command c = new ForCommand(dublin, v, new ShutDownCommand(v));
        c.Execute();
    }
}