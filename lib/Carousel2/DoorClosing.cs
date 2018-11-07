namespace Carousel2
{
    /// <summary>
    /// Klasa modeluje zachowanie zamykaj¹cych siê drzwi karuzeli.
    /// </summary>
    public class DoorClosing : DoorState 
    {
        /// <summary>
        /// Drzwi zosta³y zamkniête.
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
