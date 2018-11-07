using System;
namespace Processes
{
    /// <summary>
    /// Interfejs definiuje typ obiektu akceptowanego przez etapy i kompozyty
    /// proces�w. Klasy hierarchii ProcessComponent odwo�uj� si� z powrotem do
    /// metod Visit() obiektu-go�cia, identyfikuj�c zarazem sw�j typ. Klasy
    /// implementuj�ce ten interfejs mog� dostarcza� r�ne algorytmy dla
    /// r�nych typ�w komponent�w procesu. 
    /// </summary>
    public interface IProcessVisitor 
    {
        /// <summary>
        /// Odwiedzenie alternacji procesu.
        /// </summary>
        /// <param name="a">odwiedzana alternacja procesu</param>
        void Visit(ProcessAlternation a);
        /// <summary>
        /// Odwiedzenie sekwencji proces�w.
        /// </summary>
        /// <param name="s">odwiedzana sekwencja proces�w</param>
        void Visit(ProcessSequence s);
        /// <summary>
        /// Odwiedzenie etapu procesu.
        /// </summary>
        /// <param name="s">odwiedzany etap procesu</param>
        void Visit(ProcessStep s);
    }
}
