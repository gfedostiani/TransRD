namespace TransRD.Data
{
  using Microsoft.EntityFrameworkCore;
  using Microsoft.Extensions.Options;
  using System.Runtime.CompilerServices;
  using TransRD.Infraestructura.Models;

  public class TransRDDbContext : DbContext
  {
    public DbSet<Boleto> Boleto { get; set; }
    public DbSet<CodigoQR> CodigoQR { get; set; }
    public DbSet<ConfiguracionTarifas> ConfiguracionTarifa { get; set; }
    public DbSet<CuentaSaldo> CuentaSaldo { get; set; }
    public DbSet<Recarga> Recarga {  get; set; }
    public DbSet<TipoTransporte> TipoTransporte { get; set; }
    public DbSet<Usuario> Usuario { get; set; }
    public DbSet<Viaje> Viaje { get; set; }

    public TransRDDbContext(DbContextOptions<TransRDDbContext> options) : base (options ){

    }

    public TransRDDbContext(DbContextOptions options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
    }
  }
}
