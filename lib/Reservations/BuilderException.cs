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
        /// Konstrukcja wyjątku BuilderException bez szczegółowego komunikatu.
        /// </summary>
        public BuilderException() : base()
        {
        }
        /// <summary>
        /// Konstrukcja wyjątku BuilderException z podanym komunikatem.
        /// </summary>
        /// <param name="s">szczegółowy komunikat</param>
        public BuilderException(String s) : base(s)
        {
        }
    }
}
