namespace AcorazadosTests;

public class Acorazados(int fila, int columna)
{
    public List<Jugador> Jugadores { get; private set; } = [];

    public bool TieneDimensiones(int fila, int columna) =>
        EsCantidadFilasIgualA(fila) && EsCantidadColumnasIgualA(columna);

    public void AgregarJugador(string alias)
    {
        // var jugador = new Jugador(alias)
        // {
        //     Manejador += OnAgregarCanonero
        // };
        Jugadores.Add(new Jugador(alias)
        {
            Tablero = new string[fila, columna]
        });
    }


    public string[,] _tablero = new string[fila, columna];
    private bool EsCantidadColumnasIgualA(int columna) => _tablero.GetLength(1) == columna;
    private bool EsCantidadFilasIgualA(int fila) => _tablero.GetLength(0) == fila;

    public string ObtenerElemento(int fila, int columna)
    {
        return "g";
    }
}