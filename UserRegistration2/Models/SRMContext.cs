using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.Extensions.Configuration;

#nullable disable

namespace UserRegistration2.Models
{
    public partial class SRMContext : DbContext
    {
        public SRMContext()
        {
        }

        public SRMContext(DbContextOptions<SRMContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Category> Category { get; set; }
        public virtual DbSet<Comment> Comments { get; set; }
        public virtual DbSet<Department> Department { get; set; }
        public virtual DbSet<Employee> Employees { get; set; }
        public virtual DbSet<Request> Request { get; set; }
        public virtual DbSet<RequestType> RequestTypes { get; set; }
        public virtual DbSet<Role> Roles { get; set; }
        public virtual DbSet<Status> Status { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
                if (!optionsBuilder.IsConfigured)
                {
                    IConfigurationRoot configuration = new ConfigurationBuilder()
                         .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
                         .AddJsonFile("appsettings.json")
                         .Build();
                    optionsBuilder.UseSqlServer(configuration.GetConnectionString("DevConnection"));
                }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>(entity =>
            {
                entity.ToTable("Category");

                entity.Property(e => e.Description).HasMaxLength(50);

                entity.Property(e => e.LastModifiedBy)
                    .IsRequired()
                    .HasMaxLength(15);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.HasOne(d => d.Department)
                    .WithMany(p => p.Categories)
                    .HasForeignKey(x => x.DepartmentId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Category_Category");
            });

            modelBuilder.Entity<Comment>(entity =>
            {
                entity.Property(e => e.Comment1)
                    .IsRequired()
                    .HasMaxLength(100)
                    .HasColumnName("Comment");

                entity.Property(e => e.LastModifiedBy)
                    .IsRequired()
                    .HasMaxLength(15);

                entity.HasOne(d => d.Employee)
                    .WithMany(p => p.Comments)
                    .HasForeignKey(x => x.EmployeeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Comments_Employee");

                entity.HasOne(d => d.Request)
                    .WithMany(p => p.Comments)
                    .HasForeignKey(x => x.RequestId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Comments_Request");
            });

            modelBuilder.Entity<Department>(entity =>
            {
                entity.ToTable("Department");

                entity.Property(e => e.LastModifiedBy)
                    .IsRequired()
                    .HasMaxLength(15);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(20);
            });

            modelBuilder.Entity<Employee>(entity =>
            {
                entity.ToTable("Employee");

                entity.Property(e => e.EmailId)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasMaxLength(20);

                entity.Property(e => e.Gender)
                    .IsRequired()
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.LastModifiedBy).HasMaxLength(15);

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasMaxLength(20);

                entity.Property(e => e.MiddleName).HasMaxLength(20);

                entity.Property(e => e.Password).IsRequired();

                entity.Property(e => e.Phone)
                    .IsRequired()
                    .HasMaxLength(13);

                entity.HasOne(d => d.Department)
                    .WithMany(p => p.Employees)
                    .HasForeignKey(x => x.DepartmentId)
                    .HasConstraintName("FK_Employee_Department");

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.Employees)
                    .HasForeignKey(x => x.RoleId)
                    .HasConstraintName("FK_Employee_Role");
            });

            modelBuilder.Entity<Request>(entity =>
            {
                entity.ToTable("Request");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.LastModifiedBy)
                    .IsRequired()
                    .HasMaxLength(15);

                entity.Property(e => e.Summary)
                    .IsRequired()
                    .HasMaxLength(250);

                entity.Property(e => e.Title)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.HasOne(d => d.AssignedEmp)
                    .WithMany(p => p.RequestAssignedEmps)
                    .HasForeignKey(x => x.AssignedEmpId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Request_Employee1");

                entity.HasOne(d => d.Category)
                    .WithMany(p => p.RequestCategories)
                    .HasForeignKey(x => x.CategoryId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Request_Category");

                entity.HasOne(d => d.CreatedEmp)
                    .WithMany(p => p.RequestCreatedEmps)
                    .HasForeignKey(x => x.CreatedEmpId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Request_Employee");

                entity.HasOne(d => d.Department)
                    .WithMany(p => p.Requests)
                    .HasForeignKey(x => x.DepartmentId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Request_Department");

                entity.HasOne(d => d.RequestType)
                    .WithMany(p => p.Requests)
                    .HasForeignKey(x => x.RequestTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Request_RequestType");

                entity.HasOne(d => d.Status)
                    .WithMany(p => p.Requests)
                    .HasForeignKey(x => x.StatusId)
                    .HasConstraintName("FK_Request_Status");

                entity.HasOne(d => d.SubCategory)
                    .WithMany(p => p.RequestSubCategories)
                    .HasForeignKey(x => x.SubCategoryId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_SubRequest_Category");
            });

            modelBuilder.Entity<RequestType>(entity =>
            {
                entity.ToTable("RequestType");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.LastModifiedBy)
                    .IsRequired()
                    .HasMaxLength(15);

                entity.Property(e => e.RequestType1)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("RequestType");
            });

            modelBuilder.Entity<Role>(entity =>
            {
                entity.ToTable("Role");

                entity.Property(e => e.LastModifiedBy)
                    .IsRequired()
                    .HasMaxLength(15);

                entity.Property(e => e.Role1)
                    .HasMaxLength(10)
                    .HasColumnName("Role")
                    .IsFixedLength(true);
            });

            modelBuilder.Entity<Status>(entity =>
            {
                entity.ToTable("Status");

                entity.Property(e => e.LastModifiedBy)
                    .IsRequired()
                    .HasMaxLength(15);

                entity.Property(e => e.Status1)
                    .IsRequired()
                    .HasMaxLength(10)
                    .HasColumnName("Status")
                    .IsFixedLength(true);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
