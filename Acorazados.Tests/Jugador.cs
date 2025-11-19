namespace AcorazadosTests;

public class Jugador(string alias)
{
    public string Alias { get; private set; } = alias;
    public string[,] Tablero { get; init; }


    public void AgregarCanonero(int fila, int columna)
    {
        Tablero[fila, columna] = Nave.GunShip;
    }

    public void AgregarDestroyer(int fila, int columna, Orientacion orientacion)
    {
        Tablero[fila, columna] = Nave.Destroyer;

        if (orientacion == Orientacion.Horizontal)
        {
            Tablero[fila, columna + 1] = Nave.Destroyer;
            Tablero[fila, columna + 2] = Nave.Destroyer;
        }
        else
        {
            Tablero[fila + 1, columna] = Nave.Destroyer;
            Tablero[fila + 2, columna] = Nave.Destroyer;
            
        }
    }
}

public enum Orientacion
{
    Horizontal,
    Vertical
}

public static class Nave
{
    public const string GunShip = "g";
    public const string Destroyer = "d";
}