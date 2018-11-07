namespace Carousel
{
    /// <summary>
    /// Klasa modeluje zachowanie zamkniêtych drzwi karuzeli.
    /// </summary>
    public class DoorClosed : DoorState 
    { 
        /// <summary>
        /// Konstrukcja stanu dostarczonych drzwi.
        /// </summary>
        /// <param name="door">drzwi wymagaj¹ce modelu stanu</param>
        public DoorClosed(Door2 door) : base (door)
        {
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
