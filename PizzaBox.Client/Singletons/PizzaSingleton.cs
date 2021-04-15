using System.Collections.Generic;
using PizzaBox.Domain.Abstracts;
using PizzaBox.Domain.Models;

namespace PizzaBox.Client.Singletons
{
    /// <summary>
    ///
    /// </summary>

    public class PizzaSingleton
    {

        private static readonly PizzaSingleton _instance;

        public List<Pizza> Pizzas { get; }

        public static PizzaSingleton Instance
        {
            get 
            {
              if(_instance == null)
                {
                    return new PizzaSingleton();
                }
                return _instance;
            }

        }
        private PizzaSingleton() 
        {
            Pizzas = new List<Pizza>();
        }
    }
}