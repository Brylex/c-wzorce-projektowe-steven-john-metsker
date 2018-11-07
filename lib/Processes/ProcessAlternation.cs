using System;
using System.Collections;

namespace Processes
{
    /// <summary>
    /// Reprezentuje alternacj� (mo�liwo�� wyboru) etap�w proces�w.
    /// </summary>
    public class ProcessAlternation : ProcessComposite 
    {
        /// <summary>
        /// Tworzy alternacj� o zadanej nazwie.
        /// </summary>
        /// <param name="name">nazwa alternacji procesu</param>
        public ProcessAlternation(String name) : base(name)
        {
        }
        /// <summary>
        /// Tworzy alternacj� o zadanej nazwie, zawieraj�c� zadane podprocesy.
        /// </summary>
        /// <param name="name">nazwa alternacji</param>
        /// <param name="subprocesses">podprocesy alternacji</param>
        public ProcessAlternation(
            String name,
            params ProcessComponent[] subprocesses) : base (name, subprocesses)
        {
        }
        /// <summary>
        /// Tworzy alternacj� o zadanej nazwie, zawieraj�c� zadane podprocesy.
        /// </summary>
        /// <param name="name">nazwa alternacji</param>
        /// <param name="subprocesses">podprocesy alternacji</param>
        public ProcessAlternation(String name, IList subprocesses) : 
            base(name, subprocesses)
        {
        }
        /// <summary>
        /// Zaczep pozwalaj�cy go�ciom dodawa� operacje do kompozytu proces�w.
        /// Chodzi o to, by odwo�a� si� z powrotem do go�cia wskazuj�c 
        /// jednocze�nie typ w�z�a, czyli ProcessAlternation.
        /// </summary>
        /// <param name="v"></param>
        public override void Accept(IProcessVisitor v)
        {
            v.Visit(this);
        }
    }
}
