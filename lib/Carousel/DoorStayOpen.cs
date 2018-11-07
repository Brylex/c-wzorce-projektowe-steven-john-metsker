namespace Carousel
{
    /// <summary>
    /// Modeluje zachowanie drzwi karuzeli, gdy otrzymaj¹ polecenie
    /// otwarcia na sta³e.
    /// </summary>
    public class DoorStayOpen : DoorState 
    { 
        /// <summary>
        /// Konstrukcja stanu dostarczonych drzwi.
        /// </summary>
        /// <param name="door">drzwi wymagaj¹ce modelu stanu</param>
        public DoorStayOpen(Door2 door) : base (door)
        {
        }
        /// <summary>
        /// Zamkniêcie drzwi.
        /// </summary>
        public override void Touch()
        {
            _door.SetState(_door.CLOSING);
        }
    }
}
