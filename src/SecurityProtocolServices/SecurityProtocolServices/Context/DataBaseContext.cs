using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using SecurityProtocolServices.Models;

namespace SecurityProtocolServices.Context;

public partial class DataBaseContext : DbContext
{
    private static Lazy<DataBaseContext> _lazy = new Lazy<DataBaseContext>(() => new DataBaseContext());
    public static DataBaseContext Context = _lazy.Value;
    private DataBaseContext()
    {
    }

    private DataBaseContext(DbContextOptions<DataBaseContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Authorization> Authorizations { get; set; }

    public virtual DbSet<AuthorizationGuard> AuthorizationGuards { get; set; }

    public virtual DbSet<Department> Departments { get; set; }

    public virtual DbSet<Division> Divisions { get; set; }

    public virtual DbSet<Document> Documents { get; set; }

    public virtual DbSet<Email> Emails { get; set; }

    public virtual DbSet<Employee> Employees { get; set; }

    public virtual DbSet<Gender> Genders { get; set; }

    public virtual DbSet<Order> Orders { get; set; }

    public virtual DbSet<Post> Posts { get; set; }

    public virtual DbSet<Status> Statuses { get; set; }

    public virtual DbSet<StatusGuard> StatusGuards { get; set; }

    public virtual DbSet<TypeOrder> TypeOrders { get; set; }

    public virtual DbSet<TypeUser> TypeUsers { get; set; }

    public virtual DbSet<User> Users { get; set; }

    public virtual DbSet<Visitor> Visitors { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=DESKTOP-S9N70VV\\EVGENIY_LYKHOV;DataBase=!WSR;User Id=Evgeniy_Lykhov; Password=Tar4ok.3.SQL*; TrustServerCertificate=true");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Authorization>(entity =>
        {
            entity.ToTable("Authorization");

            entity.Property(e => e.Email).HasMaxLength(50);
            entity.Property(e => e.Login).HasMaxLength(50);
            entity.Property(e => e.Password).HasMaxLength(50);

            entity.HasOne(d => d.EmailNavigation).WithMany(p => p.Authorizations)
                .HasForeignKey(d => d.Email)
                .HasConstraintName("FK_Authorization_Email");
        });

        modelBuilder.Entity<AuthorizationGuard>(entity =>
        {
            entity.ToTable("AuthorizationGuard");

            entity.Property(e => e.Id).ValueGeneratedOnAdd();
            entity.Property(e => e.Login).HasMaxLength(50);
            entity.Property(e => e.Passwod).HasMaxLength(50);
            entity.Property(e => e.SecretWord).HasMaxLength(50);

            entity.HasOne(d => d.IdNavigation).WithOne(p => p.AuthorizationGuard)
                .HasForeignKey<AuthorizationGuard>(d => d.Id)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_AuthorizationGuard_User");
        });

        modelBuilder.Entity<Department>(entity =>
        {
            entity.ToTable("Department");

            entity.Property(e => e.Name).HasMaxLength(50);
        });

        modelBuilder.Entity<Division>(entity =>
        {
            entity.ToTable("Division");

            entity.Property(e => e.Name).HasMaxLength(50);
        });

        modelBuilder.Entity<Document>(entity =>
        {
            entity.ToTable("Document");

            entity.Property(e => e.Path).HasMaxLength(50);

            entity.HasOne(d => d.Order).WithMany(p => p.Documents)
                .HasForeignKey(d => d.OrderId)
                .HasConstraintName("FK_Document_Order");
        });

        modelBuilder.Entity<Email>(entity =>
        {
            entity.HasKey(e => e.Email1);

            entity.ToTable("Email");

            entity.Property(e => e.Email1)
                .HasMaxLength(50)
                .HasColumnName("Email");
        });

        modelBuilder.Entity<Employee>(entity =>
        {
            entity.HasKey(e => e.Code);

            entity.ToTable("Employee");

            entity.Property(e => e.Code).ValueGeneratedNever();
            entity.Property(e => e.LastName).HasMaxLength(50);
            entity.Property(e => e.Name).HasMaxLength(50);
            entity.Property(e => e.Patronymic).HasMaxLength(50);

            entity.HasOne(d => d.Department).WithMany(p => p.Employees)
                .HasForeignKey(d => d.DepartmentId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK_Employee_Department");

            entity.HasOne(d => d.Division).WithMany(p => p.Employees)
                .HasForeignKey(d => d.DivisionId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK_Employee_Division");
        });

        modelBuilder.Entity<Gender>(entity =>
        {
            entity.ToTable("Gender");

            entity.Property(e => e.Name).HasMaxLength(50);
        });

        modelBuilder.Entity<Order>(entity =>
        {
            entity.ToTable("Order");

            entity.Property(e => e.EndDate).HasColumnType("datetime");
            entity.Property(e => e.GoalVisit).HasMaxLength(50);
            entity.Property(e => e.NameGroup).HasMaxLength(50);
            entity.Property(e => e.Purpose).HasMaxLength(50);
            entity.Property(e => e.ReasonForRefusal).HasMaxLength(50);
            entity.Property(e => e.StartDate).HasColumnType("datetime");

            entity.HasOne(d => d.CodeEmployeeNavigation).WithMany(p => p.Orders)
                .HasForeignKey(d => d.CodeEmployee)
                .HasConstraintName("FK_Order_Employee");

            entity.HasOne(d => d.Status).WithMany(p => p.Orders)
                .HasForeignKey(d => d.StatusId)
                .HasConstraintName("FK_Order_Status");

            entity.HasOne(d => d.TypeOrder).WithMany(p => p.Orders)
                .HasForeignKey(d => d.TypeOrderId)
                .HasConstraintName("FK_Order_TypeOrder");
        });

        modelBuilder.Entity<Post>(entity =>
        {
            entity.ToTable("Post");

            entity.Property(e => e.Name).HasMaxLength(50);
        });

        modelBuilder.Entity<Status>(entity =>
        {
            entity.ToTable("Status");

            entity.Property(e => e.Name).HasMaxLength(50);
        });

        modelBuilder.Entity<StatusGuard>(entity =>
        {
            entity.ToTable("StatusGuard");

            entity.Property(e => e.Name).HasMaxLength(50);
        });

        modelBuilder.Entity<TypeOrder>(entity =>
        {
            entity.ToTable("TypeOrder");

            entity.Property(e => e.Name).HasMaxLength(50);
        });

        modelBuilder.Entity<TypeUser>(entity =>
        {
            entity.ToTable("TypeUser");

            entity.Property(e => e.Name).HasMaxLength(50);
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.ToTable("User");

            entity.Property(e => e.GenderId).HasColumnName("GenderID");
            entity.Property(e => e.LastName).HasMaxLength(50);
            entity.Property(e => e.Name).HasMaxLength(50);
            entity.Property(e => e.Patronymic).HasMaxLength(50);

            entity.HasOne(d => d.Gender).WithMany(p => p.Users)
                .HasForeignKey(d => d.GenderId)
                .HasConstraintName("FK_User_Gender");

            entity.HasOne(d => d.Post).WithMany(p => p.Users)
                .HasForeignKey(d => d.PostId)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("FK_User_Post");

            entity.HasOne(d => d.Status).WithMany(p => p.Users)
                .HasForeignKey(d => d.StatusId)
                .HasConstraintName("FK_User_StatusGuard");

            entity.HasOne(d => d.TypeUser).WithMany(p => p.Users)
                .HasForeignKey(d => d.TypeUserId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK_User_TypeUser");
        });

        modelBuilder.Entity<Visitor>(entity =>
        {
            entity.ToTable("Visitor");

            entity.Property(e => e.DateOfBirth).HasColumnType("datetime");
            entity.Property(e => e.Email).HasMaxLength(50);
            entity.Property(e => e.ImagePath).HasMaxLength(150);
            entity.Property(e => e.LastName).HasMaxLength(50);
            entity.Property(e => e.Name).HasMaxLength(50);
            entity.Property(e => e.Notes).HasMaxLength(50);
            entity.Property(e => e.Organization).HasMaxLength(50);
            entity.Property(e => e.Patronymic).HasMaxLength(50);
            entity.Property(e => e.PhoneNumber).HasMaxLength(50);

            entity.HasOne(d => d.EmailNavigation).WithMany(p => p.Visitors)
                .HasForeignKey(d => d.Email)
                .HasConstraintName("FK_Visitor_Email");

            entity.HasMany(d => d.Orders).WithMany(p => p.Visitors)
                .UsingEntity<Dictionary<string, object>>(
                    "VisitorOrder",
                    r => r.HasOne<Order>().WithMany()
                        .HasForeignKey("OrderId")
                        .HasConstraintName("FK_VisitorOrder_Order"),
                    l => l.HasOne<Visitor>().WithMany()
                        .HasForeignKey("VisitorId")
                        .HasConstraintName("FK_VisitorOrder_Visitor"),
                    j =>
                    {
                        j.HasKey("VisitorId", "OrderId");
                        j.ToTable("VisitorOrder");
                    });
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
