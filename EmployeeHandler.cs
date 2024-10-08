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

        while (!validInput)
        {
            Console.Write("Förnamn: ");
            firstName = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(firstName))
            {
                Console.WriteLine("Förnamn kan ej vara tom");
            }
            else
            {
                validInput = true;
            }
        }
        while (!validInput)
        {
            Console.Write("Efternamn: ");
            lastName = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(lastName))
            {
                Console.WriteLine("Efternamn kan ej vara tom");
            }
            else
            {
                validInput = true;
            }
        }
        int employeeNumber = rnd.Next(1000,10000);
        employees.Add(new Employee(firstName, lastName, employeeNumber));
    }
    public static void ListEmployees()
    {
        for (int i = 0; i < employees.Count; i++)
        {
            Console.WriteLine($"{employees[i].firstName} {employees[i].lastName} Tjänstnummer: {employees[i].employeeNumber}");
        }
    }
    public static string ChooseEmployee()
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
                ChooseEmployee();
            }
        }
        else
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Fel inamtning! Ange ett heltal");
            Console.ForegroundColor = ConsoleColor.White;
            ChooseEmployee();
        }
        
        return "";
    }
    public static void Menu()
    {
        Console.WriteLine("1. Lägg till en ny anställd");
        Console.WriteLine("2. Visa alla anställda");
        string choice = Console.ReadLine();

        switch (choice)
        {
            case "1": 
            AddEmployee();
            break;
            
            case "2":
            Console.WriteLine("----Lista av personal----");
            ListEmployees();
            break;

            default:
            Console.Clear();
            Console.WriteLine("Fel val");
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