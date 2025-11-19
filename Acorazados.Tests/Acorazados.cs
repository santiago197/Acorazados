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

    public string[,] _tablero;
    private readonly int _fila;
    private readonly int _columna;

    public Acorazados(int fila, int columna)
    {
        _fila = fila;
        _columna = columna;
        _tablero = new string[fila, columna];
    }

    private bool EsCantidadColumnasIgualA(int columna) => _tablero.GetLength(1) == columna;
    private bool EsCantidadFilasIgualA(int fila) => _tablero.GetLength(0) == fila;

    public string ObtenerElemento(string aliasJugador, int fila, int columna)
    {
        if (ExisteJugador(aliasJugador))
            return Jugadores[aliasJugador].ObtenerElemento(fila, columna);

        return Nave.GunShip;
    }

    private bool ExisteJugador(string aliasJugador)
    {
        return Jugadores.ContainsKey(aliasJugador);
    }
}