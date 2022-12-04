namespace EventSourcing.Api.Models;

public class AppendUser
{
    public string Name { get; set; } = default!;
    public string LastName { get; set; } = default!;
    public string EmailAddress { get; set; } = default!;
    public bool IsDeleted { get; set; } = default!;
}