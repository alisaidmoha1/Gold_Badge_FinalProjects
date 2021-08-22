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
                        SearchMenuItemByMealNumber();
                        break;
                    case "4":
                        DeleteMenuItem();
                        break;
                    case "5":
                    case "EXIT":
                    case "exit":
                    case "Exit":
                        WriteLine("Goodbye!");
                        WriteLine("Press any key to exit");
                        ReadKey();
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

            List<CafeMenu> menuItems = _repo.GetMenuList();

            if (!_repo.GetMenuList().Contains(newMenuItem))
            {
            _repo.AddMenuToTheList(newMenuItem);
            } else
            {
                WriteLine("You already have this menu item");
            }

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

        private void SearchMenuItemByMealNumber()
        {
            WriteLine("Enter meal number: ");
            string userInput = ReadLine().ToString();
            int userInputInt = int.Parse(userInput);

            CafeMenu mealNumber = _repo.GetMenuByMealNumber(userInputInt);
            if (userInput == null) {
                WriteLine("The Meal Number you entered has not been found");
            } else
            {
                WriteLine($"\nNo.{mealNumber.MealNumber}\n" +
                    $"Name: {mealNumber.MealName}\n" +
                    $"Description: {mealNumber.Description}\n" +
                    $"The ingredients: {mealNumber.ListOfIngredients}\n" +
                    $"The Price: ${mealNumber.Price}");
                WriteLine("\n====================\n");
            }
        }

        private void DeleteMenuItem()
        {
            WriteLine("Enter the menu meal number you want to delete: ");
            string userInput = ReadLine().ToString();
            int userInputInt = int.Parse(userInput);

            CafeMenu mealNumber = _repo.GetMenuByMealNumber(userInputInt);

            if(userInput == null)
            {
                WriteLine("The meal number you entered is not valid");
            } else
            {
                WriteLine($"Are you sure you want to delete No.{mealNumber.MealNumber}, (yes or no)");
                string answer = ReadLine().ToLower();
                if (answer == "yes" || answer == "y")
                {
                    _repo.DeleteMenuFromTheList(userInputInt);
                    WriteLine($"Menu item No.{mealNumber.MealNumber} is successfully deleted");
                } else
                {
                    WriteLine("Phew! the menu item is safe for now");
                }
            }


        }

        public void SeedContentMenu()
        {
            CafeMenu menuItem1 = new CafeMenu(001, "Morning Brew", "Breakfast cereal", 7.00m, "Steel cut oats, quinao and blueberries topped with fresh apple");
            CafeMenu menuItem2 = new CafeMenu(005, "The Sandwitch", "Breakfast sandwitch", 8.95m, "Eggs and Cheddar on toasted croissant with green salad");
            CafeMenu menuItem3 = new CafeMenu(004, "House Granola", "Breakfast granola", 6.50m, "granola with greek yogurt and fresh fruit");
            CafeMenu menuItem4 = new CafeMenu(255, "Hi", "Hi", 5.5m, "hi");

            _repo.AddMenuToTheList(menuItem1);
            _repo.AddMenuToTheList(menuItem2);
            _repo.AddMenuToTheList(menuItem3);
            _repo.AddMenuToTheList(menuItem4);
        }

        private void ConsoleInfo()
        {
            WriteLine("Press any key to continue");
            ReadKey();
            Clear();
        }
    }
}
