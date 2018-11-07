using System;
using Machines;
/// <summary>
/// Klasa przygotowuj¹ca zadanie z rozdzia³u Composite.
/// </summary>
public class ShowPlant 
{
    public static void Main() 
    {
        MachineComponent c = ExampleMachine.Plant();
        Console.WriteLine(c.GetMachineCount());
    }
}