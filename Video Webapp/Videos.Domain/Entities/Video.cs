namespace Videos.Domain.Entities;

public class Video : BaseEntity
{
    public string Title { get; set; }
    public string Description { get; set; }
    public string Category { get; set; }
}