using Microsoft.Win32.SafeHandles;
using System.Text.Json;

class Program
{
    static void Main()
    {
        //LoadData();
        /*bool IsRunning = true; 

        while (IsRunning)
        {
            Console.WriteLine("----Polisen----");
            Console.WriteLine("1. Utryckningar");
            Console.WriteLine("2. Rapporter");
            Console.WriteLine("3. Personal");
            //Console.WriteLine("5. Skriv ut utryckning med rapport");
            Console.WriteLine("4. Avsluta");
            var choice = Console.ReadKey().Key; 

            switch(choice)
            {
                case ConsoleKey.D1: 
                Console.Clear();
                CrimeHandler.Menu();
                break;

                case ConsoleKey.D2:
                Console.Clear();
                Reporthandler.Menu();
                break;

                case ConsoleKey.D3:
                Console.Clear();
                EmployeeHandler.Menu(); 
                break; 

                case ConsoleKey.D4:
                SaveData();
                IsRunning = false;
                break;

                //case ConsoleKey.D5:
                //break;

                default: 
                Console.Clear(); 
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Fel val");
                Console.ForegroundColor = ConsoleColor.White;
                continue;
                
            }

        }*/
        while (true)
        Reporthandler.Menu();

    }
    /*static void LoadData()
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
    }*/
}
