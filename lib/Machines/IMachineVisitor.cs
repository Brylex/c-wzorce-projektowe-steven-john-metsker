namespace Machines
{
	/// <summary>
	/// Definiuje operacje, jakie musi implementowa� ka�da klasa odwiedzaj�ca 
	/// obiekt MachineComponent.
	/// </summary>
	public interface IMachineVisitor
    {
        void Visit(Machine m);
        void Visit(MachineComposite c);
	}
}
