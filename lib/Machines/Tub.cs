using System;

namespace Machines
{ 
    /// <summary>
    /// Modeluje standardowy, gumowy pojemnik, mieszcz¹cy oko³o czterech litrów
    /// zwi¹zku chemicznego. Klasa stanowi minimalny model, pokazuj¹cy sposób
    /// zarz¹dzania relacj¹ jeden do wielu w modelu obiektowym.
    /// </summary>
    public class Tub 
    {
        private String _id;
        private TubMediator _mediator = TubMediator.SINGLETON;
        /// <summary>
        /// Tworzy pojemnik o podanym identyfikatorze, zarz¹dzany przez 
        /// mediatora.
        /// </summary>
        /// <param name="id">identyfikator pojemnika</param>
        public Tub(String id)
        {
            _id = id;
        }
        /// <summary>
        /// Pobieranie i ustawianie lokalizacji pojemnika za poœrednictwem mediatora.
        /// Pozwala to zapobiec zamodelowaniu lokalizacji pojemnika przy dwóch
        /// maszynach jednoczeœnie.
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
        /// Zwraca tekstow¹ reprezentacjê pojemnika.
        /// </summary>
        /// <returns>tekstow¹ reprezentacjê pojemnika</returns>
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
        /// Zwraca true jeœli z biznesowego punktu widzenia bie¿¹cy obiekt
        /// i dostarczony obiekt odwo³uj¹ siê do tej samej maszyny.
        /// </summary>
        /// <param name="o">porównywany obiekt</param>
        /// <returns>true jeœli bie¿¹cy obiekt i dostarczony obiekt 
        /// odwo³uj¹ siê do tej samej maszyny</returns>
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
