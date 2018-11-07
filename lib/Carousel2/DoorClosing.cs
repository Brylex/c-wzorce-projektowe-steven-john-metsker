namespace Carousel2
{
    /// <summary>
    /// Klasa modeluje zachowanie zamykaj�cych si� drzwi karuzeli.
    /// </summary>
    public class DoorClosing : DoorState 
    {
        /// <summary>
        /// Drzwi zosta�y zamkni�te.
        /// </summary>
        public override void Complete(Door door)
        {
            door.SetState(DoorState.CLOSED);
        }

        /// <summary>
        /// Otwarcie drzwi.
        /// </summary>
        public override void Touch(Door door)
        {
            door.SetState(DoorState.OPENING);
        }
    }
}
