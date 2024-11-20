using System.ComponentModel.DataAnnotations;

namespace HomeAccounting.Domain.Entities;

public class PurchaseCategory
{
    [Key]
    public int Id { get; set; }
    public string Name { get; set; }
    public string Color { get; set; }
}