namespace Aster 
{
    public delegate void AsterHook(AsterStarPress2 p);
    /// <summary>
    /// Zmodyfikowana wersja klasy AsterStarPress, wprowadzaj�ca
    /// wzorzec Command w celu umo�liwienia klientowi wp�ywania na jej
    /// zachowanie.
    /// 
    /// Klasa opisana w rozdziale Command. 
    /// </summary>
    public class AsterStarPress2
    {
        public event AsterHook MoldIncomplete;
        protected int _currentMoldID;

        /// <summary>
        /// Identyfikator aktualnie przetwarzanej formy.
        /// </summary>
        public int CurrentMoldID
        {
            get
            {
                return _currentMoldID;
            }
        }

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
        public virtual void ShutDown()
        {
            if (InProcess())
            {
                StopProcessing();
                if (MoldIncomplete != null) 
                {
                    MoldIncomplete(this); 
                }
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
