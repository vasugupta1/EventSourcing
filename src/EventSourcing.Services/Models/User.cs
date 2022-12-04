namespace EventSourcing.Services.Models;

public record User
{
    // public Guid Id { get; set; } = default!;
    public string Name { get; set; } = default!;
    public string LastName { get; set; } = default!;
    public string EmailAddress { get; set; } = default!;
    public bool IsDeleted { get; set; } = default!;
}
