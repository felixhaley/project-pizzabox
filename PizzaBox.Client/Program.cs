using System.Collections.Generic;
using PizzaBox.Domain.Abstracts;
using PizzaBox.Domain.Models;
using System;
using sc = System.Console; //alias

namespace PizzaBox.Client
  {
  public class Program
  {
      private static void Main()
      {
          List<string> storeList = new List<string>{ "Store 001", "Store 002" };
          var stores = new List<AStore>{ new ChicagoStore(), new NewYorkStore() };

          for (var x = 0; x < stores.Count; x += 1)
          {
              sc.WriteLine($"{x} {stores[x]}"); //string interpolation
          }

          sc.WriteLine("make a selection");
          string input = sc.ReadLine();
          int entry = int.Parse(input);

          sc.WriteLine(stores[entry]);
      }
  }
}