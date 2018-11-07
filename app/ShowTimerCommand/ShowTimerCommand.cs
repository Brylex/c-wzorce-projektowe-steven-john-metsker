using System;

delegate void Command();
/// <summary>
/// Demonstruje us³ugê zwracaj¹c¹ czas wykonania zadanego polecenia.
/// </summary>
class ShowTimerCommand
{
    static void Main()
    {			
        Console.WriteLine(TimeThis(new Command(Snooze)));
    }
    static void Snooze()
    {
        System.Threading.Thread.Sleep(2000);
    }
    static TimeSpan TimeThis(Command c)
    {
        DateTime t1 = DateTime.Now;
        c();
        return DateTime.Now.Subtract(t1);
    }
}