using System.Collections.Generic;
using System.Linq;
using System;

namespace KomodoInsurance
{
    public class Insurance_Repository
    {
        Dictionary<int, List<string>> _listOfBadges = new Dictionary<int, List<string>>();


        public void CreateNewBadges(int badgeID, List<string> doorNames)
        {
            if (_listOfBadges.ContainsKey(badgeID))
            {
                Console.WriteLine("\nERROR! You already have a badge ID with the same number, please change it");

            }
            else
            {

            _listOfBadges.Add(badgeID, doorNames);

            }
        }

        public Dictionary<int, List<string>> GetAllBadges()
        {
            return _listOfBadges;
        }

        public bool AddDoorsToBadges(int badgeID, List<string> newDoorNames)
        {
            Dictionary<int, List<string>> dic = GetAllBadges();

            if (dic.ContainsKey(badgeID))
            {
                List<string> currentDoorList = GetBadgeAccessListByID(badgeID);
                //List<string> updatedDoorList = currentDoorList; 
                foreach (string door in newDoorNames)
                {
                    currentDoorList.Add(door);
                }
                //dic[badgeID] = newDoorNames;
                return true;
            }
            else
            {
                return false;
            }
        }

        //Helper

        public List<string> GetBadgeAccessListByID(int id)
        {
            foreach (KeyValuePair<int, List<string>> kvp in _listOfBadges)
            {
                if (kvp.Key == id)
                {
                    return kvp.Value;
                }
            }

            return null;
        }

        public Insurance GetAccessByBadge(int badgeID)
        {
            Insurance newBadge = new Insurance();

            foreach (KeyValuePair<int, List<string>> accessKeyValue in _listOfBadges)
            {
                if (badgeID == accessKeyValue.Key)
                {
                    newBadge.BadgeID = badgeID;
                    foreach (string accessValue in accessKeyValue.Value)
                    {

                        newBadge.AccessDoor.Add(accessValue);

                    }

                }

            }

            return newBadge;
        }


        public Insurance RemoveDoors(int badgeID, string door)
        {
            Insurance newBadge = new Insurance();
            foreach (var kvp in _listOfBadges)
            {
             newBadge.BadgeID = badgeID;
                
                if (kvp.Key == badgeID)
                {
                     kvp.Value.Remove(door);
                }


            }

            return newBadge;

        }

    }

}




