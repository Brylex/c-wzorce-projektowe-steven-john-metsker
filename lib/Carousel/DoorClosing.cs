namespace Carousel
{
    /// <summary>
    /// Klasa modeluje zachowanie zamykaj�cych si� drzwi karuzeli.
    /// </summary>
    public class DoorClosing : DoorState 
    {
        /// <summary>
        /// Konstrukcja stanu dostarczonych drzwi.
        /// </summary>
        /// <param name="door">drzwi wymagaj�ce modelu stanu</param>
        public DoorClosing(Door2 door) : base (door)
        {
        }

        /// <summary>
        /// Drzwi zosta�y zamkni�te.
        /// </summary>
        public override void Complete()
        {
            _door.SetState(_door.CLOSED);
        }

        /// <summary>
        /// Otwarcie drzwi.
        /// </summary>
        public override void Touch()
        {
            _door.SetState(_door.OPENING);
        }
    }
}
