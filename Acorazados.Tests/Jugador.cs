namespace AcorazadosTests;

public class Jugador(string alias)
{
    public string Alias { get; private set; } = alias;
    public string[,] Tablero { get; set; }


    public void AgregarCanonero(int fila, int columna)
    {
        Tablero[fila, columna] = "g";
    }
}