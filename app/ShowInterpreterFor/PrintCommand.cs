using System;
using RobotInterpreter2;
/// <summary>
/// Klasa interpretująca, której wykonanie powoduje wypisanie wartości
/// zadanej zmiennej, uzyskanej za pośrednictwem ToString().
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