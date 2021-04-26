using System;
using PizzaBox.Domain.Abstracts;
using PizzaBox.Domain.Models;
using PizzaBox.Client.Singletons;
using PizzaBox.Storing;
using PizzaBox.Domain.Models.Pizzas;
using System.Collections.Generic;

namespace PizzaBox.Client
{
  /// <summary>
  /// 
  /// </summary>
  public class Program
  {
    private static readonly PizzaSingleton _pizzaSingleton = PizzaSingleton.Instance;
    private static readonly StoreSingleton _storeSingleton = StoreSingleton.Instance;
    private static readonly OrderSingleton _orderSingleton = OrderSingleton.Instance;

    /// <summary>
    /// 
    /// </summary>
    private static void Main()
    {
      Run();
    }

    /// <summary>
    /// 
    /// </summary>
    private static void Run()
    {
      var order = new Order();

      Console.WriteLine("Welcome to PizzaBox\r\n");
      order.Customer = GetCustomer();
      var Continue = true;
      PrintStoreList();

      order.Store = SelectStore();
      while (Continue)
      {
        PrintPizzaList();
        order.AddPizza(SelectPizza());

        Console.WriteLine("\r\nWould you like to add another pizza to your order? Y or N");
        var answer = Console.ReadLine();
        if (!(answer == "Y" || answer == "y"))
          Continue = false;
      }
      Console.WriteLine("\r\nYour order is:");
      PrintOrder(order);
      Console.WriteLine($"And your total is: ${string.Format("{0:#.00}", order.Total)}\r\n");
      Console.WriteLine($"Thank you for your order, {order.Customer}!\r\n");
      OrderSingleton.Update(order);
    }

    /// <summary>
    /// 
    /// </summary>
    private static void PrintOrder(Order FullOrder)
    {
      var index = 0;
      foreach (var item in FullOrder.Pizzas)
        Console.WriteLine($"{++index}: {item.Size} - {item.Crust} - {item}");
    }

    /// <summary>
    /// 
    /// </summary>
    private static void PrintPizzaList()
    {
      Console.WriteLine("\r\nWhich pizza would you like to add to your order?");
      var index = 0;

      foreach (var item in _pizzaSingleton.Pizzas)
      {
        Console.WriteLine($"{++index} - {item}");
      }
    }

    /// <summary>
    /// 
    /// </summary>
    private static void PrintStoreList()
    {
      var index = 0;
      Console.WriteLine("\r\nPlease select from the following stores:");

      foreach (var item in _storeSingleton.Stores)
      {
        Console.WriteLine($"{++index} - {item}");
      }
    }

    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    private static APizza SelectPizza()
    {
      var valid = int.TryParse(Console.ReadLine(), out int input);

      if (!valid)
      {
        return null;
      }


      var pizza = _pizzaSingleton.Pizzas[input - 1];

      if (input == 1)
        CustomToppings((CustomPizza)pizza);

      Console.WriteLine("\r\nWhat size pizza would you like?");
      Console.WriteLine("1 - Small ($3)\r\n2 - Medium ($5)\r\n3 - Large ($9)");
      var choice = Console.ReadLine();
      if (choice == "1")
        pizza.AddSize(new Size() { Name = "Small", Price = 3 });
      else if (choice == "3")
        pizza.AddSize(new Size() { Name = "Large", Price = 9 });
      else
        pizza.AddSize(new Size() { Name = "Medium", Price = 5 });

      Console.WriteLine("\r\nWhat type of crust would you like?");
      Console.WriteLine("1 - Thin ($4)\r\n2 - Stuffed ($5)\r\n3 - Deep Dish ($6)");
      choice = Console.ReadLine();
      if (choice == "2")
        pizza.AddCrust(new Crust() { Name = "Stuffed", Price = 5 });
      else if (choice == "3")
        pizza.AddCrust(new Crust() { Name = "Deep Dish", Price = 6 });
      else
        pizza.AddCrust(new Crust() { Name = "Thin", Price = 4 });
      return pizza;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    private static AStore SelectStore()
    {
      var valid = int.TryParse(Console.ReadLine(), out int input);

      if (!valid)
      {
        return null;
      }

      AStore store = _storeSingleton.Stores[input - 1];
      store = _orderSingleton.FetchStore(store);
      return store;
    }

    private static Customer GetCustomer()
    {

      Console.WriteLine("Please enter your name: ");


      string s = new System.Globalization.CultureInfo("en-US").TextInfo.ToTitleCase(Console.ReadLine());
      var name = new Customer(s);
      return (_orderSingleton.FetchCustomer(name));
    }

    public static void CustomToppings(CustomPizza pizza)
    {
      var looping = true;

      while (looping)
      {
        Console.WriteLine("\r\nWould you like to add any toppings to this pizza? ($1 per topping)");
        Console.WriteLine("\r\n1 - Mozzarella\r\n2 - Marinara\r\n3 - Pepperoni\r\n4 - Mushrooms\r\n5 - Onion\r\n6 - Sausage\r\n0 - Finished");
        switch (Console.ReadLine())
        {
          case "0":
            looping = false;
            break;
          case "1":
            pizza.NewTopping(new Topping() { Name = "Mozzarella", Price = 1 });
            break;
          case "2":
            pizza.NewTopping(new Topping() { Name = "Marinara", Price = 1 });
            break;
          case "3":
            pizza.NewTopping(new Topping() { Name = "Pepperoni", Price = 1 });
            break;
          case "4":
            pizza.NewTopping(new Topping() { Name = "Mushrooms", Price = 1 });
            break;
          case "5":
            pizza.NewTopping(new Topping() { Name = "Onion", Price = 1 });
            break;
          case "6":
            pizza.NewTopping(new Topping() { Name = "Sausage", Price = 1 });
            break;
          default: break;
        }
        Console.WriteLine(pizza);
      }
    }
  }
}
