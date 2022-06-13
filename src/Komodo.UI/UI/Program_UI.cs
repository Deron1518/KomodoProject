using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


    public class Program_UI
    {
        private readonly DeveloperRepo _dRepo = new DeveloperRepo();
        private readonly DevTeamRepo _dtRepo = new DevTeamRepo();

        public void Run()
        {
            SeedData();

            RunMenu();
        }

        private void RunMenu()
        {
            bool continueToRun = true;

            while(continueToRun)
            {
                Console.Clear();
                System.Console.WriteLine("Please make a selection: \n " +
                "1. Developer List \n " +
                "2. Add Developer \n " +
                "3. Remove Developer \n " +
                "4. Find Developer by ID \n" +
                "5. Developers With PluralSight \n" +
                "6. Create Developer Team \n " +
                "7. Add Developer to Team \n " +
                "8. Remove Developer from Team" 
                );

                string userInput = Console.ReadLine();
                switch(userInput)
                {
                    case "1":
                        ShowAllDevelopers();
                        break;
                    case "2":
                        CreateNewDeveloper();
                        break;
                    case "3":
                        RemoveDeveloper();
                        break;
                    case "4":
                        ShowDeveloperByID();
                        break;
                    case "5":
                        CreateNewDevTeam();
                        break;
                    case "6":
                        AddDeveloperToTeam();
                        break;
                    case "7":
                        RemoveDeveloperFromTeam();
                        break;
                    case "8":
                        continueToRun = false;
                        System.Console.WriteLine("Have A Good Day!");
                        PauseUntilKeyPress();
                        break;
                    default:
                        System.Console.WriteLine("Don't be dumb, enter a number!");
                        PauseUntilKeyPress();
                    break;
                }
            }
        }

        private void PauseUntilKeyPress()
        {
            System.Console.WriteLine("Press any key you desire to continue.");
            Console.ReadKey();
        }

        private void ShowAllDevelopers()
        {
            Console.Clear();
            System.Console.WriteLine("---Damn Good Developers!---");
            List<DeveloperData> ListOfDevelopers = _dRepo.GetAllDevelopers();
            foreach(DeveloperData data in ListOfDevelopers)
            {
                DisplayDeveloper(data);
            }
            PauseUntilKeyPress();
        }

        private void DisplayDeveloper(DeveloperData data)
        {
            System.Console.WriteLine($"Developer Name: {firstName + lastName} \n" + $"Developer ID: {id} \n PluralSight Access: {pluralSightAccess} ");
        }

        private void SeedData()
        {
            DeveloperData ryan = new DeveloperData("Ryan", "Williams", 1, true);
            DeveloperData terri = new DeveloperData("Terri", "Watt", 2, false);
            DeveloperData patrick = new DeveloperData("Patrick", "Mahomes", 3, true);

            _dRepo.AddDeveloperToDataBase(ryan);
            _dRepo.AddDeveloperToDataBase(terri);
            _dRepo.AddDeveloperToDataBase(patrick);

            DevTeam alpha = new DevTeam("Alpha Team ");
            DevTeam bravo = new DevTeam("Bravo Team");
            DevTeam charlie = new DevTeam("Charlie Team");

            _dtRepo.AddDevTeamToDataBase(alpha);
            _dtRepo.AddDevTeamToDataBase(bravo);
            _dtRepo.AddDevTeamToDataBase(charlie);
        }

        private void CreateNewDeveloper()
        {
            Console.Clear();
            DeveloperData data = new DeveloperData();
            System.Console.WriteLine("Please enter first name: ");
            data.FirstName = Console.ReadLine();

            System.Console.WriteLine("Please enter last name: ");
            data.LastName = Console.ReadLine();

            System.Console.WriteLine("Does this developer have access to Pluralsight?(enter true or false): ");
            data.PluralsightAccess = Console.ReadLine();

        }

        private void RemoveDeveloper()
        {
            Console.Clear();
            System.Console.WriteLine("Developer Removal Page");
            var DeveloperData = _dRepo.GetDeveloperById();

            foreach(DeveloperData d in ListOfDevelopers)
            {
                DisplayDeveloper(d);
            }
            
            try
            {
                System.Console.WriteLine("Please select a developer by ID: \n");
                int userInputSelectedDeveloper = int.Parse(Console.ReadLine());
                bool isSuccessful = _dRepo.RemoveDeveloperDataFromDataBase(userInputSelectedDeveloper);

                if(isSuccessful)
                {
                    System.Console.WriteLine("See ya developer!");
                }
                else
                {
                    System.Console.WriteLine("Weird.... developer not removed?");
                }
            }
            catch
            {
                System.Console.WriteLine("Can't delete someone that was never there :/ ");
            }
            PauseUntilKeyPress();
        }
    
        private void ShowDeveloperByID()
        {
            Console.Clear();
            System.Console.WriteLine("List O Developers");
            var developer = _dRepo.GetAllDevelopers();

            foreach(DeveloperData d in ListOfDevelopers)
            {
                DisplayDeveloper(d);
            }
            try
            {
                System.Console.WriteLine("Please select a developer by ID: ");
                int userInput = int.Parse(Console.ReadLine());
                var selectedDeveloper = _dRepo.GetDeveloperById(userInput);

                if(selectedDeveloper != null)
                {
                    DisplayDeveloper(selectedDeveloper);
                }
                else
                {
                    System.Console.WriteLine("Who????");
                }
            }
            catch
            {
                System.Console.WriteLine("Sorry invalid selection.");
            }
        }
    
        private void CreateNewDevTeam()
        {
             Console.Clear();
            DevTeam data = new DevTeam();
            System.Console.WriteLine("Please enter Team Name: ");
            data.Name = Console.ReadLine();
        }

        private void AddDeveloperToTeam()
        {
            Console.Clear();
            var availTeams = _dtRepo.GetAllTeams();
            var currentDevelopers = _dRepo.GetAllDevelopers();
            foreach(var t in availTeams)
            {
                DisplayTeamList(t);
            }

            System.Console.WriteLine("Please select a team by ID: \n");
            int userInput = int.Parse(Console.ReadLine());
            var selectedTeam = _dtRepo.GetTeamByID(userInput);

            if(selectedTeam != null)
            {
                Console.Clear();
                System.Console.WriteLine("Please select developer by ID \n");
                int developerSelected = int.Parse(Console.ReadLine());
                var selectedDeveloper = _dRepo.GetDeveloperById(developerSelected);

                if(selectedDeveloper != null)
                {
                    availTeams.DeveloperData.Add(selectedDeveloper);
                    currentDevelopers.Remove(selectedDeveloper);
                }
                else
                {
                    System.Console.WriteLine("Darn no developer added");
                }
            }
            else
            {
                System.Console.WriteLine("Sorry this team does not exist, maybe you should create a new one!");
            }
        }

        private void RemoveDeveloperFromTeam()
        {
            Console.Clear();
            var availTeams = _dtRepo.GetAllTeams();
            var currentDevelopers = _dRepo.GetAllDevelopers();
            foreach(var t in availTeams)
            {
                DisplayTeamList(t);
            }

            System.Console.WriteLine("Please select a team by ID: \n");
            int userInput = int.Parse(Console.ReadLine());
            var selectedTeam = _dtRepo.GetTeamByID(userInput);

            if(selectedTeam != null)
            {
                Console.Clear();
                System.Console.WriteLine("Please select developer by ID \n");
                int developerSelected = int.Parse(Console.ReadLine());
                var selectedDeveloper = _dRepo.GetDeveloperById(developerSelected);
                if(selectedDeveloper != null)
                {
                    availTeams.DeveloperData.Remove(selectedDeveloper);
                    currentDevelopers.Add(selectedDeveloper);
                }
                else
                {
                    System.Console.WriteLine("Darn no developer removed");
                }
            }
            else
            {
                System.Console.WriteLine("Sorry developer was not removed, looks like you're stuck with them!");
            }
        }
    

    }
