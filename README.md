# КТ №24 — Ограниченные классы

**Вариант 2 — Инвентарь предметов**

- Абстрактный базовый класс `Item` со свойствами `string Name { get; init; }`, `decimal Value { get; init; }` и абстрактным методом `string GetDescription()`.
- Обобщённый класс `Inventory<T> where T : Item` с методами `Add(T item)`, `decimal GetTotalValue()` (сумма `Value` всех предметов) и `void PrintAll()` (выводит `GetDescription()` для каждого предмета).
- Производные классы `Weapon : Item` (переопределяет `GetDescription()`, добавляя урон) и `Potion : Item` (переопределяет `GetDescription()`, добавляя эффект).
- Созданы `Inventory<Weapon>` и `Inventory<Potion>`, в каждый добавляется минимум два предмета.
- Методы `Inventory<T>` используют `item.Value` и `item.GetDescription()` напрямую, без приведения типов, — работает ограничение `where T : Item`.

Все данные вводит пользователь; неверный ввод (не число, число не больше нуля, пустая строка) запрашивается повторно.

## Проверочные ключи

| Действие | Ожидаемый результат |
|---|---|
| `Inventory<Weapon>.GetTotalValue()` | сумма `Value` всех добавленных предметов |
| `Inventory<Weapon>.PrintAll()` | описание каждого предмета, специфичное для `Weapon` |
| `Inventory<Potion>` с собственным набором данных | работает независимо от `Inventory<Weapon>` |

## Запуск

```
dotnet run
```

## Результат выполнения

![Результат выполнения](screenshot.png)
