
namespace ObiletHackathon.Api.Entities
{
    public interface IRepository
    {
        ReservationResponse CreateReservation(ReservationRequest request);
        IEnumerable<Journey> GetJourneys(JourneyRequest request);
        IEnumerable<Point> GetPoints(PointRequest request);
    }
}