using System;

namespace PizzaBox.Domain.Abstracts
    {
        public abstract class Pizza
        {
            public string Name { get; protected set; }

            public override string ToString()
            {
             return Name;
            }

        }
    }