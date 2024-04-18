namespace InventoryAccountingSystem.Additional;

public class Inputs
{
    public static string InputString(string text)
    {
        Console.Write($"Enter {text}: ");
        return Console.ReadLine();
    }
        
    public static decimal InputDecimal(string text)
    {
        var isValid = false;
        decimal number;

        do
        {
            Console.Write($"Enter {text}: ");
            var input = Console.ReadLine();

            if (decimal.TryParse(input, out number))
                isValid = true;
            else
                Console.WriteLine("Invalid number");
        } while (!isValid);

        return number;
    }
        
    public static int InputInt(string text)
    {
        var isValid = false;
        int number;

        do
        {
            Console.Write($"Enter {text}: ");
            var input = Console.ReadLine();

            if (int.TryParse(input, out number))
                isValid = true;
            else
                Console.WriteLine("Invalid number");
        } while (!isValid);

        return number;
    }
    
    public static bool AmountError<T>(IEnumerable<T> list, string text)
    {
        if (list.Any())
            return false;
            
        Console.WriteLine(text);
        Console.ReadKey();
        return true;
    }
}
