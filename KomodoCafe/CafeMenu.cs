using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KomodoCafe
{
    public class CafeMenu
    {
        //private int _MealNumber;
        //private string _MealName;
        //private string _Description;
        //private decimal _Price;
        //private string _ListOfIngredients;

        public int  MealNumber { get; set; }
        public string MealName { get; set; }
        public string  Description { get; set; }
        public decimal  Price { get; set; }
        public string ListOfIngredients { get; set; }

        public CafeMenu() {  }

        public CafeMenu(int mealNumber, string mealName, string description, decimal price, string listOfIngredients)
        {
            MealNumber = mealNumber;
            MealName = mealName;
            Description = description;
            Price = price;
            ListOfIngredients = listOfIngredients;
        }

    }
}
