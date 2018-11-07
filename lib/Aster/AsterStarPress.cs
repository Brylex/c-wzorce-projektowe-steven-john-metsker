namespace Aster 
{
    /// <summary>
    /// Klasa steruj¹ca fikcyjn¹ pras¹ gwiazdow¹ Aster i wspomagaj¹ca
    /// komunikacjê z fabryk¹, w której prasa siê znajduje. W rzeczywistoœci
    /// klasa jest pretekstem do pokazania sposobu, w który klient móg³by
    /// dostarczyæ metodê szablonow¹.
    /// 
    /// Klasa jest opisana w rozdziale Template Method.
    /// </summary>
    public abstract class AsterStarPress 
    {
        protected int _currentMoldID;

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
        /// <param name="id">identyfikator niekompletnej formy</param>
        public abstract void MarkMoldIncomplete(int id);

        /// <summary>
        /// Wstrzymanie przetwarzania, oznaczenie bie¿¹cej formy jako 
        /// niekompletnej, usuniêcie z maszyny wszystkich form, wyrzucenie
        /// przygotowanej pasty i zlanie powierzchni roboczej wod¹.
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
        /// Przesuniêcie wszystkich form na taœmê wyjœciow¹.
        /// </summary>
        public virtual void UsherInputMolds()
        {
        }
    }
}
