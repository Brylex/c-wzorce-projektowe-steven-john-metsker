using System;
using System.Collections;

namespace Processes
{
    /// <summary>
    /// Reprezentuje sekwencjê etapów procesu.
    /// </summary>
    public class ProcessSequence : ProcessComposite 
    {
        /// <summary>
        /// Tworzy sekwencjê o zadanej nazwie.
        /// </summary>
        /// <param name="name">nazwa sekwencji procesów</param>
        public ProcessSequence(String name) : base(name)
        {
        }
        /// <summary>
        /// Tworzy sekwencjê o zadanej nazwie, zawieraj¹c¹ zadane podprocesy.
        /// </summary>
        /// <param name="name">nazwa sekwencji</param>
        /// <param name="subprocesses">podprocesy sekwencji</param>
        public ProcessSequence(
            String name, params ProcessComponent[] subprocesses) : 
            base(name, subprocesses)
        {
        }
        /// <summary>
        /// Tworzy sekwencjê o zadanej nazwie, zawieraj¹c¹ zadane podprocesy.
        /// </summary>
        /// <param name="name">nazwa sekwencji</param>
        /// <param name="subprocesses">podprocesy sekwencji</param>
        public ProcessSequence(String name, IList subprocesses) : 
            base(name, subprocesses)
        {
        }
        /// <summary>
        /// Zaczep pozwalaj¹cy goœciom dodawaæ operacje do kompozytu procesów.
        /// Chodzi o to, by odwo³aæ siê z powrotem do goœcia wskazuj¹c 
        /// jednoczeœnie typ wêz³a, czyli ProcessAlternation.
        /// ProcessSequence.
        /// </summary>
        /// <param name="v"></param>
        public override void Accept(IProcessVisitor v)
        {
            v.Visit(this);
        }
    }
}
