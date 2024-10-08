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
        bool isRunning = true;
        Console.WriteLine("Välj typ av brott");
        PrintCrimeType();
        Crimes crime = Enum.Parse<Crimes>(Console.ReadLine());
        Console.Write("Ange plats: ");
        string place = Console.ReadLine();
        Console.Write("Ange tid i formatet(YYYY-MM-DD HH:MM): ");
        DateTime dateTime = DateTime.Parse(Console.ReadLine());
        Console.WriteLine("Vilka deltog?");
        string officer = "";
        List<string> officers = new List<string>();
        while (isRunning)
        {
            officer = EmployeeHandler.ChooseEmployee();
            Console.WriteLine("");
            officers.Add(officer);
            isRunning = false;
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

