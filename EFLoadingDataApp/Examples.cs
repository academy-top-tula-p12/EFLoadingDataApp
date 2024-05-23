using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFLoadingDataApp
{
    public class Examples
    {
        public static void CreateDatabase()
        {
            using (EmployeeAppContext context = new())
            {
                context.Database.EnsureDeleted();
                context.Database.EnsureCreated();

                List<Company> companies = null!;
                List<Employee> employees = null!;
                List<Country> countries = null!;
                List<Position> positions = null!;

                positions = new()
                {
                    new(){ Title = "Manager" },
                    new(){ Title = "Developer" },
                    new(){ Title = "Designer" }
                };

                countries = new()
                {
                    new(){ Title = "Russia" },
                    new(){ Title = "China" },
                    new(){ Title = "Usa" },
                };

                companies = new()
                {
                    new() { Title = "Yandex", Country = countries[0] },
                    new() { Title = "Ozon", Country = countries[0] },
                    new() { Title = "Avito", Country = countries[0] },

                    new() { Title = "Huawai", Country = countries[1] },
                    new() { Title = "Xiaomi", Country = countries[1] },

                    new() { Title = "Microsoft", Country = countries[2] },
                    new() { Title = "Google", Country = countries[2] },

                };
                employees = new()
                {
                    new(){ Name = "Bobby", Age = 35, Company = companies[0], Position = positions[0] },
                    new(){ Name = "Sammy", Age = 22, Company = companies[1], Position = positions[1] },
                    new(){ Name = "Jommy", Age = 41, Company = companies[2], Position = positions[1] },
                    new(){ Name = "Tommt", Age = 26, Company = companies[0], Position = positions[0] },
                    new(){ Name = "Billy", Age = 48, Company = companies[1], Position = positions[2] },
                    new(){ Name = "Kenny", Age = 31, Company = companies[0], Position = positions[2] },

                    new(){ Name = "Chi Li", Age = 27, Company = companies[3], Position = positions[1] },
                    new(){ Name = "Dao Sin", Age = 33, Company = companies[4], Position = positions[0] },
                    new(){ Name = "Kio San", Age = 21, Company = companies[3], Position = positions[2] },

                    new(){ Name = "Mikle", Age = 38, Company = companies[5], Position = positions[2] },
                    new(){ Name = "Anna", Age = 23, Company = companies[6], Position = positions[1] },
                    new(){ Name = "Susan", Age = 20, Company = companies[6], Position = positions[0] },
                };
                context.Companies.AddRange(companies);
                context.Employees.AddRange(employees);
                context.Countries.AddRange(countries);
                context.Positions.AddRange(positions);
                context.SaveChanges();
            }
        }

        public static void EagerLoadingExample()
        {
            using (EmployeeAppContext context = new())
            {
                //var employees = context.Employees;

                //var employees = context.Employees
                //                       .Include(e => e.Company)
                //                       .ToList();

                //foreach (var e in employees)
                //    Console.WriteLine($"{e.Name} {e.Age} {e.Company?.Title}");

                //Console.WriteLine();

                //var companies = context.Companies;
                //var companies = context.Companies
                //                       .Include(c => c.Employees)
                //                       .ToList();

                //foreach (var c in companies)
                //{
                //    Console.WriteLine($"{c.Title}");
                //    foreach(var e in c.Employees)
                //        Console.WriteLine($"\t{e.Name}");
                //}

                //var employees = context.Employees
                //                       .Include(e => e.Company)
                //                            .ThenInclude(c => c.Country)
                //                       .ToList();

                //foreach(var e in employees)
                //    Console.WriteLine($"Name: {e.Name} Age: {e.Age} Company: {e.Company?.Title} Country: {e.Company?.Country?.Title}");

                //var countries = context.Countries
                //                     .Include(c => c.Companies)
                //                        .ThenInclude(cmp => cmp.Employees)
                //                     .ToList();

                //foreach(var c in countries)
                //{
                //    Console.WriteLine($"Country: {c.Title}");
                //    foreach(var cmp in c.Companies)
                //    {
                //        Console.WriteLine($"\t{cmp.Title}");
                //        foreach(var e in cmp.Employees)
                //            Console.WriteLine($"\t\tName: {e.Name}, Age: {e.Age}");
                //    }
                //}


                //var employees = context.Employees
                //                       .Include(e => e.Company)
                //                            .ThenInclude(c => c!.Country)
                //                       .Include(e => e.Position)
                //                       .ToList();

                //foreach (var e in employees)
                //    Console.WriteLine($"Name: {e.Name} Age: {e.Age} Position: {e.Position?.Title} Company: {e.Company?.Title} Country: {e.Company?.Country?.Title}");


                //var positions = context.Positions
                //                       .Include(p => p.Employees)
                //                            .ThenInclude(e => e.Company)
                //                                .ThenInclude(c => c!.Country)
                //                       .ToList();

                //foreach(var p in positions)
                //{
                //    Console.WriteLine($"Position: {p.Title}");
                //    foreach(var e in p.Employees)
                //    {
                //        Console.WriteLine($"\tEmployee: Name: {e.Name} Age {e.Age} Company: {e.Company!.Title} Country: {e.Company!.Country!.Title}");
                //    }
                //}

                //var companies = context.Companies
                //                       .Include(c => c.Country)
                //                       .Include(c => c.Employees)
                //                            .ThenInclude(e => e.Position)
                //                       .ToList();

                //foreach (var c in companies)
                //{
                //    Console.WriteLine($"Company: {c.Title}, Country: {c.Country!.Title}");
                //    foreach(var e in c.Employees)
                //        Console.WriteLine($"\tName: {e.Name}, Age: {e.Age}, Position: {e.Position!.Title}");
                //}
            }
        }
    }
}
