namespace AcorazadosTests;

public class Jugador(string alias)
{
    public string Alias { get; private set; } = alias;
    public string[,] Tablero { get; init; }

    public string ObtenerElemento(int fila, int columna) => Tablero[fila, columna];
    
    public void AgregarCanonero(int fila, int columna)
    {
        Tablero[fila, columna] = Nave.GunShip;
    }

    public void AgregarDestroyer(int fila, int columna, Orientacion orientacion)
    {
        if (EsPosicionHorizontal(orientacion))
            PosicionarDestroyerHorizontal(fila, columna);
        else
            PosicionarDestroyerVertical(fila, columna);
    }

    private static bool EsPosicionHorizontal(Orientacion orientacion) => orientacion == Orientacion.Horizontal;

    private void PosicionarDestroyerVertical(int fila, int columna)
    {
        Tablero[fila, columna] = Nave.Destroyer;
        Tablero[fila + 1, columna] = Nave.Destroyer;
        Tablero[fila + 2, columna] = Nave.Destroyer;
    }

    private void PosicionarDestroyerHorizontal(int fila, int columna)
    {
        Tablero[fila, columna] = Nave.Destroyer;
        Tablero[fila, columna + 1] = Nave.Destroyer;
        Tablero[fila, columna + 2] = Nave.Destroyer;
    }

    public void AgregarCarrier(int i, int i1, Orientacion vertical)
    {
        Tablero[i, i1] = Nave.Carrier;
        Tablero[i + 1, i1] = Nave.Carrier;
        Tablero[i + 2, i1] = Nave.Carrier;
        Tablero[i + 3, i1] = Nave.Carrier;
    }
}