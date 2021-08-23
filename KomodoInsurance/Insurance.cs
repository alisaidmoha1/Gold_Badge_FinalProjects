using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KomodoInsurance
{
    public enum DoorNames { A1, A2, A3, A4, A5, B1, B2, B3, B4, B5}
    public class Insurance
    {
        public int  BadgeID { get; set; }
        public DoorNames AccessDooor { get; set; }

        public Insurance() { }

        public Insurance(int badgeID, DoorNames accessDoor)
        {
            BadgeID = badgeID;
            AccessDooor = accessDoor;
        }
    }
}
