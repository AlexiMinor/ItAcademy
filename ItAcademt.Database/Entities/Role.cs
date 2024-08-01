namespace ItAcademy.Database.Entities;

public class Role : IEntity
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    
    public List<User> Users { get; set; }
}