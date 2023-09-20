using Contract_Manager.Entities.Enums;
namespace Contract_Manager.Entities;

public class Worker
{
    public string? Name { get; set; }
    public WorkerLevel Level { get; set; }
    public double BaseSalary { get; set; }
    public Departament Departament { get; set; }
    public List<HourContract> Contracts { get; set; } = new List<HourContract>();

    public Worker()
    {
    }

    public Worker(string? name, WorkerLevel level, double baseSalary, Departament departament)
    {
        Name = name;
        Level = level;
        BaseSalary = baseSalary;
        Departament = departament;
    }

    public void AddContract(HourContract contract)
    {
        Contracts.Add(contract);
    }

    public void RemoveContract(HourContract contract)
    {
        Contracts.Remove(contract);
    }

    public double Income( int year, int month)
    {
        double sum = BaseSalary;

        foreach (HourContract contract in Contracts)
        {
            if(contract.Date.Month == month && contract.Date.Year == year)
            {
                sum += contract.TotalValue();
            }
        }
        return sum;
    }
}
