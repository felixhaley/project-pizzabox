using PizzaBox.Domain.Models;
using Xunit;

namespace PizzaBox.Testing.Tests
{
    public class StoreTests
    {
        [Fact]
        public void Test_ChicagoStore()
        {
            // arrange
            var sut = new ChicagoStore();

            // act
            var actual = sut.Name;

            // assert
            Assert.True(actual == "ChicagoStore");
        }

        [Fact]
        public void Test_NewYorkStore()
        {

            var sut = new NewYorkStore();

            var actual = sut.Name;

            Assert.True(actual == "NewYorkStore");
        }
    }
}