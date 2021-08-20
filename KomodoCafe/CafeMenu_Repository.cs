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

        public bool DeleteMenuFromTheList(CafeMenu menu)
        {
            _menuList.Remove(menu);
            return true;
        }
    }
}
