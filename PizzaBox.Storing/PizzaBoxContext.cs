using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using PizzaBox.Domain.Abstracts;
using PizzaBox.Domain.Models;
using PizzaBox.Domain.Models.Pizzas;
using PizzaBox.Domain.Models.Stores;

namespace PizzaBox.Storing
{
  /// <summary>
  /// 
  /// </summary>
  public class PizzaBoxContext : DbContext
  {
    private readonly IConfiguration _configuration;

    public DbSet<AStore> Stores { get; set; }
    public DbSet<APizza> Pizzas { get; set; }
    public DbSet<Customer> Customers { get; set; }
    public DbSet<Size> Sizes { get; set; }
    public DbSet<Order> Orders { get; set; }
    public DbSet<Crust> Crusts { get; set; }

    /// <summary>
    /// 
    /// </summary>
    public PizzaBoxContext()
    {
      _configuration = new ConfigurationBuilder().AddUserSecrets<PizzaBoxContext>().Build();
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="builder"></param>
    protected override void OnConfiguring(DbContextOptionsBuilder builder)
    {
      builder.UseSqlServer(_configuration["mssql"]);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="builder"></param>
    protected override void OnModelCreating(ModelBuilder builder)
    {
      builder.Entity<AStore>().HasKey(e => e.EntityId);
      builder.Entity<ChicagoStore>().HasBaseType<AStore>();
      builder.Entity<NewYorkStore>().HasBaseType<AStore>();

      builder.Entity<APizza>().HasKey(e => e.EntityId);
      builder.Entity<CustomPizza>().HasBaseType<APizza>();
      builder.Entity<MeatPizza>().HasBaseType<APizza>();
      builder.Entity<VeggiePizza>().HasBaseType<APizza>();

      builder.Entity<Crust>().HasKey(e => e.EntityId);
      builder.Entity<Order>().HasKey(e => e.EntityId);
      builder.Entity<Size>().HasKey(e => e.EntityId);
      builder.Entity<Topping>().HasKey(e => e.EntityId);

      builder.Entity<Customer>().HasKey(e => e.EntityId);

      //builder.Entity<Size>().HasMany<APizza>().WithOne(); // orm is creating the has
      //builder.Entity<APizza>().HasOne<Size>().WithMany();
      //builder.Entity<Order>().HasOne<Customer>();

      builder.Entity<ChicagoStore>().HasData(new ChicagoStore[]
      {
        new ChicagoStore() { EntityId = 1, Name = "Greek's Pizzeria" }
      });

      builder.Entity<NewYorkStore>().HasData(new NewYorkStore[]
      {
        new NewYorkStore() { EntityId = 2, Name = "Pizza King" }
      });

      builder.Entity<NewYorkStore>().HasData(new NewYorkStore[]
      {
        new NewYorkStore() { EntityId = 3, Name = "Al's Pizza" }
      });

      //builder.Entity<Customer>().HasData(new Customer[]
      //{
      //  new Customer() { EntityId = 1, Name = "Uncle John" }
      //});
      /*
            builder.Entity<Topping>().HasData(new Topping[]
            {
              new Topping() { EntityId = 1, Name = "Mozzarella" }
            });

            builder.Entity<Topping>().HasData(new Topping[]
            {
              new Topping() { EntityId = 2, Name = "Marinara" }
            });

            builder.Entity<Topping>().HasData(new Topping[]
            {
              new Topping() { EntityId = 3, Name = "Pepperoni" }
            });

            builder.Entity<Topping>().HasData(new Topping[]
            {
              new Topping() { EntityId = 4, Name = "Mushrooms" }
            });

            builder.Entity<Topping>().HasData(new Topping[]
            {
              new Topping() { EntityId = 5, Name = "Onion" }
            });

            builder.Entity<Topping>().HasData(new Topping[]
            {
              new Topping() { EntityId = 6, Name = "Sausage" }
            });

      builder.Entity<CustomPizza>().HasData(new CustomPizza[]
      {
              new CustomPizza() { EntityId = 1, Name = "Custom Pizza" }
      });

      builder.Entity<MeatPizza>().HasData(new MeatPizza[]
      {
              new MeatPizza() { EntityId = 2, Name = "Meat Pizza" }
      });

      builder.Entity<VeggiePizza>().HasData(new VeggiePizza[]
{
              new VeggiePizza() { EntityId = 3, Name = "Veggie Pizza" }
});*/

      builder.Entity<Size>().HasData(new Size[]
      {
              new Size() { EntityId = 1, Name = "Small", Price = 3 }
      });

      builder.Entity<Size>().HasData(new Size[]
{
              new Size() { EntityId = 2, Name = "Medium", Price = 5 }
});
      builder.Entity<Size>().HasData(new Size[]
      {
              new Size() { EntityId = 3, Name = "Large", Price = 9 }
      });

      builder.Entity<Crust>().HasData(new Crust[]
{
              new Crust() { EntityId = 1, Name = "Thin", Price = 4 }
});

      builder.Entity<Crust>().HasData(new Crust[]
{
              new Crust() { EntityId = 2, Name = "Stuffed", Price = 5 }
});
      builder.Entity<Crust>().HasData(new Crust[]
{
              new Crust() { EntityId = 3, Name = "Deep Dish", Price = 6 }
});
    }
  }
}
