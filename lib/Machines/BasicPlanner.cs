using System;
using Machines;
namespace Machines
{
	/// <summary>
	/// Og�lny obiekt planuj�cy dla maszyn, kt�re nie maj� w�asnego obiektu planuj�cego.
	/// </summary>
	public class BasicPlanner : MachinePlanner
	{
		public BasicPlanner(Machine m) : base (m)
		{
		}
        
        public override DateTime GetAvailable 
        {
            get { return DateTime.Now; }
        }
	}
}
