﻿namespace scavenger_hunt_webapi.DTOs;
public class RegisterInput
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
    public string? ProfileImageUrl { get; set; }
}
