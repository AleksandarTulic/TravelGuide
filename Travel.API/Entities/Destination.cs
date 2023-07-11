namespace Travel.API.Entities
{
    public class Destination {
        public int Id { get; set; }
        public int LocationId {get; set;}
        public string Name { get; set; } = "";

        public virtual ICollection<DestinationTrip> DestinationTrips { get; set; }
    }
}
