using System;
using Machines;
/// <summary>
/// Klasa przygotowuj�ca zadanie z rozdzia�u Composite.
/// </summary>
public class ShowPlant 
{
    public static void Main() 
    {
        MachineComponent c = ExampleMachine.Plant();
        Console.WriteLine(c.GetMachineCount());
    }
}