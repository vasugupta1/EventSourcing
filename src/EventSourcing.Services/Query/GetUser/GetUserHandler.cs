using EventSourcing.Services.Aggregate;
using Marten;
using MediatR;

namespace EventSourcing.Services.Query.GetUser;

public class GetUserHandler : IRequestHandler<GetUserRequest, GetUserResponse>
{
    private readonly IDocumentSession _documentSession;
    
    public GetUserHandler(IDocumentSession documentSession)
    {
        _documentSession = documentSession;
    }
    public async Task<GetUserResponse> Handle(GetUserRequest request, CancellationToken cancellationToken)
    {
        var @event = await _documentSession.Events.AggregateStreamAsync<UserAggregate>(request.Id);
        return new GetUserResponse(@event.UserName, @event.LastName, @event.EmailAddress, @event.IsDeleted);
    }
}