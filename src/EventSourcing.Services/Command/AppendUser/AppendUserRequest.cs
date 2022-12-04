using MediatR;

namespace EventSourcing.Services.Command.AppendUser;

public class AppendUserRequest : IRequest<bool>
{
    public Guid Id { get; set; } = default!;
    public string Name { get; set; } = default!;
    public string LastName { get; set; } = default!;
    public string EmailAddress { get; set; } = default!;
    public bool IsDeleted { get; set; } = default!;
}