using System.ComponentModel.DataAnnotations;

namespace shoestore.Models
{
  public class Shoe
  {
    public int Id { get; set; }
    [Required]
    public decimal Price { get; set; }
    [Required]
    [MinLength(4)]
    public string Brand { get; set; }
    public int Size { get; set; }
    public string Style { get; set; }
  }
}