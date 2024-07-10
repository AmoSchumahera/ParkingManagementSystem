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
            // Console configuration
            Console.InputEncoding = Encoding.Unicode;
            Console.OutputEncoding = Encoding.Unicode;
            LoadParkings();
            PrintMenu();
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

        private static void PrintMenu()
        {
            //Console.Clear();

            Console.WriteLine();
            Console.WriteLine("\tМ Е Н Ю");
            Console.WriteLine();
            Console.WriteLine("\tМоля изберете желаното действие:");
            Console.WriteLine();
            Console.WriteLine("\t[1]: Добавяне на нов паркинг");
            Console.WriteLine("\t[2]: Регистрация на превозно средство в паркинг\n\n\t Всички налични места");
            Console.WriteLine("\t[3]: Напускане на паркинг от превозно средство");
            Console.WriteLine("\t[4]: Проверка на наличността на паркоместа");
            Console.WriteLine("\t[x]: Изход от програмата");
            Console.WriteLine();
            Console.Write("\tВашият избор: ");
        }

        private static void LoadParkings()
        {
            StreamReader reader = new StreamReader(filePath);
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

                    List<string> vehicles = new List<string>();
                    for (int i = 4; i < parkingInfo.Length; i++)
                    {
                        vehicles.Add(parkingInfo[i]);
                    }

                    Parking currentParking = new Parking(parkingID, location, totalSpace, availableSpace, vehicles);
                    parkings.Add(currentParking);
                    currentParking.PrintParkingInfo();
                }
            }
        }

        private static void Exit()
        {
            Environment.Exit(0);
        }

        private static void CheckSlots()
        {

        }

        private static void FreeParkings()
        {
            throw new NotImplementedException();
        }

        private static void Registration()
        {
            throw new NotImplementedException();
        }

        private static void ShowActionTitle(string title)
        {
            Console.Clear();
            Console.WriteLine();
            Console.WriteLine("\t" + title);
            Console.WriteLine();
        }

        private static void ShowResultMessage(string message)
        {
            Console.WriteLine();
            Console.WriteLine("\t" + message);
        }

        private static void AddNewParking()
        {
            Console.Write("\tНомер на полет: ");
            string flightID = Console.ReadLine();

            if (Exists(flightId))
            {
                ShowResultMessage("Номерът на полета трябва да е уникален.");
                return;
            }

            Console.Write("\tДестинация: ");
            string destination = Console.ReadLine();

            DateTime departureTime = DateTime.Now;
            DateTime arrivalTime = departureTime;
            try
            {
                Console.Write("\tДата и час на заминаване{дд-мм-гг чч:мм}: ");
                departureTime = DateTime.Parse(Console.ReadLine());

                Console.Write("\tДата и час на пристигане{дд-мм-гг чч:мм}: ");
                arrivalTime = DateTime.Parse(Console.ReadLine());
            }
            catch (Exception)
            {
                ShowResultMessage("Невалидна дата");

                return;
            }

            Console.Write("\tБрой места: ");
            int seatsAvailable = int.Parse(Console.ReadLine());

            Console.Write("\tЦена на полета: ");
            decimal price = decimal.Parse(Console.ReadLine());

            try
            {
                Parking newParking = new Parking(
                ParkingID,
                location,
                totalSpace,
                availableSpace,
                vehicles);

                parkings.Add(newParking);
                SaveParkings();

                ShowResultMessage($"Полет с номер {parkingID} за {destination} е добавен успешно.");
            }
            catch (ArgumentException е)
            {
                ShowResultMessage(е.Message);
            }
        }
        private static void SaveParkings()
        {
            StreamWriter writer = new StreamWriter(filePath, false, Encoding.Unicode);
            using (writer)
            {
                foreach (Parking parking in parkings)
                {
                    writer.WriteLine(parking);
                }
            }
        }
    }
}
