using System;

namespace Reservations
{
    /// <summary>
    /// Sygnalizuje problem napotkany podczas tworzenia obiektu rezerwacji
    /// z otrzymanych danych.
    /// </summary>
    public class BuilderException : Exception 
    {                                
        /// <summary>
        /// Konstrukcja wyj¹tku BuilderException bez szczegó³owego komunikatu.
        /// </summary>
        public BuilderException() : base()
        {
        }
        /// <summary>
        /// Konstrukcja wyj¹tku BuilderException z podanym komunikatem.
        /// </summary>
        /// <param name="s">szczegó³owy komunikat</param>
        public BuilderException(String s) : base(s)
        {
        }
    }
}
