namespace Carousel2
{
    /// <summary>
    /// Klasa modeluje zachowanie otwartych drzwi karuzeli.
    /// </summary>
    public class DoorOpen : DoorState 
    {
        /// <summary>
        /// Rozpoczêcie zamykania, jeœli drzwi s¹ otwarte, a aparatura
        /// drzwi wyœle sygna³ przekroczenia dopuszczalnego czasu.
        /// </summary>
        public override void Timeout(Door door)
        {
            door.SetState(DoorState.CLOSING);
        }

        /// <summary>
        /// Nieco nieintuicyjne zachowanie przycisku wielofunkcyjnego. Gdy
        /// drzwi s¹ otwarte, zaczn¹ siê automatycznie zamykaæ po kilku 
        /// sekundach. Mo¿na temu zapobiec jeszcze raz naciskaj¹c przycisk,
        /// co zasygnalizuje, ¿e drzwi maj¹ pozostaæ otwarte.
        /// </summary>
        public override void Touch(Door door)
        {
            door.SetState(DoorState.STAYOPEN);
        }
    }
}
