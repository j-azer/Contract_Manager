// See https://aka.ms/new-console-template for more information
using Contract_Manager.Entities;
using Contract_Manager.Entities.Enums;
using System.Globalization;

Console.Write("Enter departament's name: ");
string nameDepartament = Console.ReadLine();

Console.WriteLine("Enter worker data:");
Console.Write("Name: ");
string name = Console.ReadLine();

Console.Write("Level (Junior/MidLevel/Senior): ");
WorkerLevel level = Enum.Parse<WorkerLevel>(Console.ReadLine());

Console.Write("Base Salary: ");
double baseSalary = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);

Departament dept = new Departament(nameDepartament);
Worker worker = new Worker(name, level, baseSalary, dept);

Console.Write("How many contracts to this worker? ");
int n = int.Parse(Console.ReadLine());

for (int i = 1; i <= n; i++)
{
    Console.WriteLine($"Enter #{i} contract data:");
    Console.Write("Date (YYYY/MM/DD): ");
    DateTime date = DateTime.Parse(Console.ReadLine());

    Console.Write("Value per hour: ");
    double valuePerHour = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);

    Console.Write("Duration (hours): ");
    int hours = int.Parse(Console.ReadLine());

    HourContract contract = new HourContract(date, valuePerHour, hours);
    worker.AddContract(contract); Console.WriteLine();
}
Console.WriteLine();
Console.Write("Enter month and year to calculate income (MM/YYYY): ");
string monthAndYear = Console.ReadLine();

int month = int.Parse(monthAndYear.Substring(0, 2));
int year = int.Parse(monthAndYear.Substring(3));

Console.WriteLine($"Name: {worker.Name}");
Console.WriteLine($"Departament: {worker.Departament.Name}");
Console.WriteLine($"Income for {monthAndYear}: {worker.Income(year, month).ToString("F2", CultureInfo.InvariantCulture)}");
