namespace InventoryAccountingSystem.Additional;

public class Menus
{
    public static readonly string[] MainOptions = new string[]
    {
        "Categories management", "Products management  ", "Suppliers management ", 
        "Search by name       ", "Exit                 "
    };

    public static readonly string[] CategoryOptions = new string[]
    {
        "Add category         ", "Remove category      ", "Edit category        ",
        "Show category info   ", "Show all categories  ", "Exit                 "
    };
    
    public static readonly string[] ProductOptions = new string[]
    {
        "Add product          ", "Remove product       ", "Edit product         ",
        "Edit product amount  ", "Show product info    ", "Show all products    ", "Exit                 "
    };
    
    public static readonly string[] SupplierOptions = new string[]
    {
        "Add supplier         ", "Remove supplier      ", "Edit supplier        ",
        "Show supplier info   ", "Show all suppliers   ", "Exit                 "
    };

    public static readonly string[] SearchOptions = new string[]
    {
        "Search product       ", "Search supplier      ", "Exit                 "
    };

    public static readonly string[] ShowAndSortProductsOptions = new string[]
    {
        "Show all products     ", "Sort products by name ", "Sort products by brand",
        "Sort products by price", "Exit                  "
    };
    
    public static readonly string[] ShowAndSortSuppliersOptions = new string[]
    {
        "Show all suppliers           ", "Sort suppliers by first name ", 
        "Sort suppliers by second name", "Exit                         "
    };
    
    public static void ActionMenu(Action[] actions, string[] options)
    {
        var continueChoice = true;

        do
        {
            var option = UniversalMenu(options);

            if (option < 0 || option >= actions.Length)
                continueChoice = false;
            else
                actions[option]();
        
        } while (continueChoice);
    }

    public static int UniversalMenu(string[] options)
    {
        var optionsAmount = options.Length;
        var selectedOption = 0;
        var continueChoice = true;

        do
        {
            Console.Clear();
            
            for (var i = 0; i < optionsAmount; i++)
            {
                if (i == selectedOption)
                {
                    Console.BackgroundColor = ConsoleColor.White;
                    Console.ForegroundColor = ConsoleColor.Black;
                }

                Console.WriteLine(options[i]);
                Console.ResetColor();
            }
            
            var keyInfo = Console.ReadKey(true);

            switch (keyInfo.Key)
            {
                case ConsoleKey.UpArrow:
                    selectedOption = (selectedOption == 0) ? optionsAmount - 1 : selectedOption - 1;
                    break;
                case ConsoleKey.DownArrow:
                    selectedOption = (selectedOption == optionsAmount - 1) ? 0 : selectedOption + 1;
                    break;
                case ConsoleKey.Enter:
                    continueChoice = false;
                    break;
            }
            
        } while (continueChoice);

        Console.Clear();
        return selectedOption;
    }
}
