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
    internal class TransactionLineConfiguration : IEntityTypeConfiguration<TransactionLine>
    {
        public void Configure(EntityTypeBuilder<TransactionLine> builder)
        {
            builder.HasKey(transactionLine => transactionLine.ID);

            builder.Property(transLine => transLine.Quantity).HasColumnType("decimal(10,2)");
            builder.Property(transLine => transLine.ItemPrice).HasColumnType("decimal(10,2)");
            builder.Property(transLine => transLine.NetValue).HasColumnType("decimal(10,2)");
            builder.Property(transLine => transLine.DiscountPercentage).HasColumnType("decimal(10,2)");
            builder.Property(transLine => transLine.DiscountValue).HasColumnType("decimal(10,2)");
            builder.Property(transLine => transLine.TotalValueOfLine).HasColumnType("decimal(10,2)");

            //TODO:ondelete cascade ?!??
            builder.HasOne(transLine => transLine.Transaction).WithMany(transaction => transaction.TransactionLinesList).HasForeignKey(transline => transline.TransactionID);
            //!?
            builder.HasOne(transline => transline.Item).WithMany(Item => Item.TransactionLineList).HasForeignKey(transline => transline.ItemID).OnDelete(DeleteBehavior.Restrict);
            
        }
    }

}
