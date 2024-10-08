using System.ComponentModel.Design;
using System.Xml.Serialization;
using Microsoft.VisualBasic;

static class EmployeeHandler
{
    public static List<Employee> employees = new List<Employee>();
    static Random rnd = new Random();
    public static void AddEmployee()
    {
        Console.Write("Förnamn: ");
        string firstName = Console.ReadLine();
        Console.Write("Efternamn: ");
        string lastName = Console.ReadLine();
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
        int choice = int.Parse(Console.ReadLine());
        string officer; 
        var employee = employees.FirstOrDefault(e => e.employeeNumber == choice);
        if (employee != null)
        {
            officer = $"{employee.firstName} {employee.lastName}";
            return officer;
        }
        
        return "-";
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
public class MainEmployeehandler 
{
    public static void MenuEmployee()
    {
            Console.WriteLine("1. Lägg till en ny anställd");
            Console.WriteLine("2. Visa alla anställda");
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1": 
                EmployeeHandler.AddEmployee();
                break;
                
                case "2":
                Console.WriteLine("----Lista av personal----");
                EmployeeHandler.ListEmployees();
                break;

                default:
                Console.Clear();
                Console.WriteLine("Fel val");
                MenuEmployee();
                break;
            }
    }
}