using System;
using Utilities;
/// <summary>
/// Malutka demonstracja faktu, ¿e obiekt klasy Set faktycznie zawiera
/// wy³¹cznie elementy ró¿ne.
/// </summary>
public class ShowSet
{
    public static void Main()
    {
        Set set = new Set();
        set.Add("Shooter");
        set.Add("Orbit");
        set.Add("Shooter");
        set.Add("Biggie");
        foreach (string s in set)
        {
            Console.WriteLine(s);
        }
    }
}