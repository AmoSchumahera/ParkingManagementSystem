using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkingManagementSystem
{
    class Parking
    {
        private string parkingID;
        private string location;
        private int totalSpaces;
        private int availableSpaces;
        private List<string> vehicles;
        public string ParkingID
        {
            get
            {
                return parkingID;
            }
            set
            {
                parkingID = value;
            }
        }
        public string Location
        {
            get
            {
                return location;
            }
            set
            {
                location = value;
            }
        }
        public int TotalSpaces
        {
            get
            {
                return totalSpaces;
            }
            set
            { 
                totalSpaces = value; 
            }
        }
    }
}