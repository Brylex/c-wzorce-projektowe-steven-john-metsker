using System;

namespace Machines
{ 
    /// <summary>
    /// Modeluje standardowy, gumowy pojemnik, mieszcz�cy oko�o czterech litr�w
    /// zwi�zku chemicznego. Klasa stanowi minimalny model, pokazuj�cy spos�b
    /// zarz�dzania relacj� jeden do wielu w modelu obiektowym.
    /// </summary>
    public class Tub 
    {
        private String _id;
        private TubMediator _mediator = TubMediator.SINGLETON;
        /// <summary>
        /// Tworzy pojemnik o podanym identyfikatorze, zarz�dzany przez 
        /// mediatora.
        /// </summary>
        /// <param name="id">identyfikator pojemnika</param>
        public Tub(String id)
        {
            _id = id;
        }
        /// <summary>
        /// Pobieranie i ustawianie lokalizacji pojemnika za po�rednictwem mediatora.
        /// Pozwala to zapobiec zamodelowaniu lokalizacji pojemnika przy dw�ch
        /// maszynach jednocze�nie.
        /// </summary>
        public Machine Location
        {
            get
            {
                return _mediator.GetMachine(this);
            }
            set
            {
                _mediator.Set(this, value);
            }
        }
        /// <summary>
        /// Zwraca tekstow� reprezentacj� pojemnika.
        /// </summary>
        /// <returns>tekstow� reprezentacj� pojemnika</returns>
        public override String ToString()
        {
            return _id;
        }
        /// <summary>
        /// Zwraca unikalny identyfikator pojemnika.
        /// </summary>
        /// <returns>unikalny identyfikator pojemnika</returns>
        public override int GetHashCode()
        {
            return _id.GetHashCode();
        }
        /// <summary>
        /// Zwraca true je�li z biznesowego punktu widzenia bie��cy obiekt
        /// i dostarczony obiekt odwo�uj� si� do tej samej maszyny.
        /// </summary>
        /// <param name="o">por�wnywany obiekt</param>
        /// <returns>true je�li bie��cy obiekt i dostarczony obiekt 
        /// odwo�uj� si� do tej samej maszyny</returns>
        public override bool Equals(Object o)
        {
            if (o == this)
            {
                return true;
            }
            if (!(o is Tub))
            {
                return false;
            }                                                    
            Tub t = (Tub) o;
            return _id.Equals(t._id);
        }
    }
}
