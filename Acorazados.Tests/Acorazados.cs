namespace AcorazadosTests;

public class Acorazados(int x, int y)
{
    public List<Jugador> Jugadores { get; private set; } = [];
    public bool TieneDimensiones(int x, int y) => EsCantidadFilasIgualA(x) && EsCantidadColumnasIgualA(y);
    public void AgregarJugador(string alias) => Jugadores.Add(new Jugador(alias));
    private readonly string[,] _tablero = new string[x, y];
    private bool EsCantidadColumnasIgualA(int y) => _tablero.GetLength(1) == y;
    private bool EsCantidadFilasIgualA(int x) => _tablero.GetLength(0) == x;
}