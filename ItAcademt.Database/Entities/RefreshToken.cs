namespace ItAcademy.Database.Entities;

public class RefreshToken : IEntity
{
    public Guid Id { get; set; }
    public bool IsRevoked { get; set; }
    public string DeviceInfo {get; set; }
    public DateTime? ExpireDateTime {get; set; }
    
    
    public Guid UserId { get; set; }
    public User User { get; set; }
}