using System;

namespace InventoryApp
{
    class Program
    {
        static void Main()
        {
            Inventory<Weapon> weaponInventory = new Inventory<Weapon>();
            int weaponsCount = ReadItemsCount("Сколько оружия добавить (минимум 2)? ");
            for (int weaponNumber = 1; weaponNumber <= weaponsCount; weaponNumber++)
            {
                Console.WriteLine($"Оружие {weaponNumber}:");
                weaponInventory.Add(new Weapon
                {
                    Name = ReadText("Название: "),
                    Value = ReadPrice("Цена: "),
                    Damage = ReadDamage("Урон: ")
                });
            }

            Inventory<Potion> potionInventory = new Inventory<Potion>();
            int potionsCount = ReadItemsCount("Сколько зелий добавить (минимум 2)? ");
            for (int potionNumber = 1; potionNumber <= potionsCount; potionNumber++)
            {
                Console.WriteLine($"Зелье {potionNumber}:");
                potionInventory.Add(new Potion
                {
                    Name = ReadText("Название: "),
                    Value = ReadPrice("Цена: "),
                    Effect = ReadText("Эффект: ")
                });
            }

            Console.WriteLine();
            Console.WriteLine("Инвентарь оружия:");
            weaponInventory.PrintAll();
            Console.WriteLine($"Общая стоимость оружия: {weaponInventory.GetTotalValue()}");

            Console.WriteLine();
            Console.WriteLine("Инвентарь зелий:");
            potionInventory.PrintAll();
            Console.WriteLine($"Общая стоимость зелий: {potionInventory.GetTotalValue()}");
        }

        static int ReadItemsCount(string prompt)
        {
            Console.Write(prompt);
            int itemsCount;
            while (!int.TryParse(Console.ReadLine(), out itemsCount) || itemsCount < 2)
            {
                Console.Write("Нужно целое число не меньше 2: ");
            }
            return itemsCount;
        }

        static decimal ReadPrice(string prompt)
        {
            Console.Write(prompt);
            decimal price;
            while (!decimal.TryParse(Console.ReadLine(), out price) || price <= 0)
            {
                Console.Write("Нужна цена больше нуля (дробная часть через запятую): ");
            }
            return price;
        }

        static int ReadDamage(string prompt)
        {
            Console.Write(prompt);
            int damage;
            while (!int.TryParse(Console.ReadLine(), out damage) || damage <= 0)
            {
                Console.Write("Нужен урон - целое число больше нуля: ");
            }
            return damage;
        }

        static string ReadText(string prompt)
        {
            Console.Write(prompt);
            string text = Console.ReadLine()!;
            while (text == "")
            {
                Console.Write("Строка не должна быть пустой: ");
                text = Console.ReadLine()!;
            }
            return text;
        }
    }
}
