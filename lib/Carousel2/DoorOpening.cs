namespace Carousel2
{
    /// <summary>
    /// Klasa modeluje zachowanie otwieraj¹cych siê drzwi karuzeli.
    /// </summary>
    public class DoorOpening : DoorState 
    {
        /// <summary>
        /// Otwieranie zosta³o zakoñczone, wiêc drzwi s¹ otwarte.
        /// </summary>
        public override void Complete(Door door)
        {
            door.SetState(DoorState.OPEN);
        }

        /// <summary>
        /// Zamykanie drzwi po naciœniêciu przycisku.
        /// </summary>
        public override void Touch(Door door)
        {
            door.SetState(DoorState.CLOSING);
        }
    }
}
