using System;
using Machines;
namespace Machines
{
	/// <summary>
	/// Obiekt planujący odpowiadający za szacowanie dostępności prasy gwiazdowej.
	/// </summary>
	public class StarPressPlanner : MachinePlanner
	{
		public StarPressPlanner(Machine m) : base (m)
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
