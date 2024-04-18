using InventoryAccountingSystem.Additional;
using InventoryAccountingSystem.Models;

namespace InventoryAccountingSystem.Actions;

public class CategoriesActions
{
    public static readonly List<Category> Categories = new List<Category>();
    
    public static readonly Action[] AllCategoriesActions = new Action[] 
    { 
        AddCategory, 
        RemoveCategory, 
        EditCategory, 
        ShowCategory, 
        ShowCategories 
    };
    
    private static void AddCategory()
    {
        var name = Inputs.InputString("name of new category");
        var description = Inputs.InputString("short description of new category");
        
        Categories.Add(new Category(name, description));
        
        Console.WriteLine("Category added");
        Console.ReadKey();
    }
    
    private static void RemoveCategory()
    {
        if (Inputs.AmountError(Categories, "No categories to remove"))
            return;
        
        int option, categoriesAmount;

        do
        {
            categoriesAmount = Categories.Count;
            option = Menus.UniversalMenu(GetAllCategories(true));
            
            if (option == categoriesAmount)
                continue;
            
            ProductsActions.Products.RemoveAll(product => product.Category == Categories[option]);
            Categories.Remove(Categories[option]);

            Console.WriteLine("Category removed");
            Console.ReadKey();
            
            if (Categories.Count == 0)
                return;

        } while (option != categoriesAmount);
    }

    private static void EditCategory()
    {
        if (Inputs.AmountError(Categories, "No categories to edit"))
            return;
        
        int option;
        var categoriesAmount = Categories.Count;

        do
        {
            option = Menus.UniversalMenu(GetAllCategories(true));
            
            if (option == categoriesAmount)
                continue;
            
            var name = Inputs.InputString("new name of category");
            var description = Inputs.InputString("new short description of category");
            var newCategory = new Category(name, description);
            
            ProductsActions.Products.Where(product => product.Category == Categories[option]).ToList()
                .ForEach(product => product.Category = newCategory);
            Categories[option] = newCategory;
            
            Console.WriteLine("Category edited");
            Console.ReadKey();

        } while (option != categoriesAmount);
    }

    private static void ShowCategory()
    {
        if (Inputs.AmountError(Categories, "No categories to show"))
            return;
        
        int option;
        var categoriesAmount = Categories.Count;

        do
        {
            option = Menus.UniversalMenu(GetAllCategories(true));
            
            if (option == categoriesAmount)
                continue;

            Console.WriteLine($"Name: {Categories[option].Name}\nDescription: {Categories[option].Description}");
            
            var products = ProductsActions.Products.Where(product => product.Category == Categories[option]).ToList();
            for (var i = 0; i < products.Count; i++)
                Console.WriteLine($"Product #{i + 1}: {products[i]}");
            
            Console.ReadKey();

        } while (option != categoriesAmount);
    }

    private static void ShowCategories()
    {
        if (Inputs.AmountError(Categories, "No categories to show"))
            return;
        
        foreach (var category in Categories)
        {
            Console.WriteLine($"Name: {category.Name}\nDescription: {category.Description}");

            var products = ProductsActions.Products.Where(product => product.Category == category).ToList();
            for (var i = 0; i < products.Count; i++)
                Console.WriteLine($"Product #{i + 1}: {products[i]}");
            
            Console.WriteLine();
        }

        Console.ReadKey();
    }

    public static string[] GetAllCategories(bool addExit)
    {
        var categoriesAmount = Categories.Count;
        var categories = (addExit) ? new string[categoriesAmount + 1] : new string[categoriesAmount];

        for (var i = 0; i < categoriesAmount; i++)
            categories[i] = Categories[i].ToString();
        
        if (addExit)
            categories[categoriesAmount] = "Exit";

        return categories;
    }
}
