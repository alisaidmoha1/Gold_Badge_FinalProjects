using KomodoCafe;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace KomodoCafe_Tests
{
    [TestClass]
    public class CafeMenu_Repository_Tests
    {
        private CafeMenu_Repository _repo;
        private CafeMenu _menu;
        [TestInitialize]
        public void Arrange()
        {
            _repo = new CafeMenu_Repository();

            _menu = new CafeMenu(1, "The Loaf", "The Best Sandwitch", 5.5m, "Bread, Tomato, Cumcumber");
            _repo.AddMenuToTheList(_menu);
        }


        [TestMethod]
        public void AddToMenuList_ShoudGetNotNull()
        {
           CafeMenu menu = new CafeMenu();
            menu.MealName = "The Sub";
            menu.MealNumber = 1;

            CafeMenu_Repository repo = new CafeMenu_Repository();
            repo.AddMenuToTheList(menu);

            Assert.IsNotNull(repo);
           
        }
        [TestMethod]
        public void GetMenuListItems_ShoudReturnListItems()
        {
            CafeMenu_Repository repo = new CafeMenu_Repository();
            CafeMenu menuItems = new CafeMenu();
            menuItems.MealName = "The Club Sandwich";

            repo.AddMenuToTheList(menuItems);
            List<CafeMenu> menu = repo.GetMenuList();
            bool listHasMenu = menu.Contains(menuItems);
            Assert.IsTrue(listHasMenu);
        }

        [TestMethod]
        public void DeleteMealNumber_ShouldReturnTrue()
        {
            bool deleteResult = _repo.DeleteMenuFromTheList(_menu.MealNumber);
            Assert.IsTrue(deleteResult);

        }

        [TestMethod]
        public void GetByMealNumber_ShouldReturnTrue()
        {
            CafeMenu menu = _repo.GetMenuByMealNumber(1);
            Assert.AreEqual(_menu, menu);
            
        }
    }
}
