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
        public int AvailableSpaces
        {
            get 
            { 
                return availableSpaces; 
            }
            set 
            {
                availableSpaces= value; 
            }
        }

        public List<string> Vehicles { get => vehicles; set => vehicles = value; }

        public Parking(string parkingID, string location, int totalSpaces)
        {
            ParkingID = parkingID;
            Location = location;
            TotalSpaces = totalSpaces;
            AvailableSpaces = totalSpaces;
            Vehicles = new List<string>() { "x"};
        }

        public Parking(string parkingID, string location, int totalSpaces, int availableSpaces, List<string> vehicles) : this(parkingID, location, totalSpaces)
        {
            AvailableSpaces = availableSpaces;
            Vehicles = vehicles;
        }

        public override string ToString()
        {
            return $"{ParkingID},{Location},{TotalSpaces},{AvailableSpaces},{string.Join(",", Vehicles)}";
        }
        public void PrintParkingInfo()
        {
            Console.WriteLine($"Информация за паркинг с Id {ParkingID}:\n\tМестоположение - {Location}\n\tОбщо места - {TotalSpaces}\n\tСвободни места - {AvailableSpaces}\n\tКоли в паркинга - {string.Join(", ",Vehicles)}\n");
        }
    }
}