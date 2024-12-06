namespace ObiletHackathon.Api.Entities
{
    public class Journey:IEntity
    {
        public int Id { get; set; }
        public int OriginId { get; set; }
        public int DestinationId { get; set; }
        public DateTime Date { get; set; }
        public short SeatCount { get; set; }        
    }
}
