using System.ComponentModel.Design;
using System.Net;
using System.Xml.Serialization;
using Microsoft.VisualBasic;

static class EmployeeHandler
{
    public static List<Employee> employees = new List<Employee>();
    static Random rnd = new Random();
    public static void AddEmployee()
    {
        string firstName = "";
        string lastName = "";
        bool validInput = false;
        
        Console.WriteLine("---Lägg till anställd---");

        while (!validInput)
        {
            Console.Write("Förnamn: ");
            firstName = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(firstName))
            {
                Console.WriteLine("Förnamn kan ej vara tom");
            }
            else if (!System.Text.RegularExpressions.Regex.IsMatch(firstName, @"^[a-öA-Ö]+$"))
            {
                Console.WriteLine("Kan endast innehålla bokstäver. Försök igen!");
            }
            else
            {
                validInput = true;
            }
        }
        validInput = false;
        while (!validInput)
        {
            Console.Write("Efternamn: ");
            lastName = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(lastName))
            {
                Console.WriteLine("Efternamn kan ej vara tom");
            }
            else if (!System.Text.RegularExpressions.Regex.IsMatch(lastName, @"^[a-zA-Z]+$"))
            {
                Console.WriteLine("Kan endast innehålla bokstäver. Försök igen!");
            }
            else
            {
                validInput = true;
            }
        }
        int employeeNumber = rnd.Next(1000,10000);
        for (int i = 0; i < employees.Count; i++)
        {
            if(employeeNumber == employees[i].employeeNumber)
            {
                employeeNumber = rnd.Next(1000,10000);
            }
        }
        Console.WriteLine($"Tjänstnummer: {employeeNumber}");
        Console.WriteLine("Klicka på någon tanget för att fortsätta");
        Console.ReadKey(true);
            
        employees.Add(new Employee(firstName, lastName, employeeNumber));
    }
    public static void ListEmployees()
    {
        if (employees.Count == 0)
        {
            Console.WriteLine("Listan är tom.");
        }
        else
        {
            for (int i = 0; i < employees.Count; i++)
            {
                Console.WriteLine($"{employees[i].firstName} {employees[i].lastName} Tjänstnummer: {employees[i].employeeNumber}");
            }
        }
    }
    public static string ChooseEmployee()
    {
        if (employees.Count == 0)
        {
            Console.WriteLine("Listan är tom.");
            AddEmployee();
            return $"{employees[0].firstName} {employees[0].lastName}";
        }
        else
        {
            while (true)
            {
                Console.WriteLine("----Lista av personal----");
                ListEmployees();
                Console.Write("Ange tjänstnummer: ");
                if (int.TryParse(Console.ReadLine(), out int choice))
                {
                    try
                    {
                    var employee = employees.FirstOrDefault(e => e.employeeNumber == choice);
                    string officer = $"{employee.firstName} {employee.lastName}";
                    return officer;
                    }
                    catch (Exception)
                    {
                        Console.Clear();
                        Console.WriteLine($"Kan inte hitta tjänstnummer: {choice} i listan");
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
    }
    public static void Menu()
    {
        Console.WriteLine("1. Lägg till en ny anställd");
        Console.WriteLine("2. Visa alla anställda");
        var choice = Console.ReadKey().Key;

        switch (choice)
        {
            case ConsoleKey.D1: 
            Console.Clear();
            AddEmployee();
            break;
            
            case ConsoleKey.D2:
            Console.Clear();
            Console.WriteLine("----Lista av personal----");
            ListEmployees();
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
class Employee
{
    public string firstName { get; set; }
    public string lastName { get; set; }
    public int employeeNumber { get; set; }

    public Employee (string firstName, string lastName, int employeeNumber)
    {
        this.firstName = firstName;
        this.lastName = lastName;
        this.employeeNumber = employeeNumber;
    }
}