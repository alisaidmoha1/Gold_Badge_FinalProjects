using KomodoInsurance;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace KomodoInsurance_Tests
{

    [TestClass]
    public class Insurance_Repo_Tests
    {
        private Insurance_Repository _repo;
        private Insurance _insurance;

        [TestInitialize]

        public void Arrange()
        {
            List<string> list = new List<string>();
            list.Add("A5");
            list.Add("B6");
            _repo = new Insurance_Repository();
            _insurance = new Insurance(400, list);

            _repo.CreateNewBadges(_insurance.BadgeID, list);
        }


        [TestMethod]
        public void AddToAccessList_ShouldGetNotNull()
        {
            List<string> door = new List<string>();
            door.Add("A5");

            Insurance insurance = new Insurance();
            insurance.BadgeID = 244;
            insurance.AccessDoor = door;

            Insurance_Repository repo = new Insurance_Repository();
            repo.CreateNewBadges(insurance.BadgeID, insurance.AccessDoor);

            Assert.IsNotNull(repo);
        }

        [TestMethod]
        public void GetAccessList_ShouldReturnDictionaryList()
        {
            Insurance_Repository repo = new Insurance_Repository();
            Insurance access = new Insurance();
            List<string> door = new List<string>();
            door.Add("A7");
            door.Add("A4");

            access.BadgeID = 244;
            access.AccessDoor = door;

            repo.CreateNewBadges(access.BadgeID, access.AccessDoor);
            Dictionary<int, List<string>> dic = repo.GetAllBadges();
            bool listHasAccess = dic.ContainsKey(access.BadgeID);

            Assert.IsTrue(listHasAccess);
            Console.WriteLine(listHasAccess);

        }

        [TestMethod]
        public void UpdateExistingBadge_ShouldUpdate()
        {
            List<string> door = new List<string>();
            door.Add("A9");
            Insurance newData = new Insurance(400, door);
            Insurance_Repository repo = new Insurance_Repository();
            repo.CreateNewBadges(newData.BadgeID, newData.AccessDoor);
            List<string> old = new List<string>();
            old.Add("B2");

            repo.AddDoorsToBadges(newData.BadgeID, old);

            List<string> list = new List<string>();
            list.Add("A9");
            list.Add("B2");

             var expected = list;
             var actual = newData.AccessDoor;


            CollectionAssert.AreEqual(expected, actual);


        }

        [TestMethod]
        public void RemoveDoorFromBadge_ShouldReturnTrue()
        {
            var deleteResult = _repo.RemoveDoors(_insurance.BadgeID, "A5");
            
        }

        [TestMethod]
        public void GetAccessListByID_ShouldReturnTrue()
        {
            var access = _repo.GetBadgeAccessListByID(400);
            Assert.AreEqual(_insurance, access);

        }

    }

}

