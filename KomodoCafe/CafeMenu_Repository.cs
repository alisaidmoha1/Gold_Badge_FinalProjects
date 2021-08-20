using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KomodoCafe
{
    public class CafeMenu_Repository
    {
        List<CafeMenu> _menuList = new List<CafeMenu>();
        //Create 
        public void AddMenuToTheList(CafeMenu menu)
        {
            _menuList.Add(menu);
        }
        //Read
        public List<CafeMenu> GetMenuList()
        {
            return _menuList;
        }

        // Delete 

        public bool DeleteMenuFromTheList(int mealNumber)
        {

            CafeMenu menu = GetMenuByMealNumber(mealNumber);

            if (menu == null)
            {
                return false;
            }

            int initialCount = _menuList.Count();
            _menuList.Remove(menu);

            if (initialCount > _menuList.Count)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        //Helper Method

        public CafeMenu GetMenuByMealNumber(int mealNumber)
        {
            foreach (CafeMenu menu in _menuList)
            {
                if (menu.MealNumber == mealNumber)
                {
                    return menu;
                }
            }

            return null;
        }
    }

}
