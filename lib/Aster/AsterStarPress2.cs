namespace Aster 
{
    public delegate void AsterHook(AsterStarPress2 p);
    /// <summary>
    /// Zmodyfikowana wersja klasy AsterStarPress, wprowadzaj¹ca
    /// wzorzec Command w celu umo¿liwienia klientowi wp³ywania na jej
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
        /// Wyrzuca ca³¹ pastê u¿ywan¹ do tworzenia gwiazd do œmietnika.
        /// </summary>
        public virtual void DischargePaste()
        {
        }

        /// <summary>
        /// Zlanie wod¹ powierzchni roboczej i dysz z past¹ w celu utrzymania
        /// czystoœci maszyny.
        /// </summary>
        public virtual void Flush()
        {
        }

        /// <summary>
        /// Zwraca true jeœli maszyna aktualnie przetwarza formê.
        /// </summary>
        /// <returns>true jeœli maszyna aktualnie przetwarza formê</returns>
        public virtual bool InProcess()
        {
            return false;
        }

        /// <summary>
        /// Konkretny sposób radzenia sobie przez fabrykê z niekompletnie
        /// przetworzon¹ form¹ zostanie zaimplementowany w klasach
        /// dziedzicz¹cych.
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
        /// Przesuniêcie wszystkich form na taœmê wyjœciow¹.
        /// </summary>
        public virtual void UsherInputMolds()
        {
        }
    }
}
