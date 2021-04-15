using System;

namespace PizzaBox.Domain.Abstracts
    {
        public abstract class Component
        {
            public string Name { get; protected set; }
            public string Price { get; protected set; }

            public override string ToString()
            {
             return Name;
            }

        }
    }