using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace kaucjarz_api.Models;
[Table("users")]
public class User
{
    [Key]
    [Column("id")]
    public int userId{get;set;}
    [Column("email")]
    public string email{get;set;}
    [Column("name")]
    public string name{get;set;}
    [Column("password")]
    public string password{get;set;}
}