namespace EventSourcing.Services.Models;

public record CreateAccount
{
    // public Guid Id;
    public bool SetupAccount { get; set; } 
}
