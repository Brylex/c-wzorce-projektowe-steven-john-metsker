using System;
using System.Collections;
using System.Text;

namespace RobotInterpreter
{
    /// <summary>
    /// Klasa zawieraj�ca sekwencj� polece�.
    /// </summary>
    public class CommandSequence : Command 
    {
        protected IList _commands = new ArrayList();

        /// <summary>
        /// Dodaje polecenie do sekwencji polece�, dla kt�rej ten obiekt
        /// wykona kaskadowo metod� Execute().
        /// </summary>
        /// <param name="c">dodawane polecenie</param>
        public void AddCommand(Command c)
        {
            _commands.Add(c);
        }

        /// <summary>
        /// Zwraca tekstowy opis sekwencji polece�.
        /// </summary>
        /// <returns>tekstowy opis tej sekwencji polece�</returns>
        public override String ToString()
        {
            StringBuilder sb = new StringBuilder();
            bool needLine = false;
            foreach (Command c in _commands) 
            {
                if (needLine)
                {
                    sb.Append("\n");
                }
                sb.Append(c);
                needLine = true;
            }
            return sb.ToString();
        }

        /// <summary>
        /// Wykonanie kolejnych polece� w sekwencji.
        /// </summary>
        public override void Execute()
        {
            foreach (Command c in _commands)
            {
                c.Execute();
            }
        }
    }
}
