using System;
using System.Collections;

namespace Processes
{
    /// <summary>
    /// Reprezentuje sekwencj� etap�w procesu.
    /// </summary>
    public class ProcessSequence : ProcessComposite 
    {
        /// <summary>
        /// Tworzy sekwencj� o zadanej nazwie.
        /// </summary>
        /// <param name="name">nazwa sekwencji proces�w</param>
        public ProcessSequence(String name) : base(name)
        {
        }
        /// <summary>
        /// Tworzy sekwencj� o zadanej nazwie, zawieraj�c� zadane podprocesy.
        /// </summary>
        /// <param name="name">nazwa sekwencji</param>
        /// <param name="subprocesses">podprocesy sekwencji</param>
        public ProcessSequence(
            String name, params ProcessComponent[] subprocesses) : 
            base(name, subprocesses)
        {
        }
        /// <summary>
        /// Tworzy sekwencj� o zadanej nazwie, zawieraj�c� zadane podprocesy.
        /// </summary>
        /// <param name="name">nazwa sekwencji</param>
        /// <param name="subprocesses">podprocesy sekwencji</param>
        public ProcessSequence(String name, IList subprocesses) : 
            base(name, subprocesses)
        {
        }
        /// <summary>
        /// Zaczep pozwalaj�cy go�ciom dodawa� operacje do kompozytu proces�w.
        /// Chodzi o to, by odwo�a� si� z powrotem do go�cia wskazuj�c 
        /// jednocze�nie typ w�z�a, czyli ProcessAlternation.
        /// ProcessSequence.
        /// </summary>
        /// <param name="v"></param>
        public override void Accept(IProcessVisitor v)
        {
            v.Visit(this);
        }
    }
}
