using System;
using RobotInterpreter2;
/// <summary>
/// Klasa interpretuj�ca, kt�rej wykonanie powoduje wypisanie warto�ci
/// zadanej zmiennej, uzyskanej za po�rednictwem ToString().
/// </summary>
public class PrintCommand : Command
{
    private Variable _v;
    public PrintCommand(Variable v)
    {
        _v = v;
    }
    public override void Execute()
    {
        Console.WriteLine(_v);
    }
}