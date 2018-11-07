using System;
using System.Collections;
using System.Threading;
using BusinessCore;
/// <summary>
/// Pokazuje �e iterowanie po synchronizowanej li�cie mo�e wskaza�
/// problem z obs�ug� wielow�tkowo�ci.
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
            { // symulacja obudzenia w�tku
                new Thread(new ThreadStart(NewMachineComesUp)).Start();
            }
            Thread.Sleep(100); // dopuszczenie innych w�tk�w
            Console.WriteLine(i.Current);
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
        Console.WriteLine(
            @"Dzia�anie programu ko�czy si� awari� w celu zademonstrowania efekt�w modyfikacji 'synchronizowanej' listy podczas iterowania po niej.");
        new ShowConcurrentWhile().DisplayUpMachines();
    }
}