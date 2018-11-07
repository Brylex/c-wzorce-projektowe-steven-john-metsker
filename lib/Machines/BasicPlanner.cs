using System;
using Machines;
namespace Machines
{
	/// <summary>
	/// Ogólny obiekt planuj¹cy dla maszyn, które nie maj¹ w³asnego obiektu planuj¹cego.
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
