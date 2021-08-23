using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KomodoInsurance
{
    public class Insurance_Repository
    {
        Dictionary<int, DoorNames> _listOfBadges = new Dictionary<int, DoorNames>();

        public void CreateNewBadges(int badgeID, DoorNames doorNames)
        {
            _listOfBadges.Add(badgeID, doorNames);
        }

        public Dictionary<int, DoorNames> GetAllBadges()
        {
            return _listOfBadges;
        }

        public bool UpdateBadges(int badgeID, DoorNames newDoorNames)
        {
            Insurance oldAccess = GetAccessByBadge(badgeID);

            if (oldAccess == null)
            {
                oldAccess.AccessDooor = newDoorNames;
                return true;
            } else
            {
                return false;
            }
        }

        //Helper

        public Insurance GetAccessByBadge(int badgeID)
        {
            foreach (KeyValuePair<int, DoorNames> accessKeyValue in _listOfBadges)
            {
               badgeID = accessKeyValue.Key;
            }

            return null;
        }

    }

}
