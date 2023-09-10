namespace scavenger_hunt_webapi.Entities;

public class BaseEntity
{
    public DateTime Created { get; set; } = DateTime.UtcNow;
    public DateTime Updated { get; set; } = DateTime.UtcNow;
}
