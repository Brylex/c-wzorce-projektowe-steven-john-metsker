using System;
namespace Machines
{
    /// <summary>
    /// Model prasy gwiazdowej, t³ocz¹cej z pasty chemicznej wybuchaj¹ce kulki,
    /// czyli gwiazdy.
    /// </summary>
    public class StarPress : Machine
    {
        // private StarPressPlanner _planner; // usuniête w ramach przekszta³cenia w rozdziale Template Method
        /// <summary>
        /// Tworzy maszynê o podanym identyfikatorze i maszynie macierzystej.
        /// </summary>
        /// <param name="id">identyfikator maszyny</param>
        public StarPress(int id) : base (id)
        {
        }
        /// <summary>
        /// Zwraca obiekt planuj¹cy dla bie¿¹cej maszyny.
        /// </summary>
        /// <returns>obiekt planuj¹cy dla bie¿¹cej maszyny</returns>
        public override MachinePlanner CreatePlanner() 
        {
            return new StarPressPlanner(this);
        }

        /* (poni¿szy kod jest usuniêty w ramach przekszta³cenia w rozdziale Template Method)
        public StarPressPlanner GetPlanner() 
        { 
            if (_planner == null) 
            {
                _planner = new StarPressPlanner(this);
            }
            return _planner;
        }
        */ 
    }
}
