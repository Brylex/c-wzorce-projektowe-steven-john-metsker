using System;
using Machines;
namespace Machines
{
	/// <summary>
	/// Abstrakcyjna nadklasa dla klas planujących przyszłe zachowanie maszyn.
	/// </summary>
	public abstract class MachinePlanner 
	{
        protected Machine _machine;
		public MachinePlanner(Machine m)
		{
			_machine = m;
		}
        public abstract DateTime GetAvailable 
        {
            get;
        }
	}
}
