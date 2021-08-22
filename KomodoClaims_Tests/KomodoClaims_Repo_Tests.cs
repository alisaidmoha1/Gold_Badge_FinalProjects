using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using KomodoClaims;

namespace KomodoClaims_Tests
{
    [TestClass]
    public class KomodoClaims_Repo_Tests
    {
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
    }
}
