using System.Collections.Generic;
using PizzaBox.Domain.Abstracts;
using PizzaBox.Storing.Repositories;

namespace PizzaBox.Client.Singletons
{
  /// <summary>
  /// 
  /// </summary>
  public class ToppingSingleton
  {
    private readonly FileRepository _fileRepository = new FileRepository();
    private static ToppingSingleton _instance;
    private const string _path = @"data/toppings.xml";

    public List<AComponent> Toppings { get; set; }
    public static ToppingSingleton Instance
    {
      get
      {
        if (_instance == null)
        {
          _instance = new ToppingSingleton();
        }

        return _instance;
      }
    }

    /// <summary>
    /// 
    /// </summary>
    private ToppingSingleton()
    {
      Toppings = _fileRepository.ReadFromFile<List<AComponent>>(_path);
    }
  }
}
