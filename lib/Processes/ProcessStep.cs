using System;
using System.Collections;
using Enumerators;
using Utilities;
namespace Processes
{
    /// <summary>
    /// Reprezentuje pojedynczy etap procesu.
    /// </summary>
    public class ProcessStep : ProcessComponent 
    {
        /// <summary>
        /// Tworzy etap o zadanej nazwie.
        /// </summary>
        /// <param name="name">nazwa etapu procesu</param>
        public ProcessStep(String name) : base(name)
        {
        }
        /// <summary>
        /// Zaczep pozwalaj¹cy goœciom dodawaæ operacje do kompozytu procesów.
        /// Chodzi o to, by odwo³aæ siê z powrotem do goœcia wskazuj¹c 
        /// jednoczeœnie typ wêz³a, czyli ProcessStep.
        /// </summary>
        /// <param name="v"></param>
        public override void Accept(IProcessVisitor v)
        {
            v.Visit(this);
        }
        /// <summary>
        /// Zwraca enumerator, który po prostu zwróci bie¿¹cy etap.
        /// </summary>
        /// <param name="visited">zbiór odwiedzonych wêz³ów</param>
        /// <returns>enumerator, który po prostu zwróci bie¿¹cy etap</returns>
        public override ComponentEnumerator GetEnumerator(Set visited)
        {
            return new LeafEnumerator(this, visited);
        }
        /// <summary>
        /// Zwraca liczbê etapów w ramach bie¿¹cego etapu, czyli 1.
        /// </summary>
        /// <param name="visited">komponenty odwiedzone podczas przechodzenia
        /// bie¿¹cego komponentu</param>
        /// <returns>1, czyli liczbê etapów w tym etapie</returns>
        public override int GetStepCount(Hashtable visited)
        {
            visited.Add(_name, this);
            return 1;
        }
    }
}
