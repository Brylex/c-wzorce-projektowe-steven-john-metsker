using System;
using System.Collections;
using Machines;
namespace RobotInterpreter2
{
    /// <summary>
    /// Klasa odpowiada p�tli "for", wykonuj�cej sw� zawarto�� dla ka�dej
    /// maszyny w ramach dostarczonego kompozytu. W ka�dym przebiegu 
    /// p�tli, zmienna jest przypisywana innej maszynie.
    /// </summary>
    public class ForCommand : Command 
    {
        protected MachineComponent _root;
        protected Variable _variable;
        protected Command _body;

        /// <summary>
        /// Konstrukcja interpretera "for", wykonuj�cego dostarczon� 
        /// zawarto�� p�tli, przechodz�cemu po kolejnych maszynach w danym
        /// kontek�cie i przypisuj�cego ka�dej maszynie dostarczon� zmienn�.
        /// </summary>
        /// <param name="root">komponent maszyn do iterowania</param>
        /// <param name="v">zmienna ustawiana w ramach p�tli</param>
        /// <param name="body">zawarto�� p�tli</param>
        public ForCommand(MachineComponent mc, Variable v, Command body)
        {
            _root = mc;
            _variable = v;
            _body = body;
        }

        /// <summary>
        /// Dla ka�dej maszyny w danym kontek�cie, przypisz zmienn� obiektu
        /// do maszyny i wykonaj zawarto�� obiektu (czyli p�tl�).
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
