namespace scavenger_hunt_webapi.Models;

public class Post : BaseEntity
{
    public int Id { get; set; }
    public int UserId { get; set; }
    public User User { get; set; } = null!;
    public int GameId { get; set; }
    public Game Game { get; set; } = null!;
    public string Content { get; set; }
    public int? ActivityId { get; set; }
    public string[]? Images { get; set; }
}
