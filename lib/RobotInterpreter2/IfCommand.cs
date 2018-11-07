using System;
namespace RobotInterpreter2
{
    /// <summary>
    /// Klasa reprezentuje wyra¿enie warunkowe, wykonuj¹ce jedno z dwóch
    /// poleceñ w zale¿noœci od wartoœci dostarczonego terminu.
    /// </summary>
    public class IfCommand : Command 
    {
        protected Term _term;
        protected Command _body;
        protected Command _elseBody;

        /// <summary>
        /// Konstrukcja polecenia "if" wykonuj¹cego swoj¹ zawartoœæ "else"
        /// jeœli wartoœci¹ dostarczonego terminu jest null, w przeciwnym
        /// przypadku wykonuj¹cego swoj¹ zwyk³¹ zawartoœæ.
        /// </summary>
        /// <param name="term">termin s³u¿¹cy do ustalenia zawartoœci do
        /// wykonania</param>
        /// <param name="body">zawartoœæ wykonywana jeœli termin jest prawd¹</param>
        /// <param name="elseBody">zawartoœæ wykonywana jeœli termin jest fa³szem</param>
        public IfCommand(Term term, Command body, Command elseBody)
        {
            _term = term;
            _body = body;
            _elseBody = elseBody;
        }

        /// <summary>
        /// Wykonuje zawartoœæ "else" obiektu, jeœli wartoœci¹ terminu jest 
        /// null. W przeciwnym razie wykonuje zawartoœæ g³ówn¹.
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
