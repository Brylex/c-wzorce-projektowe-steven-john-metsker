namespace Carousel2
{
    /// <summary>
    /// Klasa modeluje zachowanie otwartych drzwi karuzeli.
    /// </summary>
    public class DoorOpen : DoorState 
    {
        /// <summary>
        /// Rozpocz�cie zamykania, je�li drzwi s� otwarte, a aparatura
        /// drzwi wy�le sygna� przekroczenia dopuszczalnego czasu.
        /// </summary>
        public override void Timeout(Door door)
        {
            door.SetState(DoorState.CLOSING);
        }

        /// <summary>
        /// Nieco nieintuicyjne zachowanie przycisku wielofunkcyjnego. Gdy
        /// drzwi s� otwarte, zaczn� si� automatycznie zamyka� po kilku 
        /// sekundach. Mo�na temu zapobiec jeszcze raz naciskaj�c przycisk,
        /// co zasygnalizuje, �e drzwi maj� pozosta� otwarte.
        /// </summary>
        public override void Touch(Door door)
        {
            door.SetState(DoorState.STAYOPEN);
        }
    }
}
