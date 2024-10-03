using Microsoft.Win32.SafeHandles;

class Program
{
    static void Main()
    {
        bool IsRunning = true; 

        while (IsRunning)
        {
            Console.WriteLine("1. Lägg till rapport");
            Console.WriteLine("2. Visa lista över rapporter");
            Console.WriteLine("3. Visa fullständig info om rapport");
            Console.WriteLine("4. Avsluta");
            string choice = Console.ReadLine(); 

            switch(choice)
            {
                case "1": 
                Reporthandler.AddReport();
                break;

                case "2":
                Reporthandler.PrintReports();
                break;

                case "3":
                Reporthandler.Printinforeport();
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
