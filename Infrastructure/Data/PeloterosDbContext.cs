using Dominio.Entities;
using Dominio.Entities.Identity;
using Dominio.Seed;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data;

public partial class PeloterosDbContext : IdentityDbContext<AppUser>
{


    public PeloterosDbContext(DbContextOptions<PeloterosDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Bloqueo> Bloqueos { get; set; }

    public DbSet<RefreshToken> RefreshToken { get; set; }

    public virtual DbSet<Cliente> Clientes { get; set; }

    public virtual DbSet<HorariosDisponibilidad> HorariosDisponibilidads { get; set; }

    public virtual DbSet<Pago> Pagos { get; set; }

    public virtual DbSet<Recurso> Recursos { get; set; }

    public virtual DbSet<Turno> Turnos { get; set; }

    //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    //    => optionsBuilder.UseSqlServer("Name=ConnectionStrings:DefaultConnectionString");

    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {

        base.OnModelCreating(modelBuilder);




        modelBuilder.ApplyConfiguration(new RolesConfiguration());
        modelBuilder.ApplyConfiguration(new RecursoConfiguration());
        modelBuilder.ApplyConfiguration(new ClientesConfiguration());
        modelBuilder.ApplyConfiguration(new HorariosDisponibilidadConfiguration());
        modelBuilder.ApplyConfiguration(new AppUserConfiguration());
        modelBuilder.ApplyConfiguration(new RolesUserConfiguration());



    }

}
