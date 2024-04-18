using InventoryAccountingSystem.Additional;
using InventoryAccountingSystem.Models;

namespace InventoryAccountingSystem.Actions;

public class SuppliersActions
{
    public static readonly List<Supplier> Suppliers = new List<Supplier>();
    
    public static readonly Action[] AllSuppliersActions = new Action[]
    {
        AddSupplier,
        RemoveSupplier,
        EditSupplier,
        ShowSupplier,
        ShowAndSortSuppliers
    };
    
    private static void AddSupplier()
    {
        var firstName = Inputs.InputString("first name of new Supplier");
        var secondName = Inputs.InputString("second name of new Supplier");
        var company = Inputs.InputString("company name of new Supplier");
        
        Suppliers.Add(new Supplier(firstName, secondName, company));
        
        Console.WriteLine("Supplier added");
        Console.ReadKey();
    }
    
    private static void RemoveSupplier()
    {
        if (Inputs.AmountError(Suppliers, "No suppliers to remove"))
            return;
        
        int option, suppliersAmount;

        do
        {
            suppliersAmount = Suppliers.Count;
            option = Menus.UniversalMenu(GetAllSuppliers(true));
            
            if (option == suppliersAmount)
                continue;
            
            ProductsActions.Products.RemoveAll(product => product.Supplier == Suppliers[option]);
            Suppliers.Remove(Suppliers[option]);

            Console.WriteLine("Supplier removed");
            Console.ReadKey();
            
            if (Suppliers.Count == 0)
                return;

        } while (option != suppliersAmount);
    }

    private static void EditSupplier()
    {
        if (Inputs.AmountError(Suppliers, "No suppliers to edit"))
            return;
        
        int option;
        var suppliersAmount = Suppliers.Count;

        do
        {
            option = Menus.UniversalMenu(GetAllSuppliers(true));
            
            if (option == suppliersAmount)
                continue;
            
            var firstName = Inputs.InputString("new first name of Supplier");
            var secondName = Inputs.InputString("new second name of Supplier");
            var company = Inputs.InputString("new company name of Supplier");
            var newSupplier = new Supplier(firstName, secondName, company);
            
            ProductsActions.Products.Where(product => product.Supplier == Suppliers[option]).ToList()
                .ForEach(product => product.Supplier = newSupplier);
            Suppliers[option] = newSupplier;
            
            Console.WriteLine("Supplier edited");
            Console.ReadKey();

        } while (option != suppliersAmount);
    }

    private static void ShowSupplier()
    {
        if (Inputs.AmountError(Suppliers, "No suppliers to show"))
            return;
        
        int option;
        var suppliersAmount = Suppliers.Count;

        do
        {
            option = Menus.UniversalMenu(GetAllSuppliers(true));
            
            if (option == suppliersAmount)
                continue;

            Console.WriteLine(Suppliers[option].ToString());
            
            var products = ProductsActions.Products.Where(product => product.Supplier == Suppliers[option]).ToList();
            for (var i = 0; i < products.Count; i++)
                Console.WriteLine($"Product #{i + 1}: {products[i]}");
            
            Console.ReadKey();

        } while (option != suppliersAmount);
    }

    private static void ShowSuppliers()
    {
        foreach (var supplier in Suppliers)
        {
            Console.WriteLine(supplier.ToString());
            
            var products = ProductsActions.Products.Where(product => product.Supplier == supplier).ToList();
            for (var i = 0; i < products.Count; i++)
                Console.WriteLine($"Product #{i + 1}: {products[i]}");
            
            Console.WriteLine();
        }

        Console.ReadKey();
    }

    private static void SortSuppliersByFirstName()
    {
        Suppliers.Sort(new SupplierComparer("FirstName"));
        Console.WriteLine("Suppliers sorted by first name");
        Console.ReadKey();
    }
    
    private static void SortSuppliersBySecondName()
    {
        Suppliers.Sort(new SupplierComparer("SecondName"));
        Console.WriteLine("Suppliers sorted by second name");
        Console.ReadKey();
    }
    
    private static void ShowAndSortSuppliers()
    {
        if (Inputs.AmountError(Suppliers, "No suppliers to show or sort"))
            return;
        
        Action[] showAndSortActivities = new Action[]
        {
            ShowSuppliers,
            SortSuppliersByFirstName,
            SortSuppliersBySecondName
        };

        int option;
        var optionsAmount = showAndSortActivities.Length;

        do
        {
            option = Menus.UniversalMenu(Menus.ShowAndSortSuppliersOptions);
            
            if (option == optionsAmount)
                continue;

            showAndSortActivities[option]();
            
        } while (option != optionsAmount);
    }
    
    public static string[] GetAllSuppliers(bool addExit)
    {
        var suppliersAmount = Suppliers.Count;
        var suppliers = (addExit) ? new string[suppliersAmount + 1] : new string[suppliersAmount];

        for (var i = 0; i < suppliersAmount; i++)
            suppliers[i] = Suppliers[i].ToString();
        
        if (addExit)
            suppliers[suppliersAmount] = "Exit";

        return suppliers;
    }
}
