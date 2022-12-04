namespace EventSourcing.Api.Models;

public class CreateUser
{
    public string Name { get; set; } = default!;
    public string LastName { get; set; } = default!;
    public string EmailAddress { get; set; } = default!;
}