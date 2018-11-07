using System;
using System.Collections;
using System.Threading;
using BusinessCore;
/// <summary>
/// Pokazuje wykorzystanie blokowania muteksu w celu zapewnienia wzajemnego
/// wy³¹czania dwóch w¹tków. Wiêcej informacji o wzajemnym wy³¹czaniu w¹tków
/// zawiera rodzia³ Iterator.
/// </summary>
public class ShowConcurrentMutex 
{
    private ArrayList _list;
    private Object _mutex = new Object();

    protected void DisplayUpMachines() 
    {
        _list = Factory.UpMachineNames();
        lock (_mutex) 
        {
            IEnumerator i = _list.GetEnumerator();
            int counter = 0;
            while (i.MoveNext())
            {
                if (++counter == 2)
                { // symulacja obudzenia w¹tku
                    new Thread(new ThreadStart(NewMachineComesUp)).Start();
                }
                Thread.Sleep(100); // dopuszczenie innych w¹tków
                Console.WriteLine(i.Current);
            }
        }
    }
    public void NewMachineComesUp() 
    {
        lock (_mutex) 
        {
            _list.Insert(0, "Fuser:1101");
        }
    }
    public static void Main() 
    {
        new ShowConcurrentMutex().DisplayUpMachines();
    }
}