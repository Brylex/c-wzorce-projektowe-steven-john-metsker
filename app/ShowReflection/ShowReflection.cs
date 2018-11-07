using System;
using System.Reflection;
using Fireworks;

/// <summary>
/// Skromna demonstracja tworzenia instancji za pomoc� refleksji.
/// </summary>
public class ShowReflection
{
    /// <summary>
    /// Punkt wej�cia aplikacji.
    /// </summary>
    public static void Main()
    {
        Type t = typeof(Firework);
        ConstructorInfo c = t.GetConstructor(
            new Type[]{typeof(String), typeof(Double), typeof(Decimal)});
        Console.WriteLine(c.Invoke(new Object[]{"Titan", 6500, 31.95M}));
    }
}