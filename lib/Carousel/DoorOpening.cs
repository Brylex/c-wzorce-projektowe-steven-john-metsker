namespace Carousel
{
    /// <summary>
    /// Klasa modeluje zachowanie otwieraj�cych si� drzwi karuzeli.
    /// </summary>
    public class DoorOpening : DoorState 
    {
        /// <summary>
        /// Konstrukcja stanu dostarczonych drzwi.
        /// </summary>
        /// <param name="door">drzwi wymagaj�ce modelu stanu</param>
        public DoorOpening(Door2 door) : base (door)
        {
        }

        /// <summary>
        /// Otwieranie zosta�o zako�czone, wi�c drzwi s� otwarte.
        /// </summary>
        public override void Complete()
        {
            _door.SetState(_door.OPEN);
        }

        /// <summary>
        /// Zamykanie drzwi po naci�ni�ciu przycisku.
        /// </summary>
        public override void Touch()
        {
            _door.SetState(_door.CLOSING);
        }
    }
}
