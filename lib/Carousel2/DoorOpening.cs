namespace Carousel2
{
    /// <summary>
    /// Klasa modeluje zachowanie otwieraj�cych si� drzwi karuzeli.
    /// </summary>
    public class DoorOpening : DoorState 
    {
        /// <summary>
        /// Otwieranie zosta�o zako�czone, wi�c drzwi s� otwarte.
        /// </summary>
        public override void Complete(Door door)
        {
            door.SetState(DoorState.OPEN);
        }

        /// <summary>
        /// Zamykanie drzwi po naci�ni�ciu przycisku.
        /// </summary>
        public override void Touch(Door door)
        {
            door.SetState(DoorState.CLOSING);
        }
    }
}
