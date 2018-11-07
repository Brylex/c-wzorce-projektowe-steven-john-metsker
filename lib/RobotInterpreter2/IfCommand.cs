using System;
namespace RobotInterpreter2
{
    /// <summary>
    /// Klasa reprezentuje wyra�enie warunkowe, wykonuj�ce jedno z dw�ch
    /// polece� w zale�no�ci od warto�ci dostarczonego terminu.
    /// </summary>
    public class IfCommand : Command 
    {
        protected Term _term;
        protected Command _body;
        protected Command _elseBody;

        /// <summary>
        /// Konstrukcja polecenia "if" wykonuj�cego swoj� zawarto�� "else"
        /// je�li warto�ci� dostarczonego terminu jest null, w przeciwnym
        /// przypadku wykonuj�cego swoj� zwyk�� zawarto��.
        /// </summary>
        /// <param name="term">termin s�u��cy do ustalenia zawarto�ci do
        /// wykonania</param>
        /// <param name="body">zawarto�� wykonywana je�li termin jest prawd�</param>
        /// <param name="elseBody">zawarto�� wykonywana je�li termin jest fa�szem</param>
        public IfCommand(Term term, Command body, Command elseBody)
        {
            _term = term;
            _body = body;
            _elseBody = elseBody;
        }

        /// <summary>
        /// Wykonuje zawarto�� "else" obiektu, je�li warto�ci� terminu jest 
        /// null. W przeciwnym razie wykonuje zawarto�� g��wn�.
        /// </summary>
        public override void Execute()
        {
            if (_term.Eval() != null)
            {
                _body.Execute();
            }
            else
            {
                _elseBody.Execute();
            }
        }
    }
}
