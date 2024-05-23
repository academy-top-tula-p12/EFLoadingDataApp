using EFLoadingDataApp;
using Microsoft.EntityFrameworkCore;

//Examples.CreateDatabase();

using(EmployeeAppContext context = new())
{
    string companyName = "Yandex";

    Company company = context.Companies.First(c => c.Title == companyName);

    if(company is not null)
    {
        context.Employees
               .Where(e => e.CompanyId == company.Id)
               .Load();

        foreach(Employee emp in company.Employees)
        {
            Console.WriteLine($"{emp.Name}");
        }
    }
}


