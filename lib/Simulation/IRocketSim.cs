namespace Simulation 
{
    /// <summary>
    /// Definicja interfejsu u¿ywanego przez nasz symulator do modelowania
    /// osi¹gów rakiet.
    /// </summary>
    public interface IRocketSim
    {
        /// <summary>
        /// Zwraca masê symulowanej rakiety (w kilogramach) w okreœlonym
        /// momencie.
        /// </summary>
        /// <returns>masê rakiety w okreœlonym momencie</returns>
        double GetMass();
        /// <summary>
        /// Zwraca ci¹g (w niutonach na sekundê) generowany przez symulowan¹
        /// rakietê.
        /// </summary>
        /// <returns>Ci¹g w niutonach na sekundê</returns>
        double GetThrust();
        /// <summary>
        /// Aktualizacja czasu symulacji na podstawie zegara symulacji.
        /// </summary>
        /// <param name="t">bie¿¹cy czas zegara symulacji</param>
        void SetSimTime(double t);
    }
}