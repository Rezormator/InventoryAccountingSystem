namespace InventoryAccountingSystem.Models;

public class Category
{
    public string Name { get; }
    public string Description { get; }

    public Category(string name, string description)
    {
        Name = name;
        Description = description;
    }

    public override string ToString()
    {
        return $"Category: {Name}";
    }
}
