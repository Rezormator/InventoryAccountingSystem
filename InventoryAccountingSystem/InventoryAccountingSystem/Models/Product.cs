namespace InventoryAccountingSystem.Models;

public class Product
{
    public string Name { get; }
    public string Brand { get; }
    private string Description { get; }
    public decimal Price { get; }
    public Category Category { get; set; }
    public Supplier Supplier { get; set; }
    public int Amount { get; set; }

    public Product(string name, string brand, string description, decimal price, Category category, Supplier supplier)
    {
        Name = name;
        Brand = brand;
        Description = description;
        Price = price;
        Category = category;
        Supplier = supplier;
        Amount = 0;
    }

    public override string ToString()
    {
        return $"Name: {Name}, Brand: {Brand}, Price: {Price}";
    }

    public string GetAllInfo()
    {
        return $"Name: {Name}\nBrand: {Brand}\nPrice: {Price}\nAmount: {Amount}" +
               $"\nCategory: {Category.Name}\nSupplier: {Supplier.Company}\nDescription: {Description}\n";
    }
}

public class ProductComparer : IComparer<Product>
{
    private readonly string _sortBy;

    public ProductComparer(string sortBy)
    {
        _sortBy = sortBy;
    }
    
    public int Compare(Product? x, Product? y)
    {
        if (x == null || y == null)
            throw new NullReferenceException();

        return _sortBy switch
        {
            "Name" => string.Compare(x.Name, y.Name, StringComparison.Ordinal),
            "Brand" => string.Compare(x.Brand, y.Brand, StringComparison.Ordinal),
            "Price" => decimal.Compare(x.Price, y.Price),
            _ => throw new ArgumentException("Invalid sortBy parameter")
        };
    }
}
