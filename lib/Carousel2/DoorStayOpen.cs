namespace Carousel2
{
    /// <summary>
    /// Modeluje zachowanie drzwi karuzeli, gdy otrzymaj� polecenie
    /// otwarcia na sta�e.
    /// </summary>
    public class DoorStayOpen : DoorState 
    { 
        /// <summary>
        /// Zamkni�cie drzwi.
        /// </summary>
        public override void Touch(Door door)
        {
            door.SetState(DoorState.CLOSING);
        }
    }
}
