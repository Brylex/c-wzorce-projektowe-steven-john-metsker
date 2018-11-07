namespace Carousel
{
    /// <summary>
    /// Klasa modeluje zachowanie otwieraj¹cych siê drzwi karuzeli.
    /// </summary>
    public class DoorOpening : DoorState 
    {
        /// <summary>
        /// Konstrukcja stanu dostarczonych drzwi.
        /// </summary>
        /// <param name="door">drzwi wymagaj¹ce modelu stanu</param>
        public DoorOpening(Door2 door) : base (door)
        {
        }

        /// <summary>
        /// Otwieranie zosta³o zakoñczone, wiêc drzwi s¹ otwarte.
        /// </summary>
        public override void Complete()
        {
            _door.SetState(_door.OPEN);
        }

        /// <summary>
        /// Zamykanie drzwi po naciœniêciu przycisku.
        /// </summary>
        public override void Touch()
        {
            _door.SetState(_door.CLOSING);
        }
    }
}
