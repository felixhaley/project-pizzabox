using PizzaBox.Domain.Abstracts;

namespace PizzaBox.Domain.Models
{
  /// <summary>
  /// 
  /// </summary>
  public class Crust : AComponent
  {
    public void SetPrice()
    {
      if (Name.Equals("Thin"))
      {
        Price = 4;
      }
      else if (Name.Equals("Stuffed"))
      {
        Price = 6;
      }
      else if (Name.Equals("Deep Dish"))
      {
        Price = 5;
      }
    }
  }
}
