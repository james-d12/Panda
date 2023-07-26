﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Panda.Persistence;

#nullable disable

namespace Panda.Persistence.Migrations
{
    [DbContext(typeof(ApplicationDBContext))]
    partial class ApplicationDBContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "7.0.5");

            modelBuilder.Entity("Panda.Core.Domain.Entities.BudgetEmployees.BudgetEmployee", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT")
                        .HasColumnOrder(0);

                    b.Property<Guid>("BudgetId")
                        .HasColumnType("TEXT")
                        .HasColumnOrder(2);

                    b.Property<int>("BudgetRole")
                        .HasColumnType("INTEGER")
                        .HasColumnOrder(1);

                    b.Property<Guid>("EmployeeId")
                        .HasColumnType("TEXT")
                        .HasColumnOrder(3);

                    b.HasKey("Id");

                    b.HasIndex("BudgetId", "EmployeeId")
                        .IsUnique();

                    b.ToTable("BudgetEmployee");
                });

            modelBuilder.Entity("Panda.Core.Domain.Entities.Budgets.Budget", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT")
                        .HasColumnOrder(0);

                    b.Property<int>("BudgetType")
                        .HasColumnType("INTEGER")
                        .HasColumnOrder(4);

                    b.Property<Guid>("CompanyId")
                        .HasColumnType("TEXT")
                        .HasColumnOrder(2);

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("TEXT")
                        .HasColumnOrder(6);

                    b.Property<bool>("IsStandalone")
                        .HasColumnType("INTEGER")
                        .HasColumnOrder(7);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(64)
                        .HasColumnType("TEXT")
                        .HasColumnOrder(5);

                    b.Property<int>("Status")
                        .HasColumnType("INTEGER")
                        .HasColumnOrder(3);

                    b.Property<Guid>("YearId")
                        .HasColumnType("TEXT")
                        .HasColumnOrder(1);

                    b.HasKey("Id");

                    b.HasIndex("CompanyId");

                    b.HasIndex("Name")
                        .IsUnique();

                    b.HasIndex("YearId", "CompanyId")
                        .IsUnique();

                    b.ToTable("Budget");
                });

            modelBuilder.Entity("Panda.Core.Domain.Entities.Categories.Category", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT")
                        .HasColumnOrder(0);

                    b.Property<Guid>("BudgetId")
                        .HasColumnType("TEXT")
                        .HasColumnOrder(5);

                    b.Property<int>("CategoryField")
                        .HasColumnType("INTEGER")
                        .HasColumnOrder(3);

                    b.Property<int>("CategoryType")
                        .HasColumnType("INTEGER")
                        .HasColumnOrder(4);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(64)
                        .HasColumnType("TEXT")
                        .HasColumnOrder(1);

                    b.Property<int>("Status")
                        .HasColumnType("INTEGER")
                        .HasColumnOrder(2);

                    b.HasKey("Id");

                    b.HasIndex("BudgetId", "Name")
                        .IsUnique();

                    b.ToTable("Category");
                });

            modelBuilder.Entity("Panda.Core.Domain.Entities.Companies.Company", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT")
                        .HasColumnOrder(0);

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(256)
                        .HasColumnType("TEXT")
                        .HasColumnOrder(2);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(64)
                        .HasColumnType("TEXT")
                        .HasColumnOrder(1);

                    b.HasKey("Id");

                    b.HasIndex("Name")
                        .IsUnique();

                    b.ToTable("Company");
                });

            modelBuilder.Entity("Panda.Core.Domain.Entities.Employees.Employee", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT")
                        .HasColumnOrder(0);

                    b.Property<string>("EmailAddress")
                        .IsRequired()
                        .HasMaxLength(128)
                        .HasColumnType("TEXT")
                        .HasColumnOrder(3);

                    b.Property<int>("Role")
                        .HasColumnType("INTEGER")
                        .HasColumnOrder(1);

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasMaxLength(64)
                        .HasColumnType("TEXT")
                        .HasColumnOrder(2);

                    b.HasKey("Id");

                    b.HasIndex("EmailAddress")
                        .IsUnique();

                    b.HasIndex("Username")
                        .IsUnique();

                    b.ToTable("Employees");
                });

            modelBuilder.Entity("Panda.Core.Domain.Entities.Reviews.Review", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT")
                        .HasColumnOrder(0);

                    b.Property<int>("Status")
                        .HasColumnType("INTEGER")
                        .HasColumnOrder(2);

                    b.Property<Guid>("YearId")
                        .HasColumnType("TEXT")
                        .HasColumnOrder(1);

                    b.HasKey("Id");

                    b.HasIndex("YearId")
                        .IsUnique();

                    b.ToTable("Review");
                });

            modelBuilder.Entity("Panda.Core.Domain.Entities.Sages.Sage", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<string>("AccountCostCentre")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("AccountName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("AccountNumber")
                        .HasColumnType("INTEGER");

                    b.Property<Guid>("CategoryId")
                        .HasColumnType("TEXT");

                    b.Property<string>("CostCentreName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Department")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("DepartmentName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.ToTable("Sage");
                });

            modelBuilder.Entity("Panda.Core.Domain.Entities.Sandboxes.Sandbox", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT")
                        .HasColumnOrder(0);

                    b.Property<Guid>("BudgetId")
                        .HasColumnType("TEXT")
                        .HasColumnOrder(1);

                    b.HasKey("Id");

                    b.HasIndex("BudgetId")
                        .IsUnique();

                    b.ToTable("Sandbox");
                });

            modelBuilder.Entity("Panda.Core.Domain.Entities.Summaries.Summary", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT")
                        .HasColumnOrder(0);

                    b.Property<Guid>("BudgetId")
                        .HasColumnType("TEXT")
                        .HasColumnOrder(1);

                    b.HasKey("Id");

                    b.HasIndex("BudgetId")
                        .IsUnique();

                    b.ToTable("Summary");
                });

            modelBuilder.Entity("Panda.Core.Domain.Entities.Tables.Cells.Cell", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("TEXT")
                        .HasColumnOrder(0);

                    b.Property<Guid>("ColumnId")
                        .HasColumnType("TEXT")
                        .HasColumnOrder(3);

                    b.Property<DateTime?>("DateTime")
                        .HasColumnType("TEXT")
                        .HasColumnOrder(7);

                    b.Property<string>("Name")
                        .HasColumnType("TEXT")
                        .HasColumnOrder(4);

                    b.Property<double?>("Price")
                        .HasColumnType("REAL")
                        .HasColumnOrder(5);

                    b.Property<ulong?>("Quantity")
                        .HasColumnType("INTEGER")
                        .HasColumnOrder(6);

                    b.Property<Guid>("RowId")
                        .HasColumnType("TEXT")
                        .HasColumnOrder(2);

                    b.Property<Guid>("TableId")
                        .HasColumnType("TEXT")
                        .HasColumnOrder(1);

                    b.HasKey("Id");

                    b.HasIndex("ColumnId");

                    b.HasIndex("TableId");

                    b.HasIndex("RowId", "ColumnId", "TableId")
                        .IsUnique();

                    b.ToTable("Cell");
                });

            modelBuilder.Entity("Panda.Core.Domain.Entities.Tables.Columns.Column", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("TEXT")
                        .HasColumnOrder(0);

                    b.Property<string>("Field")
                        .IsRequired()
                        .HasMaxLength(64)
                        .HasColumnType("TEXT")
                        .HasColumnOrder(3);

                    b.Property<Guid>("TableId")
                        .HasColumnType("TEXT")
                        .HasColumnOrder(1);

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(64)
                        .HasColumnType("TEXT")
                        .HasColumnOrder(2);

                    b.HasKey("Id");

                    b.HasIndex("TableId")
                        .IsUnique();

                    b.ToTable("Column");
                });

            modelBuilder.Entity("Panda.Core.Domain.Entities.Tables.Rows.Row", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("TEXT")
                        .HasColumnOrder(0);

                    b.Property<string>("Notes")
                        .IsRequired()
                        .HasMaxLength(256)
                        .HasColumnType("TEXT")
                        .HasColumnOrder(2);

                    b.Property<Guid>("TableId")
                        .HasColumnType("TEXT")
                        .HasColumnOrder(1);

                    b.HasKey("Id");

                    b.HasIndex("TableId")
                        .IsUnique();

                    b.ToTable("Row");
                });

            modelBuilder.Entity("Panda.Core.Domain.Entities.Tables.Table", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("TEXT")
                        .HasColumnOrder(0);

                    b.Property<Guid?>("ReviewId")
                        .IsRequired()
                        .HasColumnType("TEXT")
                        .HasColumnOrder(3);

                    b.Property<Guid?>("SandboxId")
                        .IsRequired()
                        .HasColumnType("TEXT")
                        .HasColumnOrder(1);

                    b.Property<Guid?>("SummaryId")
                        .IsRequired()
                        .HasColumnType("TEXT")
                        .HasColumnOrder(2);

                    b.HasKey("Id");

                    b.HasIndex("ReviewId")
                        .IsUnique();

                    b.HasIndex("SandboxId")
                        .IsUnique();

                    b.HasIndex("SummaryId")
                        .IsUnique();

                    b.ToTable("Table");
                });

            modelBuilder.Entity("Panda.Core.Domain.Entities.Years.Year", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT")
                        .HasColumnOrder(0);

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(256)
                        .HasColumnType("TEXT")
                        .HasColumnOrder(2);

                    b.Property<DateOnly>("EndDate")
                        .HasColumnType("TEXT")
                        .HasColumnOrder(5);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(64)
                        .HasColumnType("TEXT")
                        .HasColumnOrder(1);

                    b.Property<DateOnly>("StartDate")
                        .HasColumnType("TEXT")
                        .HasColumnOrder(4);

                    b.Property<int>("Status")
                        .HasColumnType("INTEGER")
                        .HasColumnOrder(3);

                    b.HasKey("Id");

                    b.HasIndex("EndDate")
                        .IsUnique();

                    b.HasIndex("Name")
                        .IsUnique();

                    b.HasIndex("StartDate")
                        .IsUnique();

                    b.ToTable("Year");
                });

            modelBuilder.Entity("Panda.Core.Domain.Entities.Budgets.Budget", b =>
                {
                    b.HasOne("Panda.Core.Domain.Entities.Companies.Company", "Company")
                        .WithMany("Budgets")
                        .HasForeignKey("CompanyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Panda.Core.Domain.Entities.Years.Year", "Year")
                        .WithMany("Budgets")
                        .HasForeignKey("YearId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Company");

                    b.Navigation("Year");
                });

            modelBuilder.Entity("Panda.Core.Domain.Entities.Categories.Category", b =>
                {
                    b.HasOne("Panda.Core.Domain.Entities.Budgets.Budget", "Budget")
                        .WithMany("Categories")
                        .HasForeignKey("BudgetId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Budget");
                });

            modelBuilder.Entity("Panda.Core.Domain.Entities.Reviews.Review", b =>
                {
                    b.HasOne("Panda.Core.Domain.Entities.Years.Year", "Year")
                        .WithMany()
                        .HasForeignKey("YearId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Year");
                });

            modelBuilder.Entity("Panda.Core.Domain.Entities.Sages.Sage", b =>
                {
                    b.HasOne("Panda.Core.Domain.Entities.Categories.Category", "Category")
                        .WithMany("Sages")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Category");
                });

            modelBuilder.Entity("Panda.Core.Domain.Entities.Sandboxes.Sandbox", b =>
                {
                    b.HasOne("Panda.Core.Domain.Entities.Budgets.Budget", "Budget")
                        .WithOne("Sandbox")
                        .HasForeignKey("Panda.Core.Domain.Entities.Sandboxes.Sandbox", "BudgetId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Budget");
                });

            modelBuilder.Entity("Panda.Core.Domain.Entities.Summaries.Summary", b =>
                {
                    b.HasOne("Panda.Core.Domain.Entities.Budgets.Budget", "Budget")
                        .WithOne("Summary")
                        .HasForeignKey("Panda.Core.Domain.Entities.Summaries.Summary", "BudgetId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Budget");
                });

            modelBuilder.Entity("Panda.Core.Domain.Entities.Tables.Cells.Cell", b =>
                {
                    b.HasOne("Panda.Core.Domain.Entities.Tables.Columns.Column", "Column")
                        .WithMany()
                        .HasForeignKey("ColumnId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Panda.Core.Domain.Entities.Tables.Rows.Row", "Row")
                        .WithMany()
                        .HasForeignKey("RowId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Panda.Core.Domain.Entities.Tables.Table", "Table")
                        .WithMany("Cells")
                        .HasForeignKey("TableId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Column");

                    b.Navigation("Row");

                    b.Navigation("Table");
                });

            modelBuilder.Entity("Panda.Core.Domain.Entities.Tables.Columns.Column", b =>
                {
                    b.HasOne("Panda.Core.Domain.Entities.Tables.Table", "Table")
                        .WithMany("Columns")
                        .HasForeignKey("TableId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Table");
                });

            modelBuilder.Entity("Panda.Core.Domain.Entities.Tables.Rows.Row", b =>
                {
                    b.HasOne("Panda.Core.Domain.Entities.Tables.Table", "Table")
                        .WithMany("Rows")
                        .HasForeignKey("TableId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Table");
                });

            modelBuilder.Entity("Panda.Core.Domain.Entities.Tables.Table", b =>
                {
                    b.HasOne("Panda.Core.Domain.Entities.Reviews.Review", "Review")
                        .WithOne("Table")
                        .HasForeignKey("Panda.Core.Domain.Entities.Tables.Table", "ReviewId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Panda.Core.Domain.Entities.Sandboxes.Sandbox", "Sandbox")
                        .WithOne("Table")
                        .HasForeignKey("Panda.Core.Domain.Entities.Tables.Table", "SandboxId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Panda.Core.Domain.Entities.Summaries.Summary", "Summary")
                        .WithOne("Table")
                        .HasForeignKey("Panda.Core.Domain.Entities.Tables.Table", "SummaryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Review");

                    b.Navigation("Sandbox");

                    b.Navigation("Summary");
                });

            modelBuilder.Entity("Panda.Core.Domain.Entities.Budgets.Budget", b =>
                {
                    b.Navigation("Categories");

                    b.Navigation("Sandbox");

                    b.Navigation("Summary");
                });

            modelBuilder.Entity("Panda.Core.Domain.Entities.Categories.Category", b =>
                {
                    b.Navigation("Sages");
                });

            modelBuilder.Entity("Panda.Core.Domain.Entities.Companies.Company", b =>
                {
                    b.Navigation("Budgets");
                });

            modelBuilder.Entity("Panda.Core.Domain.Entities.Reviews.Review", b =>
                {
                    b.Navigation("Table")
                        .IsRequired();
                });

            modelBuilder.Entity("Panda.Core.Domain.Entities.Sandboxes.Sandbox", b =>
                {
                    b.Navigation("Table")
                        .IsRequired();
                });

            modelBuilder.Entity("Panda.Core.Domain.Entities.Summaries.Summary", b =>
                {
                    b.Navigation("Table")
                        .IsRequired();
                });

            modelBuilder.Entity("Panda.Core.Domain.Entities.Tables.Table", b =>
                {
                    b.Navigation("Cells");

                    b.Navigation("Columns");

                    b.Navigation("Rows");
                });

            modelBuilder.Entity("Panda.Core.Domain.Entities.Years.Year", b =>
                {
                    b.Navigation("Budgets");
                });
#pragma warning restore 612, 618
        }
    }
}
