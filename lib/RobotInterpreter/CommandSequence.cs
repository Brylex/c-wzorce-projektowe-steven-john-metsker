using System;
using System.Collections;
using System.Text;

namespace RobotInterpreter
{
    /// <summary>
    /// Klasa zawieraj¹ca sekwencjê poleceñ.
    /// </summary>
    public class CommandSequence : Command 
    {
        protected IList _commands = new ArrayList();

        /// <summary>
        /// Dodaje polecenie do sekwencji poleceñ, dla której ten obiekt
        /// wykona kaskadowo metodê Execute().
        /// </summary>
        /// <param name="c">dodawane polecenie</param>
        public void AddCommand(Command c)
        {
            _commands.Add(c);
        }

        /// <summary>
        /// Zwraca tekstowy opis sekwencji poleceñ.
        /// </summary>
        /// <returns>tekstowy opis tej sekwencji poleceñ</returns>
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
        /// Wykonanie kolejnych poleceñ w sekwencji.
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
