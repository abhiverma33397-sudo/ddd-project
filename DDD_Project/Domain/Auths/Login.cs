using Domain.Users;
using System.ComponentModel.DataAnnotations.Schema;

public class Login
{
    public int Id { get; set; }

    public string UserName { get; set; }

    public string Password { get; set; }

    public bool IsVerified { get; set; } = false;

    [ForeignKey("User")] 
    public int UserId { get; set; }
    public User User { get; set; }   
}