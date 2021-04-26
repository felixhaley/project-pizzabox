using System.Collections.Generic;
using PizzaBox.Domain.Abstracts;

namespace PizzaBox.Domain.Models.Pizzas
{
  /// <summary>
  /// 
  /// </summary>
  public class VeggiePizza : APizza
  {
    /// <summary>
    /// 
    /// </summary>
    public override void AddCrust(Crust crust)
    {
      Crust = crust ?? new Crust() { Name = "Thin", Price = 4 };
    }

    /// <summary>
    /// 
    /// </summary>
    public override void AddSize(Size size)
    {
      Size = size;
    }

    /// <summary>
    /// 
    /// </summary>
    public override void AddToppings(params Topping[] toppings)
    {
      Toppings = new List<Topping>()
      {
        new Topping() { Name = "Mushrooms", Price = 1 },
        new Topping() { Name = "Onion", Price = 1 },
        new Topping() { Name = "Mozzarella", Price = 1 },
        new Topping() { Name = "Marinara", Price = 1 }
      };
    }

    public override void SetName()
    {
      Name = "Veggie Pizza";
    }
  }
}
