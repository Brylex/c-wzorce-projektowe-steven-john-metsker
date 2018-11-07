using System;
namespace ShowNew
{
    /// <summary>
    /// Klasa rakiet, których ci¹g zawsze wynosi 1.
    /// </summary>
    public class DemoRocket 
    {
        public double Thrust() { return 1; }         
    } 
    /// <summary>
    /// Klasa dziedzicz¹ca z DemoRocket - jej instancje zawsze maj¹ ci¹g równy 2.
    /// </summary>
    public class DemoShell : DemoRocket 
    {
        /// <summary>
        /// Zwróæ uwagê na s³owo kluczowe "new" w deklaracji metody.
        /// Czy metoda przes³ania metodê Thrust() swojej nadklasy?
        /// </summary>
        /// <returns>2</returns>
        public new double Thrust() { return 2; }
    } 
    /// <summary>
    /// Jedyna normalna klasa w tej demonstracji. Dostarcza metodê
    /// wypisuj¹c¹ ci¹g rakiety.
    /// </summary>
    public class DemoEvent 
    {
        public void Add(DemoRocket r) 
        {
            Console.WriteLine(
                "Dodajê rakietê o ci¹gu " + r.Thrust());
        }
    }
    /// <summary>
    /// Klasa tworzy instancjê DemoShell i przekazuje j¹ metodzie Add() obiektu
    /// DemoEvent. Metoda ta oczekuje wprawdzie obiektu klasy DemoRocket, ale
    /// to nie szkodzi, gdy¿ DemoShell dziedziczy z DemoRocket.
    /// 
    /// Zadanie: Jaki wynik wypisuje ten program?
    /// </summary>
    public class ShowNewModifier 
    {
        public static void Main() 
        {  
            DemoEvent e = new DemoEvent();
            e.Add(new DemoShell());
        }
    }
}
