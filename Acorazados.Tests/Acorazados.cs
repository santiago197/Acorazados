namespace AcorazadosTests;

public class Acorazados(int fila, int columna)
{
    public readonly Dictionary<string, Jugador> Jugadores = new();

    public bool TieneDimensiones(int fila, int columna) =>
        EsCantidadFilasIgualA(fila) && EsCantidadColumnasIgualA(columna);

    public void AgregarJugador(string alias)
    {
        Jugadores.Add(alias, new Jugador(alias)
        {
            Tablero = new string[fila, columna]
        });
    }


    public string[,] _tablero = new string[fila, columna];
    private bool EsCantidadColumnasIgualA(int columna) => _tablero.GetLength(1) == columna;
    private bool EsCantidadFilasIgualA(int fila) => _tablero.GetLength(0) == fila;

    public string ObtenerElemento(string aliasJugador, int fila, int columna)
    {
        if (Jugadores.ContainsKey(aliasJugador))
        {
            return Jugadores[aliasJugador].Tablero[fila, columna];
        }

        return Nave.GunShip;
    }
}