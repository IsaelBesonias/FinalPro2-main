public enum TipoEvento {
    Torneo = 'T',
    Liga = 'L',
    Campeonato = 'C',
    Amistoso = 'A'
}

public class Evento
{
    public int Id { get; set; }
    public string Nombre { get; set; } = "";
    public TipoEvento Tipo { get; set; } = TipoEvento.Torneo;
    public string Sede { get; set; } = "";
    public string Deporte { get; set; } = "";
    public DateTime FechaInicio { get; set; }
    public DateTime FechaFin { get; set; }
    public string Descripcion { get; set; } = "";
    public string LogoUrl { get; set; } = "";

    // Relación con Equipos
    public List<Equipo> EquiposParticipantes { get; set; } = new List<Equipo>();
    
    // Relación con Resultados
    public List<Resultado> Resultados { get; set; } = new List<Resultado>();
}

public class Equipo
{
    public int Id { get; set; }
    public string Nombre { get; set; } = "";
    public string Ciudad { get; set; } = "";
    public string Pais { get; set; } = "";
    public string LogoUrl { get; set; } = "";
    public DateTime FechaFundacion { get; set; }

    // Relación con Jugadores
    public List<Jugador> Jugadores { get; set; } = new List<Jugador>();
    
    // Relación con Eventos
    public List<Evento> EventosParticipados { get; set; } = new List<Evento>();
}

public class Jugador
{
    public int Id { get; set; }
    public string Nombre { get; set; } = "";
    public string Apellido { get; set; } = "";
    public DateTime FechaNacimiento { get; set; }
    public string Posicion { get; set; } = "";
    public string Nacionalidad { get; set; } = "";
    public string FotoUrl { get; set; } = "";
    public int NumeroCamiseta { get; set; }

    // Relación con Equipo
    public int EquipoId { get; set; }
    public Equipo Equipo { get; set; } = null;
}

public class Resultado
{
    public int Id { get; set; }
    public int EventoId { get; set; }
    public Evento Evento { get; set; }
    public int EquipoGanadorId { get; set; }
    public Equipo EquipoGanador { get; set; }
    public int PuntuacionEquipoGanador { get; set; }
    public int EquipoPerderorId { get; set; }
    public Equipo EquipoPerdedor { get; set; }
    public int PuntuacionEquipoPerdedor { get; set; }
    public DateTime FechaResultado { get; set; }
}