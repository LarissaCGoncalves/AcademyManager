namespace AcademyManager.Shared.Entities;

public abstract class Entity
{
    public int Id { get; protected set; }
    public DateTime CreatedAt { get; protected set; }
    public DateTime UpdatedAt { get; protected set; }
    public DateTime? DeletedAt { get; protected set; }

    // Acess Method
    public void SetDeletedAt() => DeletedAt = DateTime.Now;
}
