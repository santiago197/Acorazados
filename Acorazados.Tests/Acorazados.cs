namespace AcorazadosTests;

public class Acorazados
{
    public readonly Dictionary<string, Jugador> Jugadores = new();

    public bool TieneDimensiones(int fila, int columna) =>
        EsCantidadFilasIgualA(fila) && EsCantidadColumnasIgualA(columna);

    public void AgregarJugador(string alias)
    {
        Jugadores.Add(alias, new Jugador(alias)
        {
            Tablero = new string[_fila, _columna]
        });
    }

    private string[,] _tablero;
    private readonly int _fila = 10;
    private readonly int _columna = 10;
    public Dictionary<string, string[,]> Tableros { get; set; }

    public Acorazados()
    {
        _tablero = new string[_fila, _columna];
    }

    private bool EsCantidadColumnasIgualA(int columna) => _tablero.GetLength(1) == columna;
    private bool EsCantidadFilasIgualA(int fila) => _tablero.GetLength(0) == fila;

    public string ObtenerElemento(string aliasJugador, int fila, int columna)
    {
        if (ExisteJugador(aliasJugador))
            return Jugadores[aliasJugador].ObtenerElemento(fila, columna);

        return "";
    }

    private bool ExisteJugador(string aliasJugador)
    {
        return Jugadores.ContainsKey(aliasJugador);
    }
}