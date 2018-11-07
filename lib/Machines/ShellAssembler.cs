using System;
namespace Machines
{
    /// <summary>
    /// Model maszyny montuj¹cej petardy powietrzne z gwiazd, prochu 
    /// i tekturowej obudowy.
    /// </summary>
    public class ShellAssembler : Machine
    {
        // private ShellPlanner _planner; // usuniête w ramach przekszta³cenia w rozdziale Template Method
        /// <summary>
        /// Tworzy maszynê o podanym identyfikatorze i maszynie macierzystej.
        /// </summary>
        /// <param name="id">identyfikator maszyny</param>
        public ShellAssembler(int id) : base (id)
        {
        }
        /// <summary>
        /// Zwraca obiekt planuj¹cy dla bie¿¹cej maszyny.
        /// </summary>
        /// <returns>obiekt planuj¹cy dla bie¿¹cej maszyny</returns>
        public override MachinePlanner CreatePlanner() 
        {
            return new ShellPlanner(this);
        }

        /* (poni¿szy kod jest usuniêty w ramach przekszta³cenia w rozdziale Template Method)
        public ShellPlanner GetPlanner() 
        {
            if (_planner == null) 
            {
                _planner = new ShellPlanner(this);
            }
            return _planner;
        }
        */
    }
}
