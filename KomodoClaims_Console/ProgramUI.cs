using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KomodoClaims;
using static System.Console;

namespace KomodoClaims_Console
{
    public class ProgramUI
    {
        private ClaimsDepartment_Repository _repo = new ClaimsDepartment_Repository();
        public void Run()
        {
            SeedClaimList();
            Menu();
        }

        private void Menu()
        {

            bool isRunning = true;
            while (isRunning)
            {
                WriteLine("\n~~~~~~~~~~~~~~~~~~~~~");
                WriteLine("Select a menu option: \n" +
                    "   1. Display all claims\n" +
                    "   2. Take care of next claim\n" +
                    "   3. Search claim by ID \n" +
                    "   4. Enter a new claim\n" +
                    "   5. Exit");

                string userInput = ReadLine();

                switch (userInput)
                {
                    case "1":
                        DisplayAllClaims();
                        break;
                    case "2":
                        //Take care of next claim
                        break;
                    case "3":
                        //search claim by id
                        break;
                    case "4":
                        CreateNewClaim();
                        break;
                    case "5":
                    case "Exit":
                    case "EXIT":
                    case "exit":
                        isRunning = false;
                        WriteLine("Goodbye!!");
                        WriteLine("Press any key to exit");
                        ReadKey();
                        break;
                    default:
                        ForegroundColor = ConsoleColor.Red;
                        BackgroundColor = ConsoleColor.White;
                        WriteLine("\nInvalid input, please try again!");
                        ResetColor();
                        break;
                }

                ConsoleInfo();


            }

        }

        private void DisplayAllClaims()
        {
            Clear();
            List<ClaimsDepartment> claims = _repo.GetAllClaims();

            foreach (ClaimsDepartment claim in claims)
            {
                WriteLine($"Claim ID: {claim.ClaimID},\n" +
                        $"Type: {claim.TypeOfClaim}, \n" +
                        $"Description: {claim.Description},\n" +
                        $"Amount: {claim.ClaimAmount},\n" +
                        $"Date of accident: {claim.DateOfAccident},\n" +
                        $"Date of claim: {claim.DateOfClaim},\n" +
                        $"IsValid: {claim.IsValid}");
                WriteLine("=====================\n\n");

                
            }

        }

        private void CreateNewClaim()
        {
            Clear();

            ClaimsDepartment newClaim = new ClaimsDepartment();

            WriteLine("Enter the claim id: ");
            newClaim.ClaimID = int.Parse(ReadLine());

            WriteLine("Choose the claim Type: \n" +
                "   1. Car\n" +
                "   2. House\n" +
                "   3.Theft\n");
            int userInput = int.Parse(ReadLine());
            newClaim.TypeOfClaim = (ClaimType)userInput;

            WriteLine("Enter a claim description: ");
            newClaim.Description = ReadLine();

            WriteLine("Amount of damage: ");
            newClaim.ClaimAmount = decimal.Parse(ReadLine());

            WriteLine("Date of accident: ");
            newClaim.DateOfAccident = DateTime.Parse(ReadLine());

            WriteLine("Date of claim: ");
            newClaim.DateOfClaim = DateTime.Parse(ReadLine());

            _repo.CreatNewClaim(newClaim);
        }


        public void SeedClaimList()
        {
            ClaimsDepartment claim1 = new ClaimsDepartment(225, ClaimType.Car, "car crush in i-70", 17000m, new DateTime(2021, 8, 22), new DateTime(2021, 7, 20), true);
            ClaimsDepartment claim2 = new ClaimsDepartment(227, ClaimType.Home, "burglary", 350m, new DateTime(2021, 2, 22), new DateTime(2021, 8, 20), false);
            ClaimsDepartment claim3 = new ClaimsDepartment(228, ClaimType.Theft, "phone theft", 1100m, new DateTime(2021, 1, 20), new DateTime(2020, 12, 19), true);
            ClaimsDepartment claim4 = new ClaimsDepartment(229, ClaimType.Car, "car theft", 25000m, new DateTime(2021, 7, 22), new DateTime(2021, 9, 20), true);
            ClaimsDepartment claim5 = new ClaimsDepartment(230, ClaimType.Home, "flooding", 18600m, new DateTime(2021, 3, 22), new DateTime(2021, 6, 20), false);
            ClaimsDepartment claim6 = new ClaimsDepartment(235, ClaimType.Theft, "porch pirate", 66m, new DateTime(2021, 4, 22), new DateTime(2021, 4, 25), true);

            _repo.CreatNewClaim(claim1);
            _repo.CreatNewClaim(claim2);
            _repo.CreatNewClaim(claim3);
            _repo.CreatNewClaim(claim4);
            _repo.CreatNewClaim(claim5);
            _repo.CreatNewClaim(claim6);

        }

        private void ConsoleInfo()
        {
            WriteLine("Press any key to continue");
            ReadKey();
            Clear();
        }
    }
}
