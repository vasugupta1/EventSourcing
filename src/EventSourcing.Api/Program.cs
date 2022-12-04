using EventSourcing.Api.Models;
using EventSourcing.Services;
using EventSourcing.Services.Command.AppendUser;
using EventSourcing.Services.Command.CreateUser;
using EventSourcing.Services.Query.GetUser;
using Marten;
using MediatR;
using Microsoft.AspNetCore.Mvc;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddMarten(options => {
    options.Connection(builder.Configuration.GetConnectionString("postgres"));
});

builder.Services.AddMediatR(typeof(EventSourcingServicesAnchor).Assembly);

var app = builder.Build();

app.MapPost("/create", async ([FromBody]CreateUser user, [FromServices]IMediator mediator) =>
{
    var response = await mediator.Send(new CreateUserRequest()
    {
        EmailAddress = user.EmailAddress,
        IsDeleted = false,
        LastName = user.LastName,
        Name = user.Name
    });
    return response; 
});

app.MapGet("/getUser/{id}", async (Guid id, [FromServices]IMediator mediator) =>
{
    var response = await mediator.Send(new GetUserRequest()
    {
        Id = id
    });
    return response; 
});

app.MapPut("/appendUser/{id}", async (Guid id,[FromBody] AppendUser user, [FromServices] IMediator mediator) =>
{
    var response = await mediator.Send(new AppendUserRequest()
    {
        Id = id,
        EmailAddress = user.EmailAddress,
        IsDeleted = user.IsDeleted,
        LastName = user.LastName,
        Name = user.Name
    });
    return response;
});


app.Run();