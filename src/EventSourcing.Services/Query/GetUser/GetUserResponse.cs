namespace EventSourcing.Services.Query.GetUser;

public record GetUserResponse(string name, string lastname, string emailAddress, bool isDeleted);