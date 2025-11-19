namespace AcorazadosTests;

public class Jugador(string alias)
{
    public string Alias { get; private set; } = alias;
    public string[,] Tablero { get; set; }


    public void AgregarCanonero(int fila, int columna)
    {
        Tablero[fila, columna] = "g";
    }

    public void AgregarDestroyer(int i, int i1, string horizontal)
    {
        Tablero[i, i1] = "d";

        if (horizontal == "horizontal")
        {
            Tablero[i, i1 + 1] = "d";
            Tablero[i, i1 + 2] = "d";
        }
    }

    public object ObtenerElemento(int i, int i1)
    {
        throw new NotImplementedException();
    }
}