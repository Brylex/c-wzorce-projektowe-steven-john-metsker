using System;
namespace Machines
{
    /// <summary>
    /// Model maszyny montuj�cej petardy powietrzne z gwiazd, prochu 
    /// i tekturowej obudowy.
    /// </summary>
    public class ShellAssembler : Machine
    {
        // private ShellPlanner _planner; // usuni�te w ramach przekszta�cenia w rozdziale Template Method
        /// <summary>
        /// Tworzy maszyn� o podanym identyfikatorze i maszynie macierzystej.
        /// </summary>
        /// <param name="id">identyfikator maszyny</param>
        public ShellAssembler(int id) : base (id)
        {
        }
        /// <summary>
        /// Zwraca obiekt planuj�cy dla bie��cej maszyny.
        /// </summary>
        /// <returns>obiekt planuj�cy dla bie��cej maszyny</returns>
        public override MachinePlanner CreatePlanner() 
        {
            return new ShellPlanner(this);
        }

        /* (poni�szy kod jest usuni�ty w ramach przekszta�cenia w rozdziale Template Method)
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
