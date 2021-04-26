using System.Collections.Generic;
using PizzaBox.Domain.Abstracts;

namespace PizzaBox.Domain.Models.Pizzas
{
  /// <summary>
  /// 
  /// </summary>
  public class CustomPizza : APizza
  {
    /// <summary>
    /// 
    /// </summary>
    public override void AddCrust(Crust crust = null)
    {
      Crust = crust ?? new Crust() { Name = "Thin", Price = 4 };
    }

    /// <summary>
    /// 
    /// </summary>
    public override void AddSize(Size size = null)
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
        new Topping() { Name = "Mozzarella", Price = 1 },
        new Topping() { Name = "Marinara", Price = 1 }
      };
    }

    public void NewTopping(Topping t)
    {
      Toppings.Add(t);
    }

    public override void SetName()
    {
      Name = "Custom Pizza";
    }
  }
}
