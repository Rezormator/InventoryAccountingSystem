namespace InventoryAccountingSystem.Models;

public class Supplier
{
    public string FirstName { get; }
    public string SecondName { get; }
    public string Company { get; }

    public Supplier(string firstName, string secondName, string company)
    {
        FirstName = firstName;
        SecondName = secondName;
        Company = company;
    }

    public override string ToString()
    {
        return $"Name: {FirstName} {SecondName}, Company: {Company}";
    }
}

public class SupplierComparer : IComparer<Supplier>
{
    private readonly string _sortBy;

    public SupplierComparer(string sortBy)
    {
        _sortBy = sortBy;
    }

    public int Compare(Supplier? x, Supplier? y)
    {
        if (x == null || y == null)
            throw new NullReferenceException();

        return _sortBy switch
        {
            "FirstName" => string.Compare(x.FirstName, y.FirstName, StringComparison.Ordinal),
            "SecondName" => string.Compare(x.SecondName, y.SecondName, StringComparison.Ordinal),
            _ => throw new ArgumentException("Invalid sortBy parameter")
        };
    }
}
