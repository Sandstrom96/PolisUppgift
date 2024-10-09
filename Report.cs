using Microsoft.VisualBasic;

static class Reporthandler
{
    public static List<Report> reports = new List<Report>(); 

    public static void PrintReports()
    {
        for(int i = 0; i < reports.Count; i++)
        { 
            Console.WriteLine($"Rapportnummer: {reports[i].ReportNumber}"); 
        }
        Console.WriteLine("Tryck en tangent för att fortsätta");
        Console.ReadKey(true);
    }
        public static void AddReport()
    {    
        Console.WriteLine("Lägg till ett rapportnummer");
        int reportNumber = 0;
        try
        {
            int.TryParse(Console.ReadLine(), out int nr);
            reportNumber = nr;
        }
        catch(Exception)
        {
            Console.WriteLine("Fel inmatning! Ange ett heltal.");
        }
            
        Console.WriteLine("Ange datum i formatet (YYYY-MM-DD HH:MM) för rapporten");
        DateTime date = DateTime.Parse(Console.ReadLine());
        Console.WriteLine("Ange vilken station"); 
        string station = Console.ReadLine(); 
        Console.WriteLine("Ange en beskrivning"); 
        string description = Console.ReadLine();  
        reports.Add(new Report(reportNumber, date, station, description));
    }
    public static void Printinforeport()
    {
        int index = 0;
        bool validInput = false;
        if (reports.Count == 0)
        {
            Console.WriteLine("Listan är tom.");            
        }
        else
        {
            while (!validInput)
            {
                Console.WriteLine("----Lista av rapportnummer----");
                for(int i = 0; i < reports.Count; i++)
                { 
                    Console.WriteLine($"Rapportnummer: {reports[i].ReportNumber}"); 
                }
                Console.Write("Ange rapportnummer: ");
                if (int.TryParse(Console.ReadLine(), out int input))
                {
                    index = reports.FindIndex(r => r.ReportNumber == input);
                        
                    if (index != -1)
                    {    
                        validInput = true;
                    }
                    else
                    {
                        Console.Clear();
                        Console.WriteLine($"Kan inte hitta rapportnummer: {input} i listan");
                    }
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Fel inmatning! Ange ett heltal.");
                    Console.ForegroundColor = ConsoleColor.White;
                }
            }
        }

        if (index >= 0 && index < reports.Count)
        {
            Console.WriteLine($"{reports[index].Date.ToString("yyyy-MM-dd HH:mm")}");
            Console.WriteLine($"{reports[index].Station}"); 
            Console.WriteLine($"{reports[index].Description}");
        }
        Console.ReadKey(true);
        
    }
    public static void Menu()
    {
        bool validInput = false;

        while (!validInput)
        {
            Console.WriteLine("1. Lägg till rapport");
            Console.WriteLine("2. Visa lista över rapporter");
            Console.WriteLine("3. Visa fullständig info om en rapport");
            Console.WriteLine("4. Tillbaka till huvudmenyn");
            var choice = Console.ReadKey().Key; 

            switch(choice)
            {
                case ConsoleKey.D1: 
                    Console.Clear();
                    AddReport();
                    validInput = true;
                    break;

                case ConsoleKey.D2:
                    Console.Clear();
                    PrintReports();
                    validInput = true;
                    break;

                case ConsoleKey.D3:
                    Console.Clear();
                    Printinforeport();
                    validInput = true;
                    break;

                case ConsoleKey.D4:
                validInput = true;
                    break;

                default: 
                    Console.Clear(); 
                    Console.WriteLine("Fel val");
                    break;
                
            }
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
