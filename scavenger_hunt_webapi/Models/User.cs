namespace scavenger_hunt_webapi.Models;
public class User : BaseEntity
{
    public int Id { get; set; }
    public Guid Guid { get; set; }
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string Password { get; set; } = string.Empty;
    public string ProfileImageUrl { get; set; } = string.Empty;

    public ICollection<Game> Games { get; set; } = new List<Game>();
    public ICollection<Team> Teams { get; set; } = new List<Team>();
    public ICollection<Post> Posts { get; set; } = new List<Post>();
}