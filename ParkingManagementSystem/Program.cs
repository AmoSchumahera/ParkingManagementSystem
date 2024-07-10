using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Text;

namespace ParkingManagementSystem
{
    class Program
    {
        private const string filePath = "../../../parkings.txt";
        private static List<Parking> parkings = new List<Parking>();
        private static string menuActionChoice;
        static void Main(string[] args)
        {
            LoadParkings();
            while (true)
            {
                menuActionChoice = Console.ReadLine();
                switch (menuActionChoice)
                {
                    case "1":
                        ShowActionTitle("Добавяне на нов паркинг");
                        AddNewParking();
                        break;
                    case "2":
                        ShowActionTitle("Регистрация на превозно средство в паркинг\n\n\t Всички налични места");
                        Registration();
                        break;
                    case "3":
                        ShowActionTitle("Напускане на паркинг от превозно средство");
                        FreeParkings();
                        break;
                    case "4":
                        ShowActionTitle("Проверка на наличността на паркоместа");
                        CheckSlots();
                        break;
                    case "x" or "X":
                        Exit();
                        break;
                    default:
                        // todo: implement default case

                        break;
                }
            }
        }

        private static void LoadParkings()
        {
            StreamReader reader = new StreamReader(filePath, Encoding.Unicode);
            using (reader)
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    string[] parkingInfo = line.Split(',');
                    string parkingID = parkingInfo[0];
                    string location = parkingInfo[1];
                    int totalSpace = int.Parse(parkingInfo[2]);
                    int availableSpace = int.Parse(parkingInfo[3]);
                    int seatsAvailable = int.Parse(parkingInfo[4]);
                    string vehicle = (parkingInfo[5]);

                    Parking currentFlight = new Parking(parkingID,location,totalSpace);
                    parkings.Add(currentFlight);
                }
            }
        }

        private static void Exit()
        {
            throw new NotImplementedException();
        }

        private static void CheckSlots()
        {
            throw new NotImplementedException();
        }

        private static void FreeParkings()
        {
            throw new NotImplementedException();
        }

        private static void Registration()
        {
            throw new NotImplementedException();
        }

        private static void ShowActionTitle(string v)
        {
            throw new NotImplementedException();
        }

        private static void AddNewParking()
        {
            throw new NotImplementedException();
        }
    }
}
