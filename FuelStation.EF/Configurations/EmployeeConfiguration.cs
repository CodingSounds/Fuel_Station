using FuelStation.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FuelStation.EF.Configurations
{
    internal class EmployeeConfiguration: IEntityTypeConfiguration<Employee>
    {
        public void Configure(EntityTypeBuilder<Employee> builder)
        {

            builder.HasKey(Employee => Employee.ID);
            builder.Property(Employee => Employee.Name).HasMaxLength(50);
            builder.Property(Employee => Employee.Surname).HasMaxLength(50);
            builder.Property(Employee => Employee.EmployeeType).HasMaxLength(50);

            builder.Property(Employee => Employee.Password).HasMaxLength(25);
            builder.Property(Employee => Employee.UserName).HasMaxLength(25);


        }
    }
}
