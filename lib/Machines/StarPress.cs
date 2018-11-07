using System;
namespace Machines
{
    /// <summary>
    /// Model prasy gwiazdowej, t�ocz�cej z pasty chemicznej wybuchaj�ce kulki,
    /// czyli gwiazdy.
    /// </summary>
    public class StarPress : Machine
    {
        // private StarPressPlanner _planner; // usuni�te w ramach przekszta�cenia w rozdziale Template Method
        /// <summary>
        /// Tworzy maszyn� o podanym identyfikatorze i maszynie macierzystej.
        /// </summary>
        /// <param name="id">identyfikator maszyny</param>
        public StarPress(int id) : base (id)
        {
        }
        /// <summary>
        /// Zwraca obiekt planuj�cy dla bie��cej maszyny.
        /// </summary>
        /// <returns>obiekt planuj�cy dla bie��cej maszyny</returns>
        public override MachinePlanner CreatePlanner() 
        {
            return new StarPressPlanner(this);
        }

        /* (poni�szy kod jest usuni�ty w ramach przekszta�cenia w rozdziale Template Method)
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
