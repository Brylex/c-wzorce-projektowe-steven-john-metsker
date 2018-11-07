namespace Machines
{
	/// <summary>
	/// Definiuje operacje, jakie musi implementowaæ ka¿da klasa odwiedzaj¹ca 
	/// obiekt MachineComponent.
	/// </summary>
	public interface IMachineVisitor
    {
        void Visit(Machine m);
        void Visit(MachineComposite c);
	}
}
