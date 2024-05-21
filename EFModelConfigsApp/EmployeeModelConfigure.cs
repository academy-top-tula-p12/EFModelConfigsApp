using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace EFModelConfigsApp
{
    public class EmployeeModelConfigure : IEntityTypeConfiguration<Employee>
    {
        public void Configure(EntityTypeBuilder<Employee> builder)
        {
            builder.Property(e => e.Activity)
                   .HasDefaultValue(true);

            builder.Property(e => e.HolidaysDate)
                   .HasDefaultValueSql("GETDATE()");

            builder.Property(e => e.Name)
                   .HasComputedColumnSql("FirstName + ' ' + LastName");

            builder.ToTable(t => t.HasCheckConstraint("CK_Employee_Age", "Age > 0 AND Age < 100"));


            builder.Property(e => e.LastName)
                   .HasMaxLength(70);
        }
    }

    public class CompanyModelConfigure : IEntityTypeConfiguration<Company>
    {
        public void Configure(EntityTypeBuilder<Company> builder)
        {
            builder.ToTable("CompanyTable");
        }
    }

    public class CountryModelConfigure : IEntityTypeConfiguration<Country>
    {
        public void Configure(EntityTypeBuilder<Country> builder)
        {
            builder.Property(c => c.Title).IsRequired();
        }
    }
}
