namespace EntityFrameworkCoreSamples.Models
{
  public partial class SpecialProduct
  {
    public long Id { get; set; }
    public string ProductName { get; set; } = string.Empty;
    public double Price { get; set; }
  }
}
