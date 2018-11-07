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
        /// Zaczep pozwalaj�cy go�ciom dodawa� operacje do kompozytu proces�w.
        /// Chodzi o to, by odwo�a� si� z powrotem do go�cia wskazuj�c 
        /// jednocze�nie typ w�z�a, czyli ProcessStep.
        /// </summary>
        /// <param name="v"></param>
        public override void Accept(IProcessVisitor v)
        {
            v.Visit(this);
        }
        /// <summary>
        /// Zwraca enumerator, kt�ry po prostu zwr�ci bie��cy etap.
        /// </summary>
        /// <param name="visited">zbi�r odwiedzonych w�z��w</param>
        /// <returns>enumerator, kt�ry po prostu zwr�ci bie��cy etap</returns>
        public override ComponentEnumerator GetEnumerator(Set visited)
        {
            return new LeafEnumerator(this, visited);
        }
        /// <summary>
        /// Zwraca liczb� etap�w w ramach bie��cego etapu, czyli 1.
        /// </summary>
        /// <param name="visited">komponenty odwiedzone podczas przechodzenia
        /// bie��cego komponentu</param>
        /// <returns>1, czyli liczb� etap�w w tym etapie</returns>
        public override int GetStepCount(Hashtable visited)
        {
            visited.Add(_name, this);
            return 1;
        }
    }
}
