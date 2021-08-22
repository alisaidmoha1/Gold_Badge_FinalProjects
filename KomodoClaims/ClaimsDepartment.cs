using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KomodoClaims
{ 
    public enum ClaimType { Car=1, Home, Theft};
    public class ClaimsDepartment
    {
        public int  ClaimID { get; set; }
        public ClaimType TypeOfClaim { get; set; }
        public string Description { get; set; }
        public decimal ClaimAmount { get; set; }
        public DateTime DateOfAccident { get; set; }
        public DateTime DateOfClaim { get; set; }
        public bool IsValid
        {

            get
            {

                if ((DateOfClaim - DateOfAccident).TotalDays > 30)
                {

                    return false;
                }
                else
                {

                    return true;
                }
            }

        }

        public ClaimsDepartment() { }

        public ClaimsDepartment(int claimID, ClaimType typeOfClaim, string description, decimal claimAmount, DateTime dateOfAccident, DateTime dateOfClaim, bool isValid)
        {
            ClaimID = claimID;
            TypeOfClaim = typeOfClaim;
            Description = description;
            ClaimAmount = claimAmount;
            DateOfAccident = dateOfAccident;
            DateOfClaim = dateOfClaim;
        }

    }
}
