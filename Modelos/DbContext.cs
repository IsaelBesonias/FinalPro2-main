using Microsoft.EntityFrameworkCore;

public class EventoDeportivoContext : DbContext 
{
    // Definimos los DbSet para cada entidad
    public DbSet<Evento> Eventos { get; set; } = null;
    public DbSet<Equipo> Equipos { get; set; } = null;
    public DbSet<Jugador> Jugadores { get; set; } = null;
    public DbSet<Resultado> Resultados { get; set; } = null;

    // Constructor que acepta opciones de configuración
    public EventoDeportivoContext(DbContextOptions<EventoDeportivoContext> options) : base(options) {}

    // Método opcional para configurar relaciones y restricciones
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        // Configuraciones de relaciones
        modelBuilder.Entity<Evento>()
            .HasMany(e => e.EquiposParticipantes)
            .WithMany(eq => eq.EventosParticipados);

        modelBuilder.Entity<Equipo>()
            .HasMany(eq => eq.Jugadores)
            .WithOne(j => j.Equipo)
            .HasForeignKey(j => j.EquipoId);

        modelBuilder.Entity<Resultado>()
            .HasOne(r => r.Evento)
            .WithMany(e => e.Resultados)
            .HasForeignKey(r => r.EventoId);

        modelBuilder.Entity<Resultado>()
            .HasOne(r => r.EquipoGanador)
            .WithMany()
            .HasForeignKey(r => r.EquipoGanadorId)
            .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<Resultado>()
            .HasOne(r => r.EquipoPerdedor)
            .WithMany()
            .HasForeignKey(r => r.EquipoPerderorId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}