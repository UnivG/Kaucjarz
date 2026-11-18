using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace kaucjarz_api.Models;
[Table("users")]
public class User
{
    [Key]
    [Column("id")]
    public int userId{get;set;}
    public string email{get;set;}
    public string name{get;set;}
    public string password{get;set;}
}