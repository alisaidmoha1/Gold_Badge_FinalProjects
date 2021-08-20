using KomodoCafe;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace KomodoCafe_Tests
{
    [TestClass]
    public class CafeMenu_Repository_Tests
    {
      


        [TestMethod]
        public void TestingAddMethod()
        {
           CafeMenu menu = new CafeMenu();
            menu.MealName = "The Sub";
            menu.MealNumber = 1;

            CafeMenu_Repository repo = new CafeMenu_Repository();
            repo.AddMenuToTheList(menu);

            Assert.IsNotNull(repo);
           
        }

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
        public void TestingDeleteMethod()
        {
            bool deleteResult = _repo.DeleteMenuFromTheList(_menu);
            Assert.IsTrue(deleteResult);

        }
    }
}
