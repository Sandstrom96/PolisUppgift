public class Report
{
    public int ReportNumber;
    public DateTime Date;
    public string Station;
    public string Description {get; set;}

    public Report(int ReportNumber, DateTime Date, string Station, string Description)
    {
        this.ReportNumber = ReportNumber;
        this.Date = Date;
        this.Station = Station; 
        this.Description = Description; 
    }
}

static class Reporthandler
{
    static List<Report> reports = new List<Report>(); 

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
}