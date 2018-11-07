using System;
namespace RobotInterpreter2
{
    /// <summary>
    /// Klasa reprezentuje p�tl� "while", kt�rej zawarto�� b�dzie wykonywana
    /// tak d�ugo, jak d�ugo warto�� zadanego terminu jest r�na od null.
    /// </summary>
    public class WhileCommand : Command 
    {
        protected Term _term;
        protected Command _body;

        /// <summary>
        /// Konstrukcja polecenia "while", wykonuj�cego sw� zawarto�� 
        /// tak d�ugo, jak d�ugo warto�� zadanego terminu jest r�na od null.
        /// </summary>
        /// <param name="_term">termin sprawdzany przy ka�dym przebiegu p�tli</param>
        /// <param name="body">wykonywana zawarto��</param>
        public WhileCommand(Term term, Command body)
        {
            _term = term;
            _body = body;
        }

        /// <summary>
        /// Sprawdzenie warto�ci terminu. Je�li jest ona r�na od null,
        /// wykonywana jest zawarto�� polecenia i tak w k�ko.
        /// </summary>
        public override void Execute()
        {
            while (_term.Eval() != null)
            {
                _body.Execute();
            }
        }
    }
}
