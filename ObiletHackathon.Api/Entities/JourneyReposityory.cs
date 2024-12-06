using ObiletHackathon.Api.Utilities;

namespace ObiletHackathon.Api.Entities
{
    public class JourneyReposityory:IRepository
    {
        internal DatabaseConnectionFactory _connectionFactory { get; set; }
        public JourneyReposityory(DatabaseConnectionFactory dbConnectionFactory)
        {
            _connectionFactory = dbConnectionFactory;

        }

        public IEnumerable<Journey> GetJourneys(JourneyRequest request)
        {            
            return Enumerable.Empty<Journey>();
        }

        public IEnumerable<Point> GetPoints(PointRequest request)
        {
            return Enumerable.Empty<Point>();
        }

        public IEnumerable<ReservationResponse> CreateReservation(ReservationRequest request)
        {
            return Enumerable.Empty<ReservationResponse>();
        }
    }
}
