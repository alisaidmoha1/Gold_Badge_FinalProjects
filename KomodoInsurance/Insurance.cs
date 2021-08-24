using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KomodoInsurance
{
    
    public class Insurance
    {
        
        public int  BadgeID { get; set; }
        public List<string> AccessDoor { get; set; } = new List<string>();

        public Insurance() { }

        public Insurance(int badgeID, List<string> accessDoor)
        {
            BadgeID = badgeID;
            AccessDoor = accessDoor;
        }
    }
}
