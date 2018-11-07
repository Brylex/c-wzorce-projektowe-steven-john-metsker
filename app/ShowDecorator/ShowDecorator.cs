using System;
using System.IO;

/// <summary>
/// Kr�tka demonstracja spotykanej w bibliotekach FCL techniki tworzenia
/// strumieni ze strumieni.
/// </summary>
public class ShowDecorator
{
    public static void Main()
    {
        FileStream fs = new FileStream("sample.txt", FileMode.Create);
        StreamWriter sw = new StreamWriter(fs);
        sw.WriteLine("niewielka ilo�� przyk�adowego tekstu");
        sw.Close();
    }
}