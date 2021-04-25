using System.Collections.Generic;
using PizzaBox.Domain.Abstracts;
using PizzaBox.Storing.Repositories;

namespace PizzaBox.Client.Singletons
{
  /// <summary>
  /// 
  /// </summary>
  public class SizeSingleton
  {
    private readonly FileRepository _fileRepository = new FileRepository();
    private static SizeSingleton _instance;
    private const string _path = @"data/sizes.xml";

    public List<AComponent> Sizes { get; set; }
    public static SizeSingleton Instance
    {
      get
      {
        if (_instance == null)
        {
          _instance = new SizeSingleton();
        }

        return _instance;
      }
    }

    /// <summary>
    /// 
    /// </summary>
    private SizeSingleton()
    {
      Sizes = _fileRepository.ReadFromFile<List<AComponent>>(_path);
    }
  }
}
