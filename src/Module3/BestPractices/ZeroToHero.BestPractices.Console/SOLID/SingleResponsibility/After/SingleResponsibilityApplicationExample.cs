
namespace ZeroToHero.BestPractices.Console.SOLID.SingleResponsibility.After;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class EmployeeRepository
{
    private List<Employee> _employees = [];   
    public void Save(Employee employee)
    {
        _employees.Add(employee);    
    }
}
public class EmployeeService
{
    private EmployeeRepository _employeeRepository;
    private EmailService _emailService;

    public EmployeeService()
    {
        _employeeRepository = new EmployeeRepository();
        _emailService = new EmailService();
    }
    public void RegisterEmployee(Employee employee)
    {
        _employeeRepository.Save(employee);
        _emailService.SendEmail(employee.Email, "Employee Registration", "You have been registered as an employee");
    }
}
public class EmailService
{
    public void SendEmail(string email, string subject, string message)
    {
        Console.WriteLine($"Email sent to {email} with subject {subject} and message {message}");
    }
}

public class  Employee
{
    public Guid Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public decimal Salary { get; set; }
}


public class SingleResponsibilityApplicationExample
{
    public static void Build()
    {
        Console.WriteLine("SingleResponsibilityApplicationExample\n");

        var employee = new Employee
        {
            Id = Guid.NewGuid(),
            FirstName = "John",
            LastName = "Doe",
            Email = "JohnDoe@gmail.com",
            Salary = 25000
        };

        var employeeService = new EmployeeService();

        employeeService.RegisterEmployee(employee);
    }
}
