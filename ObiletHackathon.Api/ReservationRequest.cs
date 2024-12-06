using ObiletHackathon.Api.Entities;

namespace ObiletHackathon.Api
{
    public class ReservationRequest
    {
        public int JourneyId { get; set; }
        public List<Passenger> Passengers { get; set; }
    }
}
