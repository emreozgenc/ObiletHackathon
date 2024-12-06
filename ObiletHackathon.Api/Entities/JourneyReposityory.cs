using Dapper;
using ObiletHackathon.Api.Utilities;
using System.Data;


namespace ObiletHackathon.Api.Entities
{
    public class JourneyReposityory : IRepository
    {
        internal DatabaseConnectionFactory _connectionFactory { get; set; }
        public JourneyReposityory(DatabaseConnectionFactory dbConnectionFactory)
        {
            _connectionFactory = dbConnectionFactory;

        }

        public IEnumerable<Journey> GetJourneys(JourneyRequest request)
        {
            using (IDbConnection dbConnection = _connectionFactory.GetConnection())
            {
                string query = "SELECT * FROM Journeys WHERE OriginId = @OriginId AND DestinationId = @DestinationId AND Date = @JourneyDate ";
                return dbConnection.Query<Journey>(query, new { request.OriginId, request.DestinationId, request.SearchDate });
            }
        }

        public IEnumerable<Point> GetPoints(PointRequest request)
        {
            using (IDbConnection dbConnection = _connectionFactory.GetConnection())
            {
                string query = "SELECT * FROM Points ";
                return dbConnection.Query<Point>(query);
            }
        }

        public ReservationResponse CreateReservation(ReservationRequest request)
        {
            using (IDbConnection dbConnection = _connectionFactory.GetConnection())
            {
                var isSuccessful = false;
                using (var tran = dbConnection.BeginTransaction())
                {
                    string query = "Insert INTO Passengers (JourneyId,Name,Surname) VALUES (@JourneyId, @PassengerName, @PassengerSurname)";
                    try
                    {
                        foreach (var passenger in request.Passengers)
                        {
                            var result = dbConnection.Execute(query, new { request.JourneyId, passenger.Name, passenger.Surname });
                            if (result < 1)
                                throw new Exception("");
                        }
                        tran.Commit();
                        isSuccessful = true;
                    }
                    catch (Exception)
                    {
                        tran.Rollback();
                        isSuccessful = false;
                    }
                }
                return new ReservationResponse { IsSuccess = isSuccessful };
            }
        }
    }
}
