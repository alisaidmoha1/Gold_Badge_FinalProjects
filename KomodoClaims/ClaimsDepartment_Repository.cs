using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KomodoClaims
{
   public class ClaimsDepartment_Repository
    {
        List<ClaimsDepartment> _listOfClaims = new List<ClaimsDepartment>();

        public void CreatNewClaim(ClaimsDepartment claim)
        {
            _listOfClaims.Add(claim);
        }

        public List<ClaimsDepartment> GetAllClaims()
        {
            return _listOfClaims;
        }

        public void DealingClaim(int id)
        {

            ClaimsDepartment claim = GetClaimsByID(id);

            if (claim == null)
            {
                Console.WriteLine("The ID you entered is not in the record!");
            } else
            {
                _listOfClaims.Remove(claim);
            }

            
        }

        //Helper Method

        public ClaimsDepartment GetClaimsByID (int id)
        {
            foreach(ClaimsDepartment claim in _listOfClaims)
            {
                if (claim.ClaimID == id)
                {
                    return claim;
                }

            }

            return null;
        }
    }
}
