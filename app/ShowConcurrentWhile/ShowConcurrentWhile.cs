using System;
using System.Collections;
using System.Threading;
using BusinessCore;
/// <summary>
/// Pokazuje ¿e iterowanie po synchronizowanej liœcie mo¿e wskazaæ
/// problem z obs³ug¹ wielow¹tkowoœci.
/// </summary>
public class ShowConcurrentWhile   
{
    private ArrayList _list;
    protected void DisplayUpMachines()
    {
        _list = ArrayList.Synchronized(Factory.UpMachineNames());
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
        Console.WriteLine(
            @"Dzia³anie programu koñczy siê awari¹ w celu zademonstrowania efektów modyfikacji 'synchronizowanej' listy podczas iterowania po niej.");
        new ShowConcurrentWhile().DisplayUpMachines();
    }
}