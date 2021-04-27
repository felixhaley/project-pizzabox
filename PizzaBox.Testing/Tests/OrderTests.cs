using System;
using System.Collections.Generic;
using PizzaBox.Domain.Abstracts;
using PizzaBox.Domain.Models;
using PizzaBox.Domain.Models.Pizzas;
using PizzaBox.Domain.Models.Stores;
using Xunit;

namespace PizzaBox.Testing.Tests
{
  public class OrderTests
  {
    public static IEnumerable<object[]> values = new List<object[]>()
    {
      new object[] { new Order() },
    };

    [Fact]
    public void Test_AddPizza()
    {
      var sut = new Order();
      var pizza = new MeatPizza() { Size = new Size() { Name = "Medium", Price = 5 } };
      sut.AddPizza(pizza);
      foreach (var item in sut.Pizzas)
        Assert.True(item is APizza);
    }

    [Fact]
    public void Test_OrderTotal()
    {
      var sut = new Order();
      var pizza = new MeatPizza() { Size = new Size() { Name = "Medium", Price = 5 } };
      sut.AddPizza(pizza);
      Assert.True(sut.Total == 13);
    }

    [Fact]
    public void Test_OrderCustomer()
    {
      var sut = new Order();
      sut.Customer = new Customer() { Name = "testname" };
      Assert.True(sut.Customer.Name == "testname");
    }

    [Fact]
    public void Test_OrderStore()
    {
      var sut = new Order();
      sut.Store = new NewYorkStore() { Name = "Test Store" };

      Assert.True(sut.Store.Name == "Test Store");
    }
  }
}