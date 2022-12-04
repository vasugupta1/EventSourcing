using MediatR;

namespace EventSourcing.Services.Command.CreateUser;

public record CreateUserRequest : IRequest<CreateUserResponse>
{
    public string Name { get; set; } = default!;
    public string LastName { get; set; } = default!;
    public string EmailAddress { get; set; } = default!;
    public bool IsDeleted { get; set; } = default!;
    
}
