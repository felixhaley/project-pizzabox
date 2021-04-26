using PizzaBox.Domain.Abstracts;

namespace PizzaBox.Domain.Models
{
  public class Topping : AComponent
  {

    public Topping()
    {
      Price = 1;
    }
    public Topping(string name)
    {
      Name = name;
      Price = 1;
    }
  }
}
