using System;
namespace RobotInterpreter2
{
    /// <summary>
    /// Klasa reprezentuje pêtlê "while", której zawartoœæ bêdzie wykonywana
    /// tak d³ugo, jak d³ugo wartoœæ zadanego terminu jest ró¿na od null.
    /// </summary>
    public class WhileCommand : Command 
    {
        protected Term _term;
        protected Command _body;

        /// <summary>
        /// Konstrukcja polecenia "while", wykonuj¹cego sw¹ zawartoœæ 
        /// tak d³ugo, jak d³ugo wartoœæ zadanego terminu jest ró¿na od null.
        /// </summary>
        /// <param name="_term">termin sprawdzany przy ka¿dym przebiegu pêtli</param>
        /// <param name="body">wykonywana zawartoœæ</param>
        public WhileCommand(Term term, Command body)
        {
            _term = term;
            _body = body;
        }

        /// <summary>
        /// Sprawdzenie wartoœci terminu. Jeœli jest ona ró¿na od null,
        /// wykonywana jest zawartoœæ polecenia i tak w kó³ko.
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
