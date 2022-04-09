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
    internal class TransactionConfiguration : IEntityTypeConfiguration<Transaction>
    {
        public void Configure(EntityTypeBuilder<Transaction> builder)
        {
            builder.HasKey(transaction => transaction.ID);

            builder.Property(transaction => transaction.TotalValue).HasColumnType("decimal(10,2)");
            builder.HasOne(transaction => transaction.Customer).WithMany(Customer => Customer.TransactionList).HasForeignKey(transaction => transaction.CustomerID).OnDelete(DeleteBehavior.Restrict);
            builder.HasOne(transaction => transaction.Employee).WithMany(Employee => Employee.TransactionList).HasForeignKey(transaction => transaction.EmployeeID).OnDelete(DeleteBehavior.Restrict);
            //builder.HasOne(transaction => transaction.TransactionLinesList).WithMany(car => car.Transcations).HasForeignKey(transaction => transaction.CarID).OnDelete(DeleteBehavior.Restrict);
        }
    }
}
