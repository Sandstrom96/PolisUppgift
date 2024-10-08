static class Reporthandler
{
    public static List<Report> reports = new List<Report>(); 

    public static void PrintReports()
    {
        for(int i = 0; i < reports.Count; i++)
        {
            Console.Write($"{i + 1}. "); 
            Console.WriteLine($"{reports[i].ReportNumber}"); 
        }
    }
        public static void AddReport()
    {
        Console.WriteLine("Lägg till ett rapportnummer");
        int ReportNumber = int.Parse(Console.ReadLine());
        Console.WriteLine("Ange datum i formatet (YYYY-MM-DD HH:MM) för rapporten");
        DateTime Date = DateTime.Parse(Console.ReadLine());
        Console.WriteLine("Ange vilken station"); 
        string Station = Console.ReadLine(); 
        Console.WriteLine("Ange en beskrivning"); 
        string Description = Console.ReadLine();  
        reports.Add(new Report(ReportNumber, Date, Station, Description));
    }
    public static void Printinforeport()
    {
        Console.WriteLine("Ange nummer på rapporten du vill inspektera"); 
        PrintReports();
        int index = int.Parse(Console.ReadLine());
        int choice = index -1; 

        if (choice >= 0 && choice < reports.Count)
        {
            Console.WriteLine($"{reports[choice].Date.ToString("yyyy-MM-dd HH:mm")}");
            Console.WriteLine($"{reports[choice].Station}"); 
            Console.WriteLine($"{reports[choice].Description}");
        }
        else 
        {
            Console.WriteLine("Ogiltigt nummer");
        }
    }
    public static void Menu()
    {
        Console.WriteLine("1. Lägg till rapport");
        Console.WriteLine("2. Visa lista över rapporter");
        Console.WriteLine("3. Visa fullständig info om rapport");
        string choice = Console.ReadLine(); 

        switch(choice)
        {
            case "1": 
            AddReport();
            break;

            case "2":
            PrintReports();
            break;

            case "3":
            Printinforeport();
            break; 

            default: 
            Console.Clear(); 
            Console.WriteLine("Fel val");
            Menu();
            break;
            
        }

    }
}
public class Report
{
    public int ReportNumber { get; set; }
    public DateTime Date { get; set; }
    public string Station { get; set; }
    public string Description {get; set;}

    public Report(int ReportNumber, DateTime Date, string Station, string Description)
    {
        this.ReportNumber = ReportNumber;
        this.Date = Date;
        this.Station = Station; 
        this.Description = Description; 
    }
}
