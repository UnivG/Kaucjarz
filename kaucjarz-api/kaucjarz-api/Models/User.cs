using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace kaucjarz_api.Models;
[Table("users")]
public class User
{
    [Key]
    [Column("id_user")]
    public int userId{get;set;}

    [Column("email")]
    public string email{get;set;}
    
    [Column("name")]
    public string name{get;set;}
    
    [Column("password")]
    public string password{get;set;}
    
    [Column("phone")]
    public string? phone{get;set;}
    
    [Column("balance")]
    public decimal balance { get;set;}
    
    [Column("role")]
    public UserRole role { get;set;}
}
public enum UserRole
{
    USER=0,
    ADMIN=1,
    COURIER=2
}