namespace ObiletHackathon.Api
{
    public class JourneyRequest
    {
        public int OriginId { get; set; }
        public int DestinationId { get; set; }
        public DateTime SearchDate { get; set; }        
    }
}
