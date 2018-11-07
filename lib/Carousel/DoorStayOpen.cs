namespace Carousel
{
    /// <summary>
    /// Modeluje zachowanie drzwi karuzeli, gdy otrzymaj� polecenie
    /// otwarcia na sta�e.
    /// </summary>
    public class DoorStayOpen : DoorState 
    { 
        /// <summary>
        /// Konstrukcja stanu dostarczonych drzwi.
        /// </summary>
        /// <param name="door">drzwi wymagaj�ce modelu stanu</param>
        public DoorStayOpen(Door2 door) : base (door)
        {
        }
        /// <summary>
        /// Zamkni�cie drzwi.
        /// </summary>
        public override void Touch()
        {
            _door.SetState(_door.CLOSING);
        }
    }
}
