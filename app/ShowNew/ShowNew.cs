using System;
namespace ShowNew
{
    /// <summary>
    /// Klasa rakiet, kt�rych ci�g zawsze wynosi 1.
    /// </summary>
    public class DemoRocket 
    {
        public double Thrust() { return 1; }         
    } 
    /// <summary>
    /// Klasa dziedzicz�ca z DemoRocket - jej instancje zawsze maj� ci�g r�wny 2.
    /// </summary>
    public class DemoShell : DemoRocket 
    {
        /// <summary>
        /// Zwr�� uwag� na s�owo kluczowe "new" w deklaracji metody.
        /// Czy metoda przes�ania metod� Thrust() swojej nadklasy?
        /// </summary>
        /// <returns>2</returns>
        public new double Thrust() { return 2; }
    } 
    /// <summary>
    /// Jedyna normalna klasa w tej demonstracji. Dostarcza metod�
    /// wypisuj�c� ci�g rakiety.
    /// </summary>
    public class DemoEvent 
    {
        public void Add(DemoRocket r) 
        {
            Console.WriteLine(
                "Dodaj� rakiet� o ci�gu " + r.Thrust());
        }
    }
    /// <summary>
    /// Klasa tworzy instancj� DemoShell i przekazuje j� metodzie Add() obiektu
    /// DemoEvent. Metoda ta oczekuje wprawdzie obiektu klasy DemoRocket, ale
    /// to nie szkodzi, gdy� DemoShell dziedziczy z DemoRocket.
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
