using Microsoft.Win32.SafeHandles;

class Program
{
    static void Main()
    {
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
}
