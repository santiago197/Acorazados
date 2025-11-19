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
        PosicionarNave(Nave.Destroyer, orientacion, fila, columna);
    }

    private static bool EsPosicionHorizontal(Orientacion orientacion) => orientacion == Orientacion.Horizontal;

    private void PosicionarNave(string nave, Orientacion orientacion, int fila, int columna)
    {
        Tablero[fila, columna] = nave;

        if (EsPosicionHorizontal(orientacion))
        {
            if (nave == Nave.Destroyer || nave == Nave.Carrier)
            {
                PosicionarColumna(nave, fila, columna);
                if (nave == Nave.Carrier)
                {
                    Tablero[fila, columna + 3] = nave;
                }
            }
        }
        else
        {
            if (nave == Nave.Destroyer || nave == Nave.Carrier)
            {
                PosicionarFila(nave, fila, columna);
                if (nave == Nave.Carrier)
                {
                    Tablero[fila + 3, columna] = nave;
                }
            }
        }
    }

    private void PosicionarFila(string nave, int fila, int columna)
    {
        Tablero[fila + 1, columna] = nave;
        Tablero[fila + 2, columna] = nave;
    }

    private void PosicionarColumna(string nave, int fila, int columna)
    {
        Tablero[fila, columna + 1] = nave;
        Tablero[fila, columna + 2] = nave;
    }

    public void AgregarCarrier(int fila, int columna, Orientacion orientacion)
    {
        PosicionarNave(Nave.Carrier, orientacion, fila, columna);
    }
}