using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFLoadingDataApp
{
    public class Employee
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public int Age { get; set; }

        public int CompanyId { get; set; }
        public virtual Company? Company { get; set; }

        public int PositionId { get; set; }
        public virtual Position? Position { get; set; }
    }

    public class Company
    {
        public int Id { get; set; }
        public string Title { get; set; } = null!;

        public virtual List<Employee> Employees { get; set; } = new();

        public int CountryId { get; set; }
        public virtual Country? Country { get; set; }
    }

    public class Country
    {
        public int Id { get; set; }
        public string Title { get; set; } = null!;

        public virtual List<Company> Companies { get; set; } = new();
    }

    public class Position
    {
        public int Id { get; set; }
        public string Title { get; set; } = null!;

        public virtual List<Employee> Employees { get; set; } = new();
    }
}
