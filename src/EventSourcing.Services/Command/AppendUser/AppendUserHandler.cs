using EventSourcing.Services.Models;
using Marten;
using MediatR;

namespace EventSourcing.Services.Command.AppendUser;

public class AppendUserHandler : IRequestHandler<AppendUserRequest, bool>
{
    private readonly IDocumentSession _documentSession;
    
    public AppendUserHandler(IDocumentSession documentSession)
    {
        _documentSession = documentSession;
    }
    public async Task<bool> Handle(AppendUserRequest request, CancellationToken cancellationToken)
    {
        var result = _documentSession.Events.Append(request.Id, new User()
        {
            EmailAddress = request.EmailAddress,
            IsDeleted = request.IsDeleted,
            LastName = request.LastName,
            Name = request.Name
        });

       await _documentSession.SaveChangesAsync();

       return true;
    }
}