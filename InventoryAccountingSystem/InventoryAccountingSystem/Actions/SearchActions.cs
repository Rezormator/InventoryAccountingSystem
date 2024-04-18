using InventoryAccountingSystem.Additional;
namespace InventoryAccountingSystem.Actions;

public class SearchActions
{
    public static readonly Action[] AllSearchActions = new Action[]
    {
        SearchProduct,
        SearchSupplier
    };

    private static void SearchProduct()
    {
        var products = ProductsActions.Products;
            
        if (Inputs.AmountError(products, "No products to search"))
            return;
            
        var word = Inputs.InputString("key word");
        Console.WriteLine();
            
        var filteredProducts = products.Where(product => 
            product.Name.Contains(word) || product.Brand.Contains(word)).ToList();
            
        if (filteredProducts.Count == 0)
            Console.WriteLine("\nNo searching results");

        foreach (var product in filteredProducts)
            Console.WriteLine(product.GetAllInfo());

        Console.ReadKey();
    }

    private static void SearchSupplier()
    {
        if (Inputs.AmountError(SuppliersActions.Suppliers, "No products to search"))
            return;
            
        var word = Inputs.InputString("key word");
        Console.WriteLine();

        var filteredCustomers = SuppliersActions.Suppliers.Where(customer => 
            customer.FirstName.Contains(word) || customer.SecondName.Contains(word) || customer.Company.Contains(word)).ToList();
            
        if (filteredCustomers.Count == 0)
            Console.WriteLine("\nNo searching results");

        foreach (var customer in filteredCustomers)
            Console.WriteLine(customer.ToString());

        Console.ReadKey();
    }
}
