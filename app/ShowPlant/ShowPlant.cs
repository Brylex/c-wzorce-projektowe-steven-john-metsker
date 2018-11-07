using System;
using Machines;
/// <summary>
/// Klasa przygotowująca zadanie z rozdziału Composite.
/// </summary>
public class ShowPlant 
{
    public static void Main() 
    {
        MachineComponent c = ExampleMachine.Plant();
        Console.WriteLine(c.GetMachineCount());
    }
}