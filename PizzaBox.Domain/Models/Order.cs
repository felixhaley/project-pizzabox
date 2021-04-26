using System;
using System.Collections.Generic;
using System.Linq;
using PizzaBox.Domain.Abstracts;

namespace PizzaBox.Domain.Models
{
  public class Order : AModel
  {
    public Customer Customer { get; set; }
    public AStore Store { get; set; }
    //public APizza Pizza { get; set; }
    public List<APizza> Pizzas { get; set; }

    public decimal Total { get; set; }
    public DateTime OrderDate { get; set; }
    public long CustomerEntityId { get; set; }

    /*
        public decimal TotalCost
        {
         get
          {
           return Pizza.Crust.Price + Pizza.Size.Price + Pizza.Toppings.Sum(t => t.Price);
         }
        }
    */
    public Order()
    {
      Pizzas = new List<APizza>();
      Total = 0;
      OrderDate = DateTime.Today;
    }
    public void AddPizza(APizza pizza)
    {
      Pizzas.Add(pizza);
      Total += pizza.Crust.Price + pizza.Size.Price + pizza.Toppings.Sum(t => t.Price);
    }

    /*
        public decimal GetPrice()
        {
          decimal total = 0;
          foreach (var item in Pizzas)
            total = total + (item.Crust.Price + item.Size.Price + item.Toppings.Sum(t => t.Price));
          return total;
        }*/
  }
}
