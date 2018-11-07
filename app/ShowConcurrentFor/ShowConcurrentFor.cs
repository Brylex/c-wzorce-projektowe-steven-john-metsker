using System;
using System.Collections;
using System.Threading;
using BusinessCore;
/// <summary>
/// Pokazuje ¿e sama synchronizacja listy nie zapewnia bezpiecznego
/// ze wzglêdu na w¹tki jej przechodzenia w pêtli for.
/// </summary>
public class ShowConcurrentFor   
{
    private ArrayList _list;
    protected void DisplayUpMachines()
    {
        _list = ArrayList.Synchronized(Factory.UpMachineNames()); 
        for (int i = 0; i < _list.Count; i++)
        {
            if (i == 2)
            { // symulacja obudzenia w¹tku
                new Thread(new ThreadStart(NewMachineComesUp)).Start();
            }
            Thread.Sleep(100); // dopuszczenie innych w¹tków
            Console.WriteLine(_list[i]);
        }
    }
    /// <summary>
    /// Symulacja dodania nowej maszyny do listy, po której w³aœnie iterujemy.
    /// </summary>
    public void NewMachineComesUp()
    {
        _list.Insert(0, "Fuser:1101");
    }
    /// <summary>
    /// Punkt wejœcia aplikacji.
    /// </summary>
    public static void Main()
    {
        new ShowConcurrentFor().DisplayUpMachines();
    }
}