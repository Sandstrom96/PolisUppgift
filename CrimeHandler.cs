using Microsoft.VisualBasic;

static class CrimeHandler
{
    public static List<EmergencyResponse> responses = new List<EmergencyResponse>();
    public static void PrintCrimeType()
    {
        for (int i = 1; i <= Enum.GetValues(typeof(Crimes)).Length; i++)
        {
            Console.Write($"{i}. ");
            Console.WriteLine(Enum.GetName(typeof(Crimes), i));
        }
    }
    public static void AddCrime()
    {
        bool validInput = false;
        Crimes crime = 0;
        while (!validInput)
        {
            Console.WriteLine("Välj typ av brott");
            PrintCrimeType();
            if (int.TryParse(Console.ReadLine(), out int choice))
            {
                if (choice > 0 && choice <= Enum.GetValues(typeof (Crimes)).Length)
                {
                    crime = (Crimes)choice;
                    validInput = true;
                }
                else
                {
                    Console.Clear();
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Fel inmatning!");
                    Console.ForegroundColor = ConsoleColor.White;
                }
            }
        }

        validInput = false;
        string place = "";
        while (!validInput)
        {
            Console.Write("Ange plats: ");
            place = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(place))
            {
                Console.WriteLine("Platsen kan ej vara tom");
            }
            else if (!System.Text.RegularExpressions.Regex.IsMatch(place, @"^[a-öA-Ö0-9]+$"))
            {
                Console.WriteLine("Kan endast innehålla bokstäver/siffror. Försök igen!");
            }
            else
            {
                validInput = true;
            }
        }
        
        Console.Write("Ange tid i formatet(YYYY-MM-DD HH:MM): ");
        DateTime dateTime = DateTime.Parse(Console.ReadLine());

        List<string> officers = new List<string>();
        bool isRunning = true;
        while (isRunning)
        {
            Console.WriteLine("Vilka deltog?");
            string officer = EmployeeHandler.ChooseEmployee();
            officers.Add(officer);
            validInput = false;
            while (!validInput)
            {
                Console.WriteLine("Vill du lägga till fler? j/n");
                string choice = Console.ReadLine();
                if (choice.ToLower() == "j")
                {
                    validInput = true;
                }
                else if (choice.ToLower() == "n")
                {
                    isRunning = false;
                    validInput = true;
                }
                else
                {
                    Console.Clear();
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Fel inmatning! Försök igen.");
                    Console.ForegroundColor = ConsoleColor.White;
                }
            }
        }
        
        responses.Add(new EmergencyResponse(crime, place, dateTime, officers));
    }
    public static void PrintResponses()
    {
        for (int i = 0; i < responses.Count; i++)
        {
            
            Console.WriteLine($"Brott: {responses[i].crime}");
            Console.WriteLine($"Plats: {responses[i].place}");
            Console.WriteLine($"Tid: {responses[i].dateTime.ToString("yyyy-MM-dd HH:mm")}");
            Console.WriteLine($"Deltagare: {string.Join(", ", responses[i].officer)}");
        }
    }
        public static void Menu()
    {
        Console.WriteLine("1. lägg till brott");
        Console.WriteLine("2. Visa lista över utryckningar");
        var choice = Console.ReadKey().Key;

        switch (choice)
        {
            case ConsoleKey.D1:
            AddCrime(); 
            break;

            case ConsoleKey.D2:
            PrintResponses();
            break;

            default:
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Fel val");
            Console.ForegroundColor = ConsoleColor.White;
            Menu();
            break;

        }
    }
}
enum Crimes
    {
        Inbrott = 1,
        Mord = 2,
        Stöld = 3,
        Trafikbrott = 4,
        Bråk = 5
    }
class EmergencyResponse
{
    public Crimes crime { get; set; }
    public string place { get; set; }
    public List<string> officer { get; set; }
    public DateTime dateTime { get; set; } 

    public EmergencyResponse(Crimes crime, string place, DateTime dateTime, List<string> officer)
    {
        this.crime = crime;
        this.place = place;
        this.dateTime = dateTime;
        this.officer = officer;
    }
}

