using System;
namespace Processes
{
    /// <summary>
    /// Klasa stanowi�ca model obiektowy stosowanego w Oozinoz procesu
    /// wytwarzania petardy powietrznej.
    /// </summary>
    public class ShellProcess 
    {
        protected static ProcessSequence make;
        /// <summary>
        /// Zwraca model obiektowy stosowanego w Oozinoz procesu
        /// wytwarzania petardy powietrznej.
        /// </summary>
        /// <returns>model obiektowy stosowanego w Oozinoz procesu
        /// wytwarzania petardy powietrznej</returns>
        public static ProcessSequence Make()
        {
            if (make == null)
            {
                make = new ProcessSequence("Budowa petardy powietrznej");
                make.Add(BuildInnerShell());
                make.Add(Inspect());
                make.Add(ReworkOrFinish());
            }
            return make;
        }
        protected static ProcessStep BuildInnerShell()
        {
            return new ProcessStep("Budowa �adunku wewn�trznego");
        }
        protected static ProcessStep Inspect()
        {
            return new ProcessStep("Inspekcja");
        }
        protected static ProcessAlternation ReworkOrFinish()
        {
            return new ProcessAlternation(
                "Poprawianie �adunku wewn�trznego lub doko�czenie petardy", Rework(), Finish());
        }
        protected static ProcessSequence Rework()
        {
            return new ProcessSequence("Poprawianie", Disassemble(), Make());
        }
        protected static ProcessStep Disassemble()
        {
            return new ProcessStep("Demonta�");
        }
        protected static ProcessStep Finish()
        {
            return new ProcessStep("Koniec: do��czenie �adunku wynosz�cego, w�o�enie lont�w, zapakowanie");
        }
    }
}
