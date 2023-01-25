namespace Ewone.Domain.DataLayer.User;

public class UserEntity
{
    public Guid Id { get; set; }
    public string Email { get; set; } = null!;
    public string? Name { get; set; }
    public DateTime CreateDate { get; set; }
}