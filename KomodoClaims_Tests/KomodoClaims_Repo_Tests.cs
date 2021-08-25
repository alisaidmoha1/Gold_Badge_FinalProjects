using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using KomodoClaims;
using System.Collections.Generic;

namespace KomodoClaims_Tests
{
    [TestClass]
    public class KomodoClaims_Repo_Tests
    {
        private ClaimsDepartment_Repository _repo;
        private ClaimsDepartment    _claim;
        [TestInitialize]
        public void Arrange()
        {
            _repo = new ClaimsDepartment_Repository();

            _claim = new ClaimsDepartment(225, ClaimType.Car, "car crush in i-70", 17000m, new DateTime(2021, 8, 22), new DateTime(2021, 7, 20), true);
            _repo.CreatNewClaim(_claim);
        }
        [TestMethod]
        public void AddToClaimList_ShouldGetNotNull()
        {
            ClaimsDepartment claims = new ClaimsDepartment();
            claims.ClaimID = 115;
            claims.TypeOfClaim = ClaimType.Car;
            claims.DateOfClaim = new DateTime(2021, 06, 03);
            claims.DateOfAccident = new DateTime(2021, 05, 04);
            bool isVallid =  claims.IsValid;

            Assert.IsTrue(isVallid);

            Console.WriteLine($"ClaimID: {claims.ClaimID}, Claim Type: {ClaimType.Home}, Is Valid: {isVallid}");

            ClaimsDepartment_Repository claim = new ClaimsDepartment_Repository();
            claim.CreatNewClaim(claims);
            Assert.IsNotNull(claim);
        }

        [TestMethod]
        public void GetAllClaims_ShoudReturnListItems()
        {
            ClaimsDepartment_Repository repo = new ClaimsDepartment_Repository();
            ClaimsDepartment claims = new ClaimsDepartment();
            claims.ClaimID = 444;
            claims.ClaimAmount = 5000m;
            claims.TypeOfClaim = ClaimType.Car;
            claims.DateOfAccident = new DateTime(2021, 4, 5);
            claims.DateOfClaim = new DateTime(2021, 7, 3);

            repo.CreatNewClaim(claims);
            List<ClaimsDepartment> claim = repo.GetAllClaims();

            bool result = claim.Contains(claims);
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void GetClaimByID_ShouldReturnTrue()
        {
            ClaimsDepartment claim = _repo.GetClaimsByID(225);
            Assert.AreEqual(_claim, claim);
        }
        
    }
}
