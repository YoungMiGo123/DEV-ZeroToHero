

namespace ZeroToHero.BestPractices.Console.SOLID.SingleResponsibility.Before;

using System.Collections.Generic;
using System;

public class StaticData
{
    public static List<EmployeeService> Employees { get; set; } = new List<EmployeeService>();
}

public class EmployeeService
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }   
    public decimal Salary { get; set; } 

    public void EmployeeRegistration(EmployeeService employee)
    {
        StaticData.Employees.Add(employee);
        SendEmail(employee.Email, "Employee Registration", "You have been registered as an employee");
    }
    private void SendEmail(string email, string subject, string message)
    {
        Console.WriteLine($"Email sent to {email} with subject {subject} and message {message}");
    }

}

public class SingleResponsibilityVolationExample
{
    public static void Build()
    {
        Console.WriteLine("SingleResponsibilityVolationExample\n");

        var employee = new EmployeeService
        {
            FirstName = "John",
            LastName = "Doe",
            Email = "JohnDoe@gmail.com",
            Salary = 25000
        };

        employee.EmployeeRegistration(employee);
    }
}
