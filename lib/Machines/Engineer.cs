using System;

namespace Machines
{
    /// <summary>
    /// Klasa nie jest zbyt dobrym modelem in¿yniera, ale dostarcza typ danych
    /// reprezentuj¹cy rolê osoby odpowiedzialnej za maszynê.
    /// </summary>
    public class Engineer 
    {
        protected int _employeeID;

        /// <summary>
        /// Modeluje in¿yniera o podanym identyfikatorze pracownika.
        /// </summary>
        /// <param name="_employeeID">identyfikator in¿yniera</param>
        public Engineer(int _employeeID)
        {
            this._employeeID = _employeeID;
        }
 
        /// <summary>
        /// Numer pracownika dla tego in¿yniera.
        /// </summary>
        public int EmployeeID 
        {
            get
            {
                return _employeeID;
            }
        }
    }
}
