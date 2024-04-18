using InventoryAccountingSystem.Additional;
using InventoryAccountingSystem.Models;

namespace InventoryAccountingSystem.Actions;

public class ProductsActions
{
    public static readonly List<Product> Products = new List<Product>();
    
    public static readonly Action[] AllProductsActions = new Action[]
    {
        AddProduct,
        RemoveProduct,
        EditProduct,
        EditProductAmount,
        ShowProduct,
        ShowAndSortProducts
    };
    
    private static void AddProduct()
    {
        if (Inputs.AmountError(CategoriesActions.Categories, "No categories for product"))
            return;
        
        if (Inputs.AmountError(SuppliersActions.Suppliers, "No suppliers for product"))
            return;
        
        var name = Inputs.InputString("name of new product");
        var brand = Inputs.InputString("brand name of new product");
        var description = Inputs.InputString("short description of new product");
        var price = Inputs.InputDecimal("price of new product");
        var category = CategoriesActions.Categories[Menus.UniversalMenu(CategoriesActions.GetAllCategories(false))];
        var supplier = SuppliersActions.Suppliers[Menus.UniversalMenu(SuppliersActions.GetAllSuppliers(false))];
        
        Products.Add(new Product(name, brand, description, price, category, supplier));
        
        Console.WriteLine("Product added");
        Console.ReadKey();
    }
    
    private static void RemoveProduct()
    {
        if (Inputs.AmountError(Products, "No products to remove"))
            return;
        
        int option, productsAmount;

        do
        {
            productsAmount = Products.Count;
            option = Menus.UniversalMenu(GetAllProducts(true));
            
            if (option == productsAmount)
                continue;
            
            Products.Remove(Products[option]);

            Console.WriteLine("Product removed");
            Console.ReadKey();
            
            if (Products.Count == 0)
                return;

        } while (option != productsAmount);
    }

    private static void EditProduct()
    {
        if (Inputs.AmountError(Products, "No products to edit"))
            return;
        
        int option;
        var productsAmount = Products.Count;

        do
        {
            option = Menus.UniversalMenu(GetAllProducts(true));
            
            if (option == productsAmount)
                continue;
            
            var name = Inputs.InputString("new name of product");
            var brand = Inputs.InputString("new brand name of product");
            var description = Inputs.InputString("new short description of product");
            var price = Inputs.InputDecimal("new price of product");
            var category = CategoriesActions.Categories[Menus.UniversalMenu(CategoriesActions.GetAllCategories(false))];
            var supplier = SuppliersActions.Suppliers[Menus.UniversalMenu(SuppliersActions.GetAllSuppliers(false))];

            Products[option] = new Product(name, brand, description, price, category, supplier);
            
            Console.WriteLine("Product edited");
            Console.ReadKey();

        } while (option != productsAmount);
    }
    
    private static void EditProductAmount()
    {
        if (Inputs.AmountError(Products, "No products to edit amount"))
            return;
        
        int option;
        var productsAmount = Products.Count;

        do
        {
            option = Menus.UniversalMenu(GetAllProducts(true));
            
            if (option == productsAmount)
                continue;

            Console.WriteLine($"Current amount: {Products[option].Amount}");
            Products[option].Amount = Inputs.InputInt("new amount of product");
            
            Console.WriteLine("Product amount edited");
            Console.ReadKey();

        } while (option != productsAmount);
    }

    private static void ShowProduct()
    {
        if (Inputs.AmountError(Products, "No products to show"))
            return;
        
        int option;
        var productsAmount = Products.Count;

        do
        {
            option = Menus.UniversalMenu(GetAllProducts(true));
            
            if (option == productsAmount)
                continue;

            Console.WriteLine(Products[option].GetAllInfo());
            Console.ReadKey();

        } while (option != productsAmount);
    }

    private static void ShowProducts()
    {
        foreach (var product in Products)
            Console.WriteLine(product.GetAllInfo());
        
        Console.ReadKey();
    }
    
    private static void SortProductsByName()
    {
        Products.Sort(new ProductComparer("Name"));
        Console.WriteLine("Products sorted by name");
        Console.ReadKey();
    }
    
    private static void SortProductsByBrand()
    {
        Products.Sort(new ProductComparer("Brand"));
        Console.WriteLine("Products sorted by brand");
        Console.ReadKey();
    }
    
    private static void SortProductsByPrice()
    {
        Products.Sort(new ProductComparer("Price"));
        Console.WriteLine("Products sorted by price");
        Console.ReadKey();
    }
    
    private static void ShowAndSortProducts()
    {
        if (Inputs.AmountError(Products, "No products to show or sort"))
            return;
        
        Action[] showAndSortActivities = new Action[]
        {
            ShowProducts,
            SortProductsByName,
            SortProductsByBrand,
            SortProductsByPrice,
        };

        int option;
        var optionsAmount = showAndSortActivities.Length;

        do
        {
            option = Menus.UniversalMenu(Menus.ShowAndSortProductsOptions);
            
            if (option == optionsAmount)
                continue;

            showAndSortActivities[option]();
            
        } while (option != optionsAmount);
    }

    private static string[] GetAllProducts(bool addExit)
    {
        var productsAmount = Products.Count;
        var products = (addExit) ? new string[productsAmount + 1] : new string[productsAmount];

        for (var i = 0; i < productsAmount; i++)
            products[i] = Products[i].ToString();
        
        if (addExit)
            products[productsAmount] = "Exit";

        return products;
    }
}
