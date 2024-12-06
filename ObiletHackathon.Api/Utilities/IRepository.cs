using ObiletHackathon.Api.Entities;

namespace ObiletHackathon.Api.Utilities
{
    public interface IRepository
    {
        ReservationResponse CreateReservation(ReservationRequest request);
        IEnumerable<Journey> GetJourneys(JourneyRequest request);
        IEnumerable<Point> GetPoints(PointRequest request);
    }
}