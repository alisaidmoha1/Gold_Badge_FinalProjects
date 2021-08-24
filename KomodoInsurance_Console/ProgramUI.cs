using KomodoInsurance;
using System.Collections.Generic;
using static System.Console;

namespace KomodoInsurance_Console
{
    public class ProgramUI
    {
        private Insurance_Repository _repo = new Insurance_Repository();
       
        public void Run()
        {
           SeedBadges();
            Menu();
        }

        private void Menu()
        {
            bool IsRunning = true;
            while (IsRunning)
            {
                WriteLine("Hello Security Admin, What you like to do? \n" +
                    "   1. Add a badge\n" +
                    "   2. Edit a badge\n" +
                    "   3. List All badges\n" +
                    "   4. Exit");

                string userInput = ReadLine();

                switch (userInput)
                {
                    case "1":
                        CreateANewBadge();
                        break;
                    case "2":
                        EditBadges();
                        break;
                    case "3":
                        DisplayAllBadges();
                        break;
                    case "4":
                        IsRunning = false;
                        WriteLine("GoodBye!");
                        break;
                    default:
                        WriteLine("Please enter a valid input. Thank you!");
                        break;
                }

                ConsoleInfo();
            }
        }

        private void CreateANewBadge()
        {
            Insurance newBadge = new Insurance();
            List<string> newDoorList= new List<string>();

            WriteLine("What is the number on the badge?");
            newBadge.BadgeID = int.Parse(ReadLine());

            WriteLine("Enter the door it needs access to: \n");

            bool keepAddingDoors = true;
            string doorToAdd = string.Empty;
            while (keepAddingDoors)
            {
                doorToAdd= ReadLine();
                newDoorList.Add(doorToAdd);
                WriteLine("Any other door? (y/n)\n");
                switch(ReadLine().ToLower())
                {
                    case "yes":
                    case "y":
                        WriteLine("Enter the door number: \n");
                            break;
                    case "no":
                    case "n":
                        keepAddingDoors = false;
                        break;
                    default:
                        WriteLine("You entered a wrong input");
                        break;
                }
            }
            newBadge.AccessDoor = newDoorList;
            _repo.CreateNewBadges(newBadge.BadgeID, newDoorList);
        }

        private void DisplayAllBadges()
        {
            Dictionary<int, List<string>> dic = _repo.GetAllBadges();

            foreach (KeyValuePair<int,List<string>> access in dic)
            {
                WriteLine($"\n\nBadge ID: {access.Key}\n");
                Write($"Access Doors: ");
                foreach (var doors in access.Value)
                {   
                    Write(doors + ", ");

                }
            }

            ConsoleInfo();
        }

        private void EditBadges()
        {
            WriteLine("Enter the badge ID you want to update?");
            string userInput = ReadLine();
            int userInputAsInt = int.Parse(userInput);

           var badges = _repo.GetAccessByBadge(userInputAsInt);

            WriteLine($" Badge ID: {badges.BadgeID}\n" +
                $"Door access: ");
            foreach ( string door in badges.AccessDoor)
            {
                WriteLine(door);
            }

            WriteLine("What do you like to do?\n" +
                "1. Remove a door\n" +
                "2. Add a door");
            string userChoice = ReadLine();

            switch(userChoice)
            {
                case "1":
                    Write("Which door would you like to remove? ");
                    string answer = ReadLine();
                     _repo.RemoveDoors(answer);
                    WriteLine("Door removed");
                    WriteLine($"{badges.BadgeID} has access to door");
                    foreach (string door in badges.AccessDoor)
                    {
                         WriteLine(door);
                    }
                    break;
                case "2":
                    CreateANewBadge();
                    break;
                default:
                    WriteLine("You entered a wrong input");
                    break;
            }

        }


        private void SeedBadges()
        {
            List<string> list1 = new List<string>();
            list1.Add("A7");
            list1.Add("A8");


            List<string> list2 = new List<string>();
            list2.Add("A7");
            list2.Add("A8");


            _repo.CreateNewBadges(333, list1);
            _repo.CreateNewBadges(344, list2);

        }

        public void ConsoleInfo()
        {
            WriteLine("\nPress any key to continue");
            ReadKey();
            Clear();
        }
    }
}
