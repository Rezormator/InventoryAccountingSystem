using InventoryAccountingSystem.Additional;
using InventoryAccountingSystem.Actions;

namespace InventoryAccountingSystem
{
    class Program
    {
        static void Main(string[] args)
        {
            var continueChoice = true;
        
            do
            {
                switch (Menus.UniversalMenu(Menus.MainOptions))
                {
                    case 0:
                        Menus.ActionMenu(CategoriesActions.AllCategoriesActions, Menus.CategoryOptions);
                        break;
                    case 1:
                        Menus.ActionMenu(ProductsActions.AllProductsActions, Menus.ProductOptions);
                        break;
                    case 2:
                        Menus.ActionMenu(SuppliersActions.AllSuppliersActions, Menus.SupplierOptions);
                        break;
                    case 3:
                        Menus.ActionMenu(SearchActions.AllSearchActions, Menus.SearchOptions);
                        break;
                    case 4:
                        continueChoice = false;
                        break;
                }
            
            } while (continueChoice);
        }
    }
}
