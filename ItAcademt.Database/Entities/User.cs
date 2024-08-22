namespace ItAcademy.Database.Entities;

public class User : IEntity
{
    public Guid Id { get; set; }
    public string Email { get; set; } //login
    public string PasswordHash { get; set; } //4555c48003b6e5f0455ccad6038cb592
    public string SecurityStamp { get; set; } //4555c48003b6e5f0455ccad6038cb592
    
    public Guid RoleId { get; set; }
    public Role Role { get; set; }
    
    public List<RefreshToken> RefreshTokens { get; set; }
}