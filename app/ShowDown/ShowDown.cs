using System;
using Machines;
using RobotInterpreter2;
/// <summary>
/// Pokazuje konstrukcj� i wykorzystanie male�kiego interpretera
/// wy��czaj�cego wszystkie maszyny w danej fabryce.
/// </summary>
class ShowDown
{
    /// <summary>
    /// Punkt wej�cia aplikacji.
    /// </summary>
    static void Main()
    {
        MachineComposite dublin = ExampleMachine.Dublin();
        Variable v = new Variable("machine");
        Command c = new ForCommand(dublin, v, new ShutDownCommand(v));
        c.Execute();
    }
}