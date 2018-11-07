using System;
using System.Collections;
using Machines;
namespace RobotInterpreter2
{
    /// <summary>
    /// Klasa odpowiada pêtli "for", wykonuj¹cej sw¹ zawartoœæ dla ka¿dej
    /// maszyny w ramach dostarczonego kompozytu. W ka¿dym przebiegu 
    /// pêtli, zmienna jest przypisywana innej maszynie.
    /// </summary>
    public class ForCommand : Command 
    {
        protected MachineComponent _root;
        protected Variable _variable;
        protected Command _body;

        /// <summary>
        /// Konstrukcja interpretera "for", wykonuj¹cego dostarczon¹ 
        /// zawartoœæ pêtli, przechodz¹cemu po kolejnych maszynach w danym
        /// kontekœcie i przypisuj¹cego ka¿dej maszynie dostarczon¹ zmienn¹.
        /// </summary>
        /// <param name="root">komponent maszyn do iterowania</param>
        /// <param name="v">zmienna ustawiana w ramach pêtli</param>
        /// <param name="body">zawartoœæ pêtli</param>
        public ForCommand(MachineComponent mc, Variable v, Command body)
        {
            _root = mc;
            _variable = v;
            _body = body;
        }

        /// <summary>
        /// Dla ka¿dej maszyny w danym kontekœcie, przypisz zmienn¹ obiektu
        /// do maszyny i wykonaj zawartoœæ obiektu (czyli pêtlê).
        /// </summary>
        public override void Execute()
        {
            Execute(_root);
        } 
        private void Execute(MachineComponent mc) 
        {
            Machine m = mc as Machine;
            if (m != null)
            {
                _variable.Assign(new Constant(m));
                _body.Execute();
                return;
            }
            MachineComposite comp = mc as MachineComposite;
            foreach (MachineComponent child in comp.Children)
            {
                Execute(child);
            }
        } 
    }
}
