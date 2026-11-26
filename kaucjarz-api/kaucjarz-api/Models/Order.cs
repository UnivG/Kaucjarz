using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace kaucjarz_api.Models;

[Table("orders")]
public class Order
{
    [Key]
    [Column("id_order")]
    public int orderId { get; set; }
    [Column("user_id")]
    public int userId { get; set; }
    [Column("courier_id")]
    public int? courier_id { get; set; }
    [Column("city")]
    public string city { get; set; }
    [Column("street_address")]
    public string street_address { get; set; }
    [Column("flat_nr")]
    public string? flat_nr { get; set; }
    [Column("estimated_bottles")]
    public int estimated_bottles { get; set; }
    [Column("status")]
    public OrderStatus status { get; set; }
    [Column("pickup_date")]
    public DateOnly pickup_date { get; set; }
    [Column("pickup_time_slot")]
    public string pickup_time_slot { get; set; }
    [Column("user_payout")]
    public decimal? user_payout { get; set; }
    [Column("courier_payout")]
    public decimal? courier_payout { get; set; }
    [Column("app_fee")]
    public decimal? app_fee { get; set; }
    [Column("details")]
    public string? details { get; set; }

}

public enum OrderStatus
{
    OPEN=0,
    ASSIGNED=1,
    PICKED_UP=2,
    COMPLETED=3,
    CANCELLED=4
}