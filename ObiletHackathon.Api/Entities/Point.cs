namespace ObiletHackathon.Api.Entities
{
    public class Point : IEntity
    {
        public int Id { get; set; }
        public required string Name { get; set; }
    }
}
