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
      _context.Add(order);
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
    /*
        public static List<Order> GetOrders(Customer cust)
        {
          var orders2 = from r in _context.Customers
                        join ro in _context.Orders on r.EntityId equals ro.StoreEntityId
                        where r.Name == store.Name
                        select r;

          return orders2.ToList();


        }
        */
  }
}
