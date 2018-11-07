namespace Chemicals
{
	/// <summary>
	/// Interfejs om�wiony w rozdziale Flyweight, maj�cy na celu ograniczenie
	/// mo�liwo�ci tworzenia obiekt�w zwi�zk�w chemicznych.
	/// </summary>
	public interface IChemical
    {
        string Name { get; }
        string Symbol { get; }
        double AtomicWeight { get; }
	}
}
