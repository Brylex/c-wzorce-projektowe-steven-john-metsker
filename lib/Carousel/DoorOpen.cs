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
        /// <param name="door">drzwi wymagaj�ce modelu stanu</param>
        public DoorOpen(Door2 door) : base (door)
        {
        }

        /// <summary>
        /// Rozpocz�cie zamykania, je�li drzwi s� otwarte, a aparatura
        /// drzwi wy�le sygna� przekroczenia dopuszczalnego czasu.
        /// </summary>
        public override void Timeout()
        {
            _door.SetState(_door.CLOSING);
        }

        /// <summary>
        /// Nieco nieintuicyjne zachowanie przycisku wielofunkcyjnego. Gdy
        /// drzwi s� otwarte, zaczn� si� automatycznie zamyka� po kilku 
        /// sekundach. Mo�na temu zapobiec jeszcze raz naciskaj�c przycisk,
        /// co zasygnalizuje, �e drzwi maj� pozosta� otwarte.
        /// </summary>
        public override void Touch()
        {
            _door.SetState(_door.STAYOPEN);
        }
    }
}
