using Microsoft.Win32.SafeHandles;
using System.Text.Json;

class Program
{
    static void Main()
    {
        LoadData();
        bool IsRunning = true; 

        while (IsRunning)
        {
            Console.WriteLine("1. Utryckningar");
            Console.WriteLine("2. Rapporter");
            Console.WriteLine("3. Personal");
            Console.WriteLine("5. Skriv ut utryckning med rapport");
            Console.WriteLine("4. Avsluta");
            string choice = Console.ReadLine(); 

            switch(choice)
            {
                case "1": 
                Console.Clear();
                CrimeHandler.PrintResponses();
                break;

                case "2":
                Console.Clear();
                MainReports.MenuReports();
                break;

                case "3":
                Console.Clear();
                MainEmployeehandler.MenuEmployee(); 
                break; 

                case "4":
                SaveData();
                IsRunning = false;
                break;

                case "5":
                CrimeHandler.AddCrime();
                Console.WriteLine("Lägg till rapport");
                //Reporthandler.AddReport();
                break;

                default: 
                Console.Clear(); 
                Console.WriteLine("Fel val");
                continue;
                
            }

        }

    }
    static void LoadData()
    {
        EmployeeHandler.employees = JsonSerializer.Deserialize<List<Employee>>(File.ReadAllText("Employees.json"));
        CrimeHandler.responses = JsonSerializer.Deserialize<List<EmergencyResponse>>(File.ReadAllText("Responses.json"));
        Reporthandler.reports = JsonSerializer.Deserialize<List<Report>>(File.ReadAllText("Reports.json"));
    }

    static void SaveData()
    {
        File.WriteAllText("Reports.json", JsonSerializer.Serialize(Reporthandler.reports));
        File.WriteAllText("Responses.json", JsonSerializer.Serialize(CrimeHandler.responses));
        File.WriteAllText("Employees.json", JsonSerializer.Serialize(EmployeeHandler.employees));
    }
}
