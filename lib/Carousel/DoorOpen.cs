namespace Carousel
{
    /// <summary>
    /// Klasa modeluje zachowanie otwartych drzwi karuzeli.
    /// </summary>
    public class DoorOpen : DoorState 
    {
        /// <summary>
        /// Konstrukcja stanu dostarczonych drzwi.
        /// </summary>
        /// <param name="door">drzwi wymagaj¹ce modelu stanu</param>
        public DoorOpen(Door2 door) : base (door)
        {
        }

        /// <summary>
        /// Rozpoczêcie zamykania, jeœli drzwi s¹ otwarte, a aparatura
        /// drzwi wyœle sygna³ przekroczenia dopuszczalnego czasu.
        /// </summary>
        public override void Timeout()
        {
            _door.SetState(_door.CLOSING);
        }

        /// <summary>
        /// Nieco nieintuicyjne zachowanie przycisku wielofunkcyjnego. Gdy
        /// drzwi s¹ otwarte, zaczn¹ siê automatycznie zamykaæ po kilku 
        /// sekundach. Mo¿na temu zapobiec jeszcze raz naciskaj¹c przycisk,
        /// co zasygnalizuje, ¿e drzwi maj¹ pozostaæ otwarte.
        /// </summary>
        public override void Touch()
        {
            _door.SetState(_door.STAYOPEN);
        }
    }
}
