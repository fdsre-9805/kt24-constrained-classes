using System;
using System.Collections.Generic;

namespace InventoryApp
{
    public abstract class Item
    {
        public string Name { get; init; } = "";
        public decimal Value { get; init; }

        public abstract string GetDescription();
    }

    public class Weapon : Item
    {
        public int Damage { get; init; }

        public override string GetDescription()
        {
            return $"Оружие {Name}, цена {Value}, урон {Damage}";
        }
    }

    public class Potion : Item
    {
        public string Effect { get; init; } = "";

        public override string GetDescription()
        {
            return $"Зелье {Name}, цена {Value}, эффект: {Effect}";
        }
    }

    public class Inventory<T> where T : Item
    {
        private List<T> items = new List<T>();

        public void Add(T item)
        {
            items.Add(item);
        }

        public decimal GetTotalValue()
        {
            decimal totalValue = 0;
            foreach (T item in items)
            {
                totalValue += item.Value;
            }
            return totalValue;
        }

        public void PrintAll()
        {
            foreach (T item in items)
            {
                Console.WriteLine(item.GetDescription());
            }
        }
    }
}
