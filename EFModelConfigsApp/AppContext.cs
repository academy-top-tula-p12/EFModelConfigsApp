using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFModelConfigsApp
{
    public class EmployeeAppContext : DbContext
    {
        public DbSet<Employee> Employees { set; get; } = null!;
        //public DbSet<Position> Positions { set; get; } = null!;
        //public DbSet<Country> Countries { set; get; } = null!;
        //public DbSet<Company> Companies { set; get; } = null!;

        public EmployeeAppContext()
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=DESKTOP-ISC66B9\\MSSQLSERVER2022;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False; Database=hr_db");

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //modelBuilder.Entity<Employee>().Property(e => e.Id).ValueGeneratedNever();
            //modelBuilder.Entity<Employee>()
            //            .Property(e => e.Activity)
            //            .HasDefaultValue(true);
            //
            //modelBuilder.Entity<Employee>()
            //            .Property(e => e.HolidaysDate)
            //            .HasDefaultValueSql("GETDATE()");
            //
            //modelBuilder.Entity<Employee>()
            //            .Property(e => e.Name)
            //            .HasComputedColumnSql("FirstName + ' ' + LastName");
            //
            //modelBuilder.Entity<Employee>()
            //            .ToTable(t => t.HasCheckConstraint("CK_Employee_Age", "Age > 0 AND Age < 100"));
            //
            //
            //modelBuilder.Entity<Employee>()
            //            .Property(e => e.LastName)
            //            .HasMaxLength(70);


            modelBuilder.ApplyConfiguration(new EmployeeModelConfigure());
            modelBuilder.ApplyConfiguration(new CompanyModelConfigure());

            modelBuilder.Entity<Position>(PositionModelConfigure);
        }

        public void PositionModelConfigure(EntityTypeBuilder<Position> builder)
        {
            builder.Property(p => p.Title)
                   .HasColumnName("PositionName");
        }
    }
}
