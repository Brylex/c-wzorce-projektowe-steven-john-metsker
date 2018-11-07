using System;
using System.Collections;
using System.Threading;
using BusinessCore;
/// <summary>
/// Pokazuje �e sama synchronizacja listy nie zapewnia bezpiecznego
/// ze wzgl�du na w�tki jej przechodzenia w p�tli for.
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
            { // symulacja obudzenia w�tku
                new Thread(new ThreadStart(NewMachineComesUp)).Start();
            }
            Thread.Sleep(100); // dopuszczenie innych w�tk�w
            Console.WriteLine(_list[i]);
        }
    }
    /// <summary>
    /// Symulacja dodania nowej maszyny do listy, po kt�rej w�a�nie iterujemy.
    /// </summary>
    public void NewMachineComesUp()
    {
        _list.Insert(0, "Fuser:1101");
    }
    /// <summary>
    /// Punkt wej�cia aplikacji.
    /// </summary>
    public static void Main()
    {
        new ShowConcurrentFor().DisplayUpMachines();
    }
}