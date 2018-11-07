using System;
using System.Collections;
using Machines;
using RobotInterpreter2;
	/// <summary>
	/// Demonstracja wykorzystania obiektu ForCommand.
	/// </summary>
class ShowInterpreterFor
{
    /// <summary>
    /// Punkt wejœcia aplikacji.
    /// </summary>
    static void Main()
    {
        Variable v = new Variable("machine");
        Command c = new ForCommand(ExampleMachine.Dublin(), v, new PrintCommand(v));
        c.Execute();
    }
}