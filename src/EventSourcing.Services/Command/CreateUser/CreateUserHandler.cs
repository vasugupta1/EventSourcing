using EventSourcing.Services.Models;
using Marten;
using MediatR;

namespace EventSourcing.Services.Command.CreateUser;

public class CreateUserHandler : IRequestHandler<CreateUserRequest, CreateUserResponse>
{
    private readonly IDocumentSession _documentSession;
    
    public CreateUserHandler(IDocumentSession documentSession)
    {
        _documentSession = documentSession;
    }
    
    public async Task<CreateUserResponse> Handle(CreateUserRequest request, CancellationToken cancellationToken)
    {
        var user = new User()
        {
            // Id = request.Id,
            EmailAddress = request.EmailAddress,
            IsDeleted = false,
            LastName = request.LastName,
            Name = request.Name
        };
        var setupAccount = new CreateAccount()
        {
            // Id = request.Id,
            SetupAccount = false
        };
        var id = _documentSession.Events.StartStream(user, setupAccount).Id;
        await _documentSession.SaveChangesAsync(cancellationToken);
        return new CreateUserResponse(id);
    }
}