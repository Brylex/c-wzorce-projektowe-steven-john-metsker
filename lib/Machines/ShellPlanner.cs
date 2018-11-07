using System;
using Machines;
namespace Machines
{
	/// <summary>
	/// Obiekt planuj�cy odpowiadaj�cy za szacowanie dost�pno�ci maszyny
	/// montuj�cej petardy powietrzne.
	/// </summary>
	public class ShellPlanner : MachinePlanner
	{
		public ShellPlanner(Machine m) : base (m)
		{
		}
        /// <summary>
        /// Podaje czas dost�pno�ci maszyny; metoda nie jest zaimplementowana.
        /// </summary>    
        public override DateTime GetAvailable 
        {
            get { return DateTime.Now; }
        }
	}
}
