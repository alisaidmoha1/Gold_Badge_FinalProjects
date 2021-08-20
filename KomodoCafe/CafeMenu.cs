using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KomodoCafe
{
    public class CafeMenu
    {
        private int _MealNumber;
        private string _MealName;
        private string _Description;
        private decimal _Price;
        private string _ListOfIngredients;

        public int  MealNumber { get; set; }
        public string MealName { get; set; }
        public string  Description { get; set; }
        public int  Price { get; set; }
        public string ListOfIngredients { get; set; }

        public CafeMenu() {  }

        public CafeMenu(int mealNumber, string mealName, string description, decimal price, string listOfIngredients)
        {
            _MealNumber = mealNumber;
            _MealName = mealName;
            _Description = description;
            _Price = price;
            _ListOfIngredients = listOfIngredients;
        }

    }
}
