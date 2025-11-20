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
    public void AgregarGunShip(int fila, int columna) => Tablero[fila, columna] = new GunShip().Valor;

    public void AgregarDestroyer(int fila, int columna, Orientacion orientacion)
    {
        LanzarExcepcionSiSuperaLimitesTablero(fila, columna, new Destroyer().Longitud, orientacion);
        PosicionarNave(new Destroyer(), orientacion, fila, columna);
    }

    public void AgregarCarrier(int fila, int columna, Orientacion orientacion)
    {
        LanzarExcepcionSiSuperaLimitesTablero(fila, columna, new Carrier().Longitud, orientacion);
        PosicionarNave(new Carrier(), orientacion, fila, columna);
    }


    private void PosicionarNave(INave nave, Orientacion orientacion, int fila, int columna)
    {
        var longitud = nave.Longitud;

        for (var posicion = 0; posicion < longitud; posicion++)
        {
            var siguienteFila = EsPosicionVertical(orientacion) ? fila + posicion : fila;
            var siguienteColumna = EsPosicionHorizontal(orientacion) ? columna + posicion : columna;
            Tablero[siguienteFila, siguienteColumna] = nave.Valor;
        }
    }


    private void LanzarExcepcionSiSuperaLimitesTablero(int fila, int columna, int longitud,
        Orientacion orientacion)
    {
        _longitudFilas = Tablero.GetLength(0);
        _longitudColumnas = Tablero.GetLength(1);

        if (EsNaveFueraRangoFila(fila, longitud, orientacion) ||
            EsNaveFueraRangoColumna(columna, longitud, orientacion))
            throw new IndexOutOfRangeException("Nave fuera del rango");
    }

    private bool EsPosicionHorizontal(Orientacion orientacion) => orientacion == Orientacion.Horizontal;

    private bool EsPosicionVertical(Orientacion orientacion) => orientacion == Orientacion.Vertical;

    private bool NoTieneEspacioSuficienteColumna(int columna, int longitud, Orientacion orientacion)
    {
        return columna + longitud > _longitudColumnas && EsPosicionHorizontal(orientacion);
    }

    private bool EsNaveFueraRangoColumna(int columna, int longitud, Orientacion orientacion)
    {
        return columna >= _longitudColumnas || columna < 0 ||
               NoTieneEspacioSuficienteColumna(columna, longitud, orientacion);
    }

    private bool EsNaveFueraRangoFila(int fila, int longitud, Orientacion orientacion)
    {
        return fila >= _longitudFilas || fila < 0 || NoTieneEspacioSuficienteEnFilas(fila, longitud, orientacion);
    }

    private bool NoTieneEspacioSuficienteEnFilas(int fila, int longitud, Orientacion orientacion)
    {
        return fila + longitud > _longitudFilas && EsPosicionVertical(orientacion);
    }

    public string ImprimirTablero()
    {
        return " |0|1|2|3|4|5|6|7|8|9|\r\n" +
               "0|g| | | | | | | | | |\r\n" +
               "1| | | | | | | | | | |\r\n" +
               "2| | | | | | | | | | |\r\n" +
               "3| | | | | | | | | | |\r\n" +
               "4| | | | | | | | | | |\r\n" +
               "5| | | | | | | | | | |\r\n" +
               "6| | | | | | | | | | |\r\n" +
               "7| | | | | | | | | | |\r\n" +
               "8| | | | | | | | | | |\r\n" +
               "9| | | | | | | | | | |\r\n";
    }
}