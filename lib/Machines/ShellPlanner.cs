using System;
using Machines;
namespace Machines
{
	/// <summary>
	/// Obiekt planujący odpowiadający za szacowanie dostępności maszyny
	/// montującej petardy powietrzne.
	/// </summary>
	public class ShellPlanner : MachinePlanner
	{
		public ShellPlanner(Machine m) : base (m)
		{
		}
        /// <summary>
        /// Podaje czas dostępności maszyny; metoda nie jest zaimplementowana.
        /// </summary>    
        public override DateTime GetAvailable 
        {
            get { return DateTime.Now; }
        }
	}
}
