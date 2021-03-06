using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;
using PizzaBox.Domain.Models;
using PizzaBox.Domain.Models.Pizzas;

namespace PizzaBox.Domain.Abstracts
{
  /// <summary>
  /// 
  /// </summary>
  [XmlInclude(typeof(CustomPizza))]
  [XmlInclude(typeof(MeatPizza))]
  [XmlInclude(typeof(VeggiePizza))]
  public abstract class APizza : AModel
  {
    public string Name { get; set; }
    public Crust Crust { get; set; }
    public Size Size { get; set; }
    //public long SizeEntityId { get; set; }
    public List<Topping> Toppings { get; set; }

    public long OrderEntityId { get; set; }

    /// <summary>
    /// 
    /// </summary>
    protected APizza()
    {
      Factory();
    }

    /// <summary>
    /// 
    /// </summary>
    protected virtual void Factory()
    {
      AddCrust();
      AddSize();
      AddToppings();
      SetName();
    }

    /// <summary>
    /// 
    /// </summary>
    public abstract void AddCrust(Crust crust = null);

    /// <summary>
    /// 
    /// </summary>
    public abstract void AddSize(Size size = null);

    /// <summary>
    /// 
    /// </summary>
    public abstract void AddToppings(params Topping[] toppings);

    //public abstract void NewTopping(Topping t);

    public abstract void SetName();

    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    public override string ToString()
    {
      var stringBuilder = new StringBuilder();
      var separator = ", ";

      foreach (var item in Toppings)
      {
        stringBuilder.Append($"{item}{separator}");
      }

      return $"{Name} - {stringBuilder.ToString().TrimEnd(separator.ToCharArray())}";
    }
  }
}
