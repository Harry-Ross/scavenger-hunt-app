namespace scavenger_hunt_webapi.DTOs;
public class AuthResponse
{
    public string Token { get; set; } = string.Empty;
    public int Expires { get; set; }
}
