using EventSourcing.Services.Models;

namespace EventSourcing.Services.Aggregate;

public class UserAggregate
{
    public Guid Id { get; set; }
    public string UserName { get; set; }

    public string LastName { get; set; }
    
    public string EmailAddress { get; set; }
    
    public bool IsDeleted { get; set; }
    
    public void Apply(User @user)
    {
        UserName = @user.Name;
        LastName = @user.LastName;
        EmailAddress = @user.EmailAddress;
        IsDeleted = @user.IsDeleted;
    }
}