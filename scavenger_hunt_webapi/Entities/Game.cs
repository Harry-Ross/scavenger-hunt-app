namespace scavenger_hunt_webapi.Models;

public class Game : BaseEntity
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public string EntryCode { get; set; }
    public DateTime Start { get; set; }
    public DateTime End { get; set; }
    public double Longitude { get; set; }
    public double Latitude { get; set; }
    public ICollection<User> Users { get; set; } = new List<User>();
    public ICollection<Team> Teams { get; set; } = new List<Team>();
    public ICollection<Post> Posts { get; set; } = new List<Post>();
}
