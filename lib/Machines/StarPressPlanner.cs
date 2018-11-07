using System;
using Machines;
namespace Machines
{
	/// <summary>
	/// Obiekt planuj¹cy odpowiadaj¹cy za szacowanie dostêpnoœci prasy gwiazdowej.
	/// </summary>
	public class StarPressPlanner : MachinePlanner
	{
		public StarPressPlanner(Machine m) : base (m)
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
