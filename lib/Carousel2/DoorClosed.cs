namespace Carousel2
{
    /// <summary>
    /// Klasa modeluje zachowanie zamkniêtych drzwi karuzeli.
    /// </summary>
    public class DoorClosed : DoorState 
    { 
        /// <summary>
        /// Otwarcie drzwi.
        /// </summary>
        public override void Touch(Door door)
        {
            door.SetState(DoorState.OPENING);
        }
    }
}
