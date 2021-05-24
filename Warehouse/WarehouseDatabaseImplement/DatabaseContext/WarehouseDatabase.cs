using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using WarehouseDatabaseImplement.Models;

namespace WarehouseDatabaseImplement.DatabaseContext
{
    public partial class WarehouseDatabase : DbContext
    {
        public WarehouseDatabase()
        {
        }

        public WarehouseDatabase(DbContextOptions<WarehouseDatabase> options)
            : base(options)
        {
        }

        public virtual DbSet<Expensestatement> Expensestatement { get; set; }
        public virtual DbSet<Expensestatementproduct> Expensestatementproduct { get; set; }
        public virtual DbSet<Groupp> Groupp { get; set; }
        public virtual DbSet<Product> Product { get; set; }
        public virtual DbSet<Receiptstatement> Receiptstatement { get; set; }
        public virtual DbSet<Receiptstatementproduct> Receiptstatementproduct { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                #warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseNpgsql("Host=192.168.0.104;Port=5433;Database=warehouse;Username=rafael;Password=1234");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Expensestatement>(entity =>
            {
                entity.ToTable("expensestatement");

                entity.HasComment("Запись о покупке");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasComment("Идентификатор записи");

                entity.Property(e => e.Customer)
                    .IsRequired()
                    .HasColumnName("customer")
                    .HasMaxLength(255)
                    .HasDefaultValueSql("'Покупатель'::character varying")
                    .HasComment("Покупатель");

                entity.Property(e => e.Datedeparture)
                    .HasColumnName("datedeparture")
                    .HasColumnType("date")
                    .HasDefaultValueSql("now()")
                    .HasComment("Дата отгрузки со склада");
            });

            modelBuilder.Entity<Expensestatementproduct>(entity =>
            {
                entity.HasKey(e => new { e.ExpensestatementId, e.ProductId })
                    .HasName("expensestatementproduct_pkey");

                entity.ToTable("expensestatementproduct");

                entity.HasComment("Связь записей о покупках с продукцией");

                entity.Property(e => e.ExpensestatementId)
                    .HasColumnName("expensestatement_id")
                    .HasComment("Внешний идентификатор связи из записей");

                entity.Property(e => e.ProductId)
                    .HasColumnName("product_id")
                    .HasComment("Внешний идентификатор связи из продукции");

                entity.Property(e => e.Count)
                    .HasColumnName("count")
                    .HasDefaultValueSql("1")
                    .HasComment("Количество купленной продукции");

                entity.Property(e => e.Price)
                    .HasColumnName("price")
                    .HasDefaultValueSql("1")
                    .HasComment("Цена продукции при покупке");

                entity.HasOne(d => d.Expensestatement)
                    .WithMany(p => p.Expensestatementproduct)
                    .HasForeignKey(d => d.ExpensestatementId)
                    .HasConstraintName("expensestatementproduct_expensestatement_id_fkey");

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.Expensestatementproduct)
                    .HasForeignKey(d => d.ProductId)
                    .HasConstraintName("expensestatementproduct_product_id_fkey");
            });

            modelBuilder.Entity<Groupp>(entity =>
            {
                entity.ToTable("groupp");

                entity.HasComment("Группа продукции на складе");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasComment("Идентификатор группы");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasMaxLength(255)
                    .HasDefaultValueSql("'Название'::character varying")
                    .HasComment("Название группы");
            });

            modelBuilder.Entity<Product>(entity =>
            {
                entity.ToTable("product");

                entity.HasComment("Продукция на складе");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasComment("Идентификатор продукции");

                entity.Property(e => e.Count).HasComment("Количество продукции на данный момент");

                entity.Property(e => e.GrouppId)
                    .HasColumnName("groupp_id")
                    .HasComment("Внешний ключ от группы");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasMaxLength(255)
                    .HasDefaultValueSql("'Название'::character varying")
                    .HasComment("Название продукции");

                entity.Property(e => e.Price)
                    .HasColumnName("price")
                    .HasComment("Цена");

                entity.HasOne(d => d.Groupp)
                    .WithMany(p => p.Product)
                    .HasForeignKey(d => d.GrouppId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("product_groupp_id_fkey");
            });

            modelBuilder.Entity<Receiptstatement>(entity =>
            {
                entity.ToTable("receiptstatement");

                entity.HasComment("Запись о поставке");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasComment("Идентификатор поставки");

                entity.Property(e => e.Datearrival)
                    .HasColumnName("datearrival")
                    .HasColumnType("date")
                    .HasDefaultValueSql("now()")
                    .HasComment("Дата поставки");

                entity.Property(e => e.Provider)
                    .IsRequired()
                    .HasColumnName("provider")
                    .HasMaxLength(255)
                    .HasDefaultValueSql("'Поставщик'::character varying")
                    .HasComment("Поставщик");
            });

            modelBuilder.Entity<Receiptstatementproduct>(entity =>
            {
                entity.HasKey(e => new { e.ReceiptstatementId, e.ProductId })
                    .HasName("receiptstatementproduct_pkey");

                entity.ToTable("receiptstatementproduct");

                entity.HasComment("Связь записей о поставке с продукцией");

                entity.Property(e => e.ReceiptstatementId)
                    .HasColumnName("receiptstatement_id")
                    .HasComment("Внешний идентификатор записи из поставки");

                entity.Property(e => e.ProductId)
                    .HasColumnName("product_id")
                    .HasComment("Внешний идентификатор записи из продукции");

                entity.Property(e => e.Count)
                    .HasColumnName("count")
                    .HasDefaultValueSql("1")
                    .HasComment("Количество продукции при поставке");

                entity.Property(e => e.Price)
                    .HasColumnName("price")
                    .HasDefaultValueSql("1")
                    .HasComment("Цена придукции на момент поставки");

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.Receiptstatementproduct)
                    .HasForeignKey(d => d.ProductId)
                    .HasConstraintName("receiptstatementproduct_product_id_fkey");

                entity.HasOne(d => d.Receiptstatement)
                    .WithMany(p => p.Receiptstatementproduct)
                    .HasForeignKey(d => d.ReceiptstatementId)
                    .HasConstraintName("receiptstatementproduct_receiptstatement_id_fkey");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
