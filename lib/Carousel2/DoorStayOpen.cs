namespace Carousel2
{
    /// <summary>
    /// Modeluje zachowanie drzwi karuzeli, gdy otrzymaj¹ polecenie
    /// otwarcia na sta³e.
    /// </summary>
    public class DoorStayOpen : DoorState 
    { 
        /// <summary>
        /// Zamkniêcie drzwi.
        /// </summary>
        public override void Touch(Door door)
        {
            door.SetState(DoorState.CLOSING);
        }
    }
}
