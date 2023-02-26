using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using SystemTaimsalDevs.EL;

namespace SystemTaimsalDevs.DAL;

public partial class SystemTaimsalDevsContext : DbContext
{
    public SystemTaimsalDevsContext()
    {
    }

    public SystemTaimsalDevsContext(DbContextOptions<SystemTaimsalDevsContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Client> Clients { get; set; }

    public virtual DbSet<Machine> Machines { get; set; }

    public virtual DbSet<Product> Products { get; set; }

    public virtual DbSet<Provider> Providers { get; set; }

    public virtual DbSet<Report> Reports { get; set; }

    public virtual DbSet<Rol> Rols { get; set; }

    public virtual DbSet<UserDev> UserDevs { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        //optionsBuilder.UseSqlServer(@"Data Source=DESKTOP-NJIEQE0\SQLEXPRESS;Initial Catalog=DbSysTaimsalDevs;TrustServerCertificate=True;persist security info=False;Integrated Security=True");
        //optionsBuilder.UseSqlServer(@"workstation id=DbSysTaimsalDev.mssql.somee.com;packet size=4096;user id=UserSysTaimsal_SQLLogin_1;pwd=6eebslpat7;data source=DbSysTaimsalDev.mssql.somee.com;persist security info=False;initial catalog=DbSysTaimsalDev");
        optionsBuilder.UseSqlServer(@"workstation id=DbSysTaimsalDev02.mssql.somee.com;packet size=4096;user id=Razor_SQLLogin_1;pwd=gxaxeekhtu;data source=DbSysTaimsalDev02.mssql.somee.com;TrustServerCertificate=True;persist security info=False;initial catalog=DbSysTaimsalDev02");
    }
    //    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    //#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
    //        => optionsBuilder.UseSqlServer("workstation id=DbSysTaimsalDev.mssql.somee.com;packet size=4096;user id=UserSysTaimsal_SQLLogin_1;pwd=6eebslpat7;data source=DbSysTaimsalDev.mssql.somee.com;TrustServerCertificate=True;persist security info=False;initial catalog=DbSysTaimsalDevs");
    //    /*optionsBuilder.UseSqlServer("workstation id=DbSysTaimsalDev.mssql.somee.com;packet size=4096;user id=UserSysTaimsal_SQLLogin_1;pwd=6eebslpat7;data source=DbSysTaimsalDev.mssql.somee.com;TrustServerCertificate=True;persist security info=False;initial catalog=DbSysTaimsalDev");*/

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Client>(entity =>
        {
            entity.HasKey(e => e.IdClient).HasName("PK__Client__Taimsal_001");
        });

        modelBuilder.Entity<Machine>(entity =>
        {
            entity.HasKey(e => e.IdMachine).HasName("PK__Machine__Taimsal__001");
        });

        modelBuilder.Entity<Product>(entity =>
        {
            entity.HasKey(e => e.IdProduct).HasName("PK__Product__Taimsal_001");
        });

        modelBuilder.Entity<Provider>(entity =>
        {
            entity.HasKey(e => e.IdProvider).HasName("PK__Provider__Taimsal__001");
        });

        modelBuilder.Entity<Report>(entity =>
        {
            entity.HasKey(e => e.IdReport).HasName("PK__Report__001");

            entity.HasOne(d => d.IdClientNavigation).WithMany(p => p.Reports)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK2__Clients__Report");

            entity.HasOne(d => d.IdMachineNavigation).WithMany(p => p.Reports).HasConstraintName("FK5_Machine__Report__001");

            entity.HasOne(d => d.IdProductNavigation).WithMany(p => p.Reports).HasConstraintName("FK4__Products__Report");

            entity.HasOne(d => d.IdProviderNavigation).WithMany(p => p.Reports).HasConstraintName("FK3__Provider__Report__001");

            entity.HasOne(d => d.IdUserNavigation).WithMany(p => p.Reports).HasConstraintName("FK1__User__Report");
        });

        modelBuilder.Entity<Rol>(entity =>
        {
            entity.HasKey(e => e.IdRol).HasName("PK__Rol__TaimsalDev_001");
        });

        modelBuilder.Entity<UserDev>(entity =>
        {
            entity.HasKey(e => e.IdUser).HasName("PK__User__Taimsal__001");

            entity.Property(e => e.Password).IsFixedLength();

            entity.HasOne(d => d.IdRolNavigation).WithMany(p => p.UserDevs)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK1__Rol__User__001");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
