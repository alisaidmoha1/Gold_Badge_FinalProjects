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
            _repo = new Insurance_Repository();
            _insurance = new Insurance(400, DoorNames.B3);

            _repo.CreateNewBadges(_insurance.BadgeID, _insurance.AccessDooor);
        }


        [TestMethod]
        public void AddToAccessList_ShouldGetNotNull()
        {
            Insurance insurance = new Insurance();
            insurance.BadgeID = 244;
            insurance.AccessDooor = DoorNames.A1;

            Insurance_Repository repo = new Insurance_Repository();
            repo.CreateNewBadges(insurance.BadgeID, insurance.AccessDooor);

            Assert.IsNotNull(repo);
        }

        [TestMethod]
        public void GetAccessList_ShouldReturnDictionaryList()
        {
            Insurance_Repository repo = new Insurance_Repository();
            Insurance access = new Insurance();
            access.BadgeID = 244;
            access.AccessDooor = DoorNames.B1;

            repo.CreateNewBadges(access.BadgeID, access.AccessDooor);
            Dictionary<int, DoorNames> dic = repo.GetAllBadges();
            bool listHasAccess = dic.ContainsKey(access.BadgeID);

            Assert.IsTrue(listHasAccess);
            Console.WriteLine(listHasAccess);

        }

        [TestMethod]
        public void UpdateExistingBadge_ShouldUpdate()
        {
            Insurance newData = new Insurance(400, DoorNames.A2);

         _repo.UpdateBadges(newData.BadgeID, newData.AccessDooor);

          

            var expected = DoorNames.A2;
            var actual = DoorNames.A1;

            Assert.AreEqual(expected, actual);

            
        }



    }
}
