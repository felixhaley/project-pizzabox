using System.Collections.Generic;
using PizzaBox.Domain.Abstracts;
using PizzaBox.Domain.Models;
using Xunit;

namespace PizzaBox.Testing.Tests
{
  public class CustomerTests
  {
    public static IEnumerable<object[]> values = new List<object[]>()
    {
      new object[] { new Customer() },
    };

    [Fact]
    public void Test_CustomerName()
    {
      var sut = new Customer();
      sut.Name = "test customer";

      Assert.True(sut.Name == "test customer");
      Assert.True(sut.ToString() == "test customer");
    }

    [Fact]
    public void Test_CustomerConstructor()
    {
      var sut = new Customer("test");
      Assert.True(sut.Name == "test");
    }
  }
}