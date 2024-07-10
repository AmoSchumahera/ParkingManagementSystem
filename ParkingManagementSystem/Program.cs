using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
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
            Console.Clear();

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
                }
            }
        }

        private static void Exit()
        {
            throw new NotImplementedException();
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

            ListParkings();

            Console.Write("\tВъведи Id на паркинга: ");
            string parkingId = Console.ReadLine();
            if (ParkingExists(parkingId))
            {
                Parking selectedParking = parkings.FirstOrDefault(p => p.ParkingID == parkingId);

                Console.WriteLine($"\tБрой свободни места: {selectedParking.AvailableSpaces}");

                if (selectedParking.AvailableSpaces <= 0)
                {
                    Console.WriteLine($"\tСъжаляваме, но на този паркинг няма свободни места.");
                }
                else
                {
                    selectedParking.AvailableSpaces = -1;
                    Console.WriteLine($"\tПоздравления. Успешно запазихте място в паркинг с Id {selectedParking.ParkingID}");
                    Console.WriteLine($"\tПожелаваме Ви приятен den.");
                    SaveParkings();
                }
            }
            else
            {
                Console.WriteLine($"\tНевалиден номер на полет: {parkingId}");
            }

        }

        private static void SaveParkings()
        {
            throw new NotImplementedException();
        }

        private static bool ParkingExists(string parkingId)
        {
            if (parkings.Find(p => p.ParkingID == parkingId) != null)
            {
                return true;
            }
            return false;
        }

        private static void ListParkings()
        {
            foreach (var parking in parkings)
            {
                parking.PrintParkingInfo()
            }
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
            throw new NotImplementedException();
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
