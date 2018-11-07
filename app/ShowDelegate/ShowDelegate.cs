using System;
/// <summary>
/// Demonstracja u¿ywana w rozdziale Observer.
/// </summary>
class ShowDelegate
{
    static void Main(string[] args)
    {
        Interesting i = new Interesting();
        Curious c = new Curious(i);
        i.Wiggle();
    }
}