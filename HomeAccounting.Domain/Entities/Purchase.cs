using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HomeAccounting.Domain.Entities;

public class Purchase
{
    [Key]
    public int Id { get; set; }
    [ForeignKey("PurchaseCategory")]
    public int CategoryId { get; set; }
    [ForeignKey("User")]
    public int CreatorUserId { get; set; }
    public int Amount { get; set; }
    public string? Comment { get; set; }
    public DateTimeOffset Date { get; set; }
}