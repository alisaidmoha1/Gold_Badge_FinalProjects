using KomodoCafe;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace KomodoCafe_Console
{  
    public class ProgramUI
    {
        private CafeMenu_Repository _repo = new CafeMenu_Repository();
        public void Run()
        {
            SeedContentMenu();
            Menu();
        }

        private void Menu()
        {
            bool isRunning = true;
            while (isRunning)
            {
                WriteLine("\n~~~~~~~~~~~~~~~~~~~~~~~~~~~");
                WriteLine("Select from the menu option: \n" +
                    "1. Create a new menu item\n" +
                    "2. Display all the menu items\n" +
                    "3. Search menu Item by Meal Number\n" +
                    "4. Delete a menu item\n" +
                    "5. EXIT");

                string userInput = Console.ReadLine();

                switch (userInput)
                {
                    case "1":
                        AddNewMenuItem();
                        break;
                    case "2":
                        DisplayAllMenuItems();
                        break;
                    case "3":
                        //Search item by Meal number
                        break;
                    case "4":
                        //Delete menu item
                        break;
                    case "5":
                    case "EXIT":
                    case "exit":
                    case "Exit":
                        WriteLine("Goodbye!");
                        isRunning = false;
                        break;
                    default:
                        WriteLine("Please enter a valid number");
                        break;
                   
                }

                ConsoleInfo();

            }

        }

        private void AddNewMenuItem()
        {
            Clear();
            CafeMenu newMenuItem = new CafeMenu();

            WriteLine("Enter a meal number: ");
            newMenuItem.MealNumber = int.Parse(ReadLine());

            WriteLine("Enter a meal name: ");
            newMenuItem.MealName = ReadLine();

            WriteLine("Enter description: ");
            newMenuItem.Description = ReadLine();

            WriteLine("Enter the Ingredients");
            newMenuItem.ListOfIngredients = ReadLine();

            WriteLine("Enter the price");
            newMenuItem.Price = Decimal.Parse(ReadLine());

            _repo.AddMenuToTheList(newMenuItem);
        }

        private void DisplayAllMenuItems()
        {
            Clear();
            List<CafeMenu> menuListItems = _repo.GetMenuList();

            foreach (CafeMenu menu in menuListItems)

            {
                WriteLine($"\nNo.{menu.MealNumber}\n" +
                    $"Name: {menu.MealName}\n" +
                    $"Description: {menu.Description}\n" +
                    $"The ingredients: {menu.ListOfIngredients}\n" +
                    $"The Price: ${menu.Price}");
                WriteLine("\n====================\n");
            }
        }

        public void SeedContentMenu()
        {
            CafeMenu menuItem1 = new CafeMenu(1, "Morning Brew", "Breakfast cereal", 7.00m, "Steel cut oats, quinao and blueberries topped with fresh apple");
            CafeMenu menuItem2 = new CafeMenu(5, "The Sandwitch", "Breakfast sandwitch", 8.95m, "Eggs and Cheddar on toasted croissant with green salad");
            CafeMenu menuItem3 = new CafeMenu(1, "House Granola", "Breakfast granola", 6.50m, "granola with greek yogurt and fresh fruit");

            _repo.AddMenuToTheList(menuItem1);
            _repo.AddMenuToTheList(menuItem2);
            _repo.AddMenuToTheList(menuItem3);
        }

        private void ConsoleInfo()
        {
            WriteLine("Press any key to continue");
            ReadKey();
            Clear();
        }
    }
}
