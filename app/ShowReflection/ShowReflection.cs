using System;
using System.Reflection;
using Fireworks;

/// <summary>
/// Skromna demonstracja tworzenia instancji za pomoc¹ refleksji.
/// </summary>
public class ShowReflection
{
    /// <summary>
    /// Punkt wejœcia aplikacji.
    /// </summary>
    public static void Main()
    {
        Type t = typeof(Firework);
        ConstructorInfo c = t.GetConstructor(
            new Type[]{typeof(String), typeof(Double), typeof(Decimal)});
        Console.WriteLine(c.Invoke(new Object[]{"Titan", 6500, 31.95M}));
    }
}