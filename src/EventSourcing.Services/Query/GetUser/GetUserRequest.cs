using MediatR;

namespace EventSourcing.Services.Query.GetUser;

public record GetUserRequest : IRequest<GetUserResponse>
{
    public Guid Id { get; set; }
}