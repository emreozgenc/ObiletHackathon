
namespace ObiletHackathon.Api.Entities
{
    public interface IRepository
    {
        IEnumerable<ReservationResponse> CreateReservation(ReservationRequest request);
        IEnumerable<Journey> GetJourneys(JourneyRequest request);
        IEnumerable<Point> GetPoints(PointRequest request);
    }
}