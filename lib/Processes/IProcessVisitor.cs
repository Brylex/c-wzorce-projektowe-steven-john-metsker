using System;
namespace Processes
{
    /// <summary>
    /// Interfejs definiuje typ obiektu akceptowanego przez etapy i kompozyty
    /// procesów. Klasy hierarchii ProcessComponent odwo³uj¹ siê z powrotem do
    /// metod Visit() obiektu-goœcia, identyfikuj¹c zarazem swój typ. Klasy
    /// implementuj¹ce ten interfejs mog¹ dostarczaæ ró¿ne algorytmy dla
    /// ró¿nych typów komponentów procesu. 
    /// </summary>
    public interface IProcessVisitor 
    {
        /// <summary>
        /// Odwiedzenie alternacji procesu.
        /// </summary>
        /// <param name="a">odwiedzana alternacja procesu</param>
        void Visit(ProcessAlternation a);
        /// <summary>
        /// Odwiedzenie sekwencji procesów.
        /// </summary>
        /// <param name="s">odwiedzana sekwencja procesów</param>
        void Visit(ProcessSequence s);
        /// <summary>
        /// Odwiedzenie etapu procesu.
        /// </summary>
        /// <param name="s">odwiedzany etap procesu</param>
        void Visit(ProcessStep s);
    }
}
