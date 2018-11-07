namespace Aster 
{
    /// <summary>
    /// Klasa steruj�ca fikcyjn� pras� gwiazdow� Aster i wspomagaj�ca
    /// komunikacj� z fabryk�, w kt�rej prasa si� znajduje. W rzeczywisto�ci
    /// klasa jest pretekstem do pokazania sposobu, w kt�ry klient m�g�by
    /// dostarczy� metod� szablonow�.
    /// 
    /// Klasa jest opisana w rozdziale Template Method.
    /// </summary>
    public abstract class AsterStarPress 
    {
        protected int _currentMoldID;

        /// <summary>
        /// Wyrzuca ca�� past� u�ywan� do tworzenia gwiazd do �mietnika.
        /// </summary>
        public virtual void DischargePaste()
        {
        }

        /// <summary>
        /// Zlanie wod� powierzchni roboczej i dysz z past� w celu utrzymania
        /// czysto�ci maszyny.
        /// </summary>
        public virtual void Flush()
        {
        }

        /// <summary>
        /// Zwraca true je�li maszyna aktualnie przetwarza form�.
        /// </summary>
        /// <returns>true je�li maszyna aktualnie przetwarza form�</returns>
        public virtual bool InProcess()
        {
            return false;
        }

        /// <summary>
        /// Konkretny spos�b radzenia sobie przez fabryk� z niekompletnie
        /// przetworzon� form� zostanie zaimplementowany w klasach
        /// dziedzicz�cych.
        /// </summary>
        /// <param name="id">identyfikator niekompletnej formy</param>
        public abstract void MarkMoldIncomplete(int id);

        /// <summary>
        /// Wstrzymanie przetwarzania, oznaczenie bie��cej formy jako 
        /// niekompletnej, usuni�cie z maszyny wszystkich form, wyrzucenie
        /// przygotowanej pasty i zlanie powierzchni roboczej wod�.
        /// </summary>
        public virtual void ShutDown()
        {
            if (InProcess())
            {
                StopProcessing();
                MarkMoldIncomplete(_currentMoldID);
            }
            UsherInputMolds();
            DischargePaste();
            Flush();
        }

        /// <summary>
        /// Wstrzymanie przetwarzania.
        /// </summary>
        public virtual void StopProcessing()
        {
        }

        /// <summary>
        /// Przesuni�cie wszystkich form na ta�m� wyj�ciow�.
        /// </summary>
        public virtual void UsherInputMolds()
        {
        }
    }
}
