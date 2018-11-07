using System;
using Machines;
namespace Machines
{
	/// <summary>
	/// Obiekt planuj¹cy odpowiadaj¹cy za szacowanie dostêpnoœci maszyny
	/// montuj¹cej petardy powietrzne.
	/// </summary>
	public class ShellPlanner : MachinePlanner
	{
		public ShellPlanner(Machine m) : base (m)
		{
		}
        /// <summary>
        /// Podaje czas dostêpnoœci maszyny; metoda nie jest zaimplementowana.
        /// </summary>    
        public override DateTime GetAvailable 
        {
            get { return DateTime.Now; }
        }
	}
}
