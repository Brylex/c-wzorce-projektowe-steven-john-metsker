namespace Chemicals
{
	/// <summary>
	/// Interfejs omówiony w rozdziale Flyweight, maj¹cy na celu ograniczenie
	/// mo¿liwoœci tworzenia obiektów zwi¹zków chemicznych.
	/// </summary>
	public interface IChemical
    {
        string Name { get; }
        string Symbol { get; }
        double AtomicWeight { get; }
	}
}
