using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace ComputerASP.Models
{
    public partial class CompContext : DbContext
    {
        public CompContext()
            : base("name=CompContext")
        {
        }

        public virtual DbSet<AssemblyPc> AssemblyPcs { get; set; }
        public virtual DbSet<Component> Components { get; set; }
        public virtual DbSet<Employee> Employees { get; set; }
        public virtual DbSet<Model> Models { get; set; }
        public virtual DbSet<PCSale> PCSales { get; set; }
        public virtual DbSet<ProfitBill> ProfitBills { get; set; }
        public virtual DbSet<PurchasePCComponent> PurchasePCComponents { get; set; }
        public virtual DbSet<ReadyPC> ReadyPCs { get; set; }
        public virtual DbSet<RetailInvoice> RetailInvoices { get; set; }
        public virtual DbSet<Supplier> Suppliers { get; set; }
        public virtual DbSet<WarehouseComponent> WarehouseComponents { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AssemblyPc>()
                .Property(e => e.AssemblyPrice)
                .HasPrecision(10, 4);

            modelBuilder.Entity<PCSale>()
                .Property(e => e.PricePC)
                .HasPrecision(10, 4);

            modelBuilder.Entity<PCSale>()
                .Property(e => e.PCStatus)
                .IsFixedLength();

            modelBuilder.Entity<ProfitBill>()
                .Property(e => e.UnitPrice)
                .HasPrecision(10, 4);

            modelBuilder.Entity<ProfitBill>()
                .Property(e => e.SumPrice)
                .HasPrecision(10, 4);

            modelBuilder.Entity<PurchasePCComponent>()
                .Property(e => e.Price)
                .HasPrecision(10, 4);

            modelBuilder.Entity<ReadyPC>()
                .Property(e => e.PurchasePrice)
                .HasPrecision(10, 4);

            modelBuilder.Entity<RetailInvoice>()
                .Property(e => e.UnitPrice)
                .HasPrecision(10, 4);

            modelBuilder.Entity<RetailInvoice>()
                .Property(e => e.SumPrice)
                .HasPrecision(10, 4);
        }
    }
}
