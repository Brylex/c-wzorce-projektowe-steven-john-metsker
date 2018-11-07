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
        /// Konstrukcja wyj�tku BuilderException bez szczeg�owego komunikatu.
        /// </summary>
        public BuilderException() : base()
        {
        }
        /// <summary>
        /// Konstrukcja wyj�tku BuilderException z podanym komunikatem.
        /// </summary>
        /// <param name="s">szczeg�owy komunikat</param>
        public BuilderException(String s) : base(s)
        {
        }
    }
}
