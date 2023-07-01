﻿namespace scavenger_hunt_webapi.Models;

public class Team : BaseEntity
{
    public int Id { get; set; }
    public Guid Guid { get; set; }
    public List<User> Users { get; set; }
    
    public int GameId { get; set; }
    public Game Game { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public string ImageUrl { get; set; }
    public User Owner { get; set; }
}