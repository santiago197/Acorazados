namespace AcorazadosTests;

public class Jugador
{
    private int _longitudColumnas;
    private int _longitudFilas;

    public Jugador(string alias)
    {
        Alias = alias;
    }

    public string Alias { get; private set; }
    public string[,] Tablero { get; init; }

    public string ObtenerElemento(int fila, int columna) => Tablero[fila, columna];

    public void AgregarCanonero(int fila, int columna)
    {
        Tablero[fila, columna] = Nave.GunShip;
    }


    public void AgregarDestroyer(int fila, int columna, Orientacion orientacion)
    {
        LanzarExcepcionSiSuperaLimitesTablero(fila, columna, LongitudNave.Destroyer, orientacion);
        PosicionarNave(Nave.Destroyer, orientacion, fila, columna);
    }

    public void AgregarCarrier(int fila, int columna, Orientacion orientacion)
    {
        LanzarExcepcionSiSuperaLimitesTablero(fila, columna, LongitudNave.Carrier, orientacion);
        PosicionarNave(Nave.Carrier, orientacion, fila, columna);
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

    private void LanzarExcepcionSiSuperaLimitesTablero(int fila, int columna, LongitudNave longitudNave,
        Orientacion orientacion)
    {
        _longitudColumnas = Tablero.GetLength(1);
        var noTieneEspacioSuficiente =
            columna + (int)longitudNave > _longitudColumnas && EsPosicionHorizontal(orientacion);
        _longitudFilas = Tablero.GetLength(0);
        var noTieneEspacioSuficienteEnFilas =
            fila + (int)longitudNave > _longitudFilas && EsPosicionVertical(orientacion);


        if ((fila >= _longitudFilas || fila < 0 && EsPosicionVertical(orientacion))
            || noTieneEspacioSuficienteEnFilas)
            throw new IndexOutOfRangeException("Nave fuera del rango");
        if (columna >= _longitudColumnas || columna < 0 || noTieneEspacioSuficiente)
            throw new IndexOutOfRangeException("Nave fuera del rango");
    }

    private bool EsPosicionVertical(Orientacion orientacion) => orientacion == Orientacion.Vertical;
}

public enum LongitudNave
{
    Carrier = 4,
    Destroyer = 3
}