using System;
using System.Collections;

namespace Processes
{
    /// <summary>
    /// Reprezentuje alternacjê (mo¿liwoœæ wyboru) etapów procesów.
    /// </summary>
    public class ProcessAlternation : ProcessComposite 
    {
        /// <summary>
        /// Tworzy alternacjê o zadanej nazwie.
        /// </summary>
        /// <param name="name">nazwa alternacji procesu</param>
        public ProcessAlternation(String name) : base(name)
        {
        }
        /// <summary>
        /// Tworzy alternacjê o zadanej nazwie, zawieraj¹c¹ zadane podprocesy.
        /// </summary>
        /// <param name="name">nazwa alternacji</param>
        /// <param name="subprocesses">podprocesy alternacji</param>
        public ProcessAlternation(
            String name,
            params ProcessComponent[] subprocesses) : base (name, subprocesses)
        {
        }
        /// <summary>
        /// Tworzy alternacjê o zadanej nazwie, zawieraj¹c¹ zadane podprocesy.
        /// </summary>
        /// <param name="name">nazwa alternacji</param>
        /// <param name="subprocesses">podprocesy alternacji</param>
        public ProcessAlternation(String name, IList subprocesses) : 
            base(name, subprocesses)
        {
        }
        /// <summary>
        /// Zaczep pozwalaj¹cy goœciom dodawaæ operacje do kompozytu procesów.
        /// Chodzi o to, by odwo³aæ siê z powrotem do goœcia wskazuj¹c 
        /// jednoczeœnie typ wêz³a, czyli ProcessAlternation.
        /// </summary>
        /// <param name="v"></param>
        public override void Accept(IProcessVisitor v)
        {
            v.Visit(this);
        }
    }
}
