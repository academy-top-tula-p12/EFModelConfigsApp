using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFModelConfigsApp
{
    public class Employee
    {
        //[DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }

        [MaxLength(50)]
        public string? FirstName { get; set; }
        public string? LastName { get; set; }

        public string? Name { get; set; }

        public int Age { get; set; }
        public bool Activity { get; set; } = true;
        public DateTime HolidaysDate { get; set; }

        public Company? Company { get; set; }
        public Position? Position { get; set; }
    }

    public class Company
    {
        public int Id { get; set; }
        public string? Title { get; set; }
        public Country? Country { get; set; }
    }

    public class Position
    {
        public int Id { get; set; }
        public string? Title { get; set; }
    }

    [EntityTypeConfiguration(typeof(CountryModelConfigure))]
    public class Country
    {
        public int Id { get; set; }
        public string? Title { get; set; }
    }
}
