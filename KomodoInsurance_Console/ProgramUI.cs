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

                string userInput = "";

                do
                {
                    userInput = ReadLine();
                    if (!string.IsNullOrEmpty(userInput))
                    {
                        Clear();
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
                    }
                    else
                    {
                        WriteLine("Empty input, please try again!");
                    }
                } while (string.IsNullOrEmpty(userInput));



                ConsoleInfo();
            }
        }

        private void CreateANewBadge()
        {
            Insurance newBadge = new Insurance();
            List<string> newDoorList = new List<string>();

            WriteLine("\nWhat is the number on the badge? \n");

            newBadge.BadgeID = int.Parse(ReadLine());

            WriteLine("\nEnter the door it needs access to: \n");

            bool keepAddingDoors = true;
            string doorToAdd = string.Empty;
            while (keepAddingDoors)
            {
                doorToAdd = ReadLine();
                newDoorList.Add(doorToAdd);
                WriteLine("\nAny other door? (y/n)\n");
                string answer = ReadLine();
                switch (answer)
                {
                    case "yes":
                    case "y":
                        WriteLine("\nEnter the door number: \n");
                        break;
                    case "no":
                    case "n":
                        keepAddingDoors = false;
                        break;
                    default:
                        WriteLine("\nYou entered a wrong input");
                        break;
                }
            }
                _repo.CreateNewBadges(newBadge.BadgeID, newDoorList);
        }


        private void DisplayAllBadges()
        {
            Dictionary<int, List<string>> dic = _repo.GetAllBadges();

            foreach (KeyValuePair<int, List<string>> access in dic)
            {
                WriteLine($"\nBadge ID: {access.Key}\n");
                Write($"Access Doors: ");
                
                foreach (var doors in access.Value)
                {
                    Write(doors + ", ");

                }
                    WriteLine("\n~~~~~~~~~~~~~~~~~~~~~~~~~\n");
            }
        }

        private void EditBadges()
        {
            WriteLine("Enter the badge ID you want to update?\n");
            string userInput = ReadLine();
            int userInputAsInt = int.Parse(userInput);

            var badges = _repo.GetAccessByBadge(userInputAsInt);

            WriteLine($"\nBadge ID: {badges.BadgeID}\n");
            Write("Access Door/s: ");
                
            foreach (string door in badges.AccessDoor)
            {
                Write(door + ", ");
            }

            WriteLine("\n\nWhat do you like to do?\n" +
                "   1. Remove a door\n" +
                "   2. Add a door\n");
            string userChoice = ReadLine();

            switch (userChoice)
            {
                case "1":
                    Write("Which door would you like to remove? \n");
                    string answer = ReadLine();
                    WriteLine("\nDoor removed\n");
                     _repo.RemoveDoors(userInputAsInt, answer);
                    var result = _repo.GetBadgeAccessListByID(userInputAsInt);
                    Write($"Badge ID {badges.BadgeID} has access to door ");
                    foreach (var door in result)
                    {
                        Write(door + ",");
                    }
                    
                    break;
                case "2":
                    WriteLine("Which door would like to add?");
                    string userResponse = ReadLine();
                    List<string> newDoor = new List<string>();
                    newDoor.Add(userResponse);
                    _repo.AddDoorsToBadges(userInputAsInt, newDoor);
                    var newAccess = _repo.GetBadgeAccessListByID(userInputAsInt);
                    Write($"Badge ID {badges.BadgeID} has access to door ");
                    foreach (var door in newAccess)
                    {
                        Write(door + ", ");
                    }

                    break;
                default:
                    WriteLine("You entered a wrong input\n");
                    break;
            }

        }


        private void SeedBadges()
        {
            List<string> list1 = new List<string>();
            list1.Add("A7");
            list1.Add("A5");


            List<string> list2 = new List<string>();
            list2.Add("B7");
            list2.Add("A8");
            list2.Add("A7");

            List<string> list3 = new List<string>();
            list3.Add("A7");


            _repo.CreateNewBadges(333, list1);
            _repo.CreateNewBadges(344, list2);
            _repo.CreateNewBadges(355, list3);


        }

        public void ConsoleInfo()
        {
            WriteLine("\nPress any key to continue");
            ReadKey();
            Clear();
        }
    }
}
