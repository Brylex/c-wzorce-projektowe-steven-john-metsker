using System;
using RobotInterpreter2;
/// <summary>
/// Klasa interpretuj¹ca, której wykonanie powoduje wypisanie wartoœci
/// zadanej zmiennej, uzyskanej za poœrednictwem ToString().
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