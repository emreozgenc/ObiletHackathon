namespace ObiletHackathon.Api.Entities
{
    public class Passenger: IEntity
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Surname { get; set; }
    }
}
