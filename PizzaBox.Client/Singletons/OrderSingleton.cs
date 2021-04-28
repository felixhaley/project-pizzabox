using System.Collections.Generic;
using System.Linq;
using PizzaBox.Domain.Abstracts;
using PizzaBox.Domain.Models;
using PizzaBox.Storing;

namespace PizzaBox.Client.Singletons
{


  public class OrderSingleton
  {
    private static OrderSingleton _instance;
    private readonly static PizzaBoxContext _context = new PizzaBoxContext();

    public static OrderSingleton Instance
    {
      get
      {
        if (_instance == null)
        {
          _instance = new OrderSingleton();
        }

        return _instance;
      }
    }

    public AStore FetchStore(AStore store)
    {
      var st = _context.Stores.FirstOrDefault(s => s.Name == store.Name);
      return st;
    }
    public static void Update(Order order)
    {
      _context.Orders.Add(order);
      _context.SaveChanges();
    }

    public Customer FetchCustomer(Customer customer)
    {
      var cust = _context.Customers.FirstOrDefault(c => c.Name == customer.Name);
      if (cust == null)
        return customer;
      else
        return cust;
    }

    public Crust FetchCrust(Crust crust)
    {
      var cr = _context.Crusts.FirstOrDefault(c => c.Name == crust.Name);
      if (cr == null)
        return crust;
      else
        return cr;
    }

    public Size FetchSize(Size size)
    {
      var sz = _context.Sizes.FirstOrDefault(s => s.Name == size.Name);
      if (sz == null)
        return size;
      else
        return sz;
    }

    /*    public APizza FetchPizza(APizza pizza)
        {
          var pz = _context.Pizzas.FirstOrDefault(p => p.Name == pizza.Name);
          if (pz == null)
            return pizza;
          else
            return pz;
        }*/

    public List<Order> GetOrders(Customer cust)
    {
      var orders = from r in _context.Customers
                   join ro in _context.Orders on r.EntityId equals ro.CustomerEntityId
                   where r.Name == cust.Name
                   select ro;

      return orders.ToList();
    }

    public List<APizza> GetPizzas(Order order)
    {
      var pizzas = from r in _context.Pizzas
                   join ro in _context.Orders on r.OrderEntityId equals ro.EntityId
                   where ro.EntityId == order.EntityId
                   select r;

      return pizzas.ToList();
    }
  }
}
