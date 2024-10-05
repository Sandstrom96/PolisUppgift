using Microsoft.Win32.SafeHandles;

class Program
{
    static void Main()
    {
        bool IsRunning = true; 

        while (IsRunning)
        {
            Console.WriteLine("1. Registrering av utryckningar");
            Console.WriteLine("2. Rapporter");
            Console.WriteLine("3. Personal");
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

                default: 
                Console.Clear(); 
                Console.WriteLine("Fel val");
                continue;
                
            }

        }

    }
}
