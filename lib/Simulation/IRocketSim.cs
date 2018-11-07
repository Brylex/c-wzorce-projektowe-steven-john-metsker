namespace Simulation 
{
    /// <summary>
    /// Definicja interfejsu u�ywanego przez nasz symulator do modelowania
    /// osi�g�w rakiet.
    /// </summary>
    public interface IRocketSim
    {
        /// <summary>
        /// Zwraca mas� symulowanej rakiety (w kilogramach) w okre�lonym
        /// momencie.
        /// </summary>
        /// <returns>mas� rakiety w okre�lonym momencie</returns>
        double GetMass();
        /// <summary>
        /// Zwraca ci�g (w niutonach na sekund�) generowany przez symulowan�
        /// rakiet�.
        /// </summary>
        /// <returns>Ci�g w niutonach na sekund�</returns>
        double GetThrust();
        /// <summary>
        /// Aktualizacja czasu symulacji na podstawie zegara symulacji.
        /// </summary>
        /// <param name="t">bie��cy czas zegara symulacji</param>
        void SetSimTime(double t);
    }
}