using AwesomeAssertions;

namespace AcorazadosTests;

public class AcorazadosTests
{
    [Fact]
    public void Si_InicializoUnTablero_Debe_TenerDimensionesDe10X10()
    {
        var acorazados = new Acorazados(10, 10);

        acorazados.TieneDimensiones(10, 10).Should().BeTrue();
    }

    [Fact]
    public void Si_InicializoUnTableroDe10x1o_Debe_TenerDimensionesDe10X10()
    {
        var acorazados = new Acorazados(10, 10);

        acorazados.TieneDimensiones(11, 11).Should().BeFalse();
    }

    [Fact]
    public void Si_AgregoUnJugador_Debe_ExistirUnJugadorConElAliasAsignado()
    {
        var acorazados = new Acorazados(10, 10);

        var jugador1 = "jugador 1";
        acorazados.AgregarJugador(jugador1);

        acorazados.Jugadores[jugador1].Alias.Should().Be(jugador1);
    }

    [Fact]
    public void Si_JugadorAgregaCanoneroEnLaPosicionFila2Columna7_Debe_EnTableroEnPosicionX7Y2TenerG()
    {
        var acorazados = new Acorazados(10, 10);
        var jugador1 = "jugador 1";
        acorazados.AgregarJugador(jugador1);

        acorazados.Jugadores[jugador1].AgregarGunShip(2, 7);

        acorazados.ObtenerElemento(jugador1, 2, 7).Should().Be(new GunShip().Valor);
    }

    [Fact]
    public void Si_JugadorAgregaDestroyerEnLaFila3Columna2YOrientacionHorizontal_Debe_TableroOcuparDesde32A34_TenerD()
    {
        var acorazados = new Acorazados(10, 10);
        var jugador1 = "jugador 1";
        acorazados.AgregarJugador(jugador1);

        acorazados.Jugadores[jugador1].AgregarDestroyer(3, 2, Orientacion.Horizontal);

        var valorDestroyer = new Destroyer().Valor;
        acorazados.ObtenerElemento(jugador1, 3, 2).Should().Be(valorDestroyer);
        acorazados.ObtenerElemento(jugador1, 3, 3).Should().Be(valorDestroyer);
        acorazados.ObtenerElemento(jugador1, 3, 4).Should().Be(valorDestroyer);
    }

    [Fact]
    public void Si_JugadorAgregaDestroyerEnLaFila7Columna5YOrientacionVertical_Debe_TableroOcuparDesde75A95_TenerD()
    {
        var acorazados = new Acorazados(10, 10);
        var jugador1 = "jugador 1";
        acorazados.AgregarJugador(jugador1);

        acorazados.Jugadores[jugador1].AgregarDestroyer(7, 5, Orientacion.Vertical);

        var valorDestroyer = new Destroyer().Valor;
        acorazados.ObtenerElemento(jugador1, 7, 5).Should().Be(valorDestroyer);
        acorazados.ObtenerElemento(jugador1, 8, 5).Should().Be(valorDestroyer);
        acorazados.ObtenerElemento(jugador1, 9, 5).Should().Be(valorDestroyer);
    }


    [Fact]
    public void Si_JugadorAgregaCarrierEnLaFila4Columna8YOrientacionVertical_Debe_TableroOcuparDesde48A78_TenerC()
    {
        var acorazados = new Acorazados(10, 10);
        var jugador1 = "jugador 1";
        acorazados.AgregarJugador(jugador1);

        acorazados.Jugadores[jugador1].AgregarCarrier(4, 8, Orientacion.Vertical);

        var valorCarrier = new Carrier().Valor;
        acorazados.ObtenerElemento(jugador1, 4, 8).Should().Be(valorCarrier);
        acorazados.ObtenerElemento(jugador1, 5, 8).Should().Be(valorCarrier);
        acorazados.ObtenerElemento(jugador1, 6, 8).Should().Be(valorCarrier);
        acorazados.ObtenerElemento(jugador1, 7, 8).Should().Be(valorCarrier);
    }

    [Fact]
    public void Si_JugadorAgregaCarrierEnLaFila9Columna0YOrientacionHorizontal_Debe_TableroOcuparDesde90A93_TenerC()
    {
        var acorazados = new Acorazados(10, 10);
        var jugador1 = "jugador 1";
        acorazados.AgregarJugador(jugador1);

        acorazados.Jugadores[jugador1].AgregarCarrier(9, 0, Orientacion.Horizontal);

        var valorCarrier = new Carrier().Valor;
        acorazados.ObtenerElemento(jugador1, 9, 0).Should().Be(valorCarrier);
        acorazados.ObtenerElemento(jugador1, 9, 1).Should().Be(valorCarrier);
        acorazados.ObtenerElemento(jugador1, 9, 2).Should().Be(valorCarrier);
        acorazados.ObtenerElemento(jugador1, 9, 3).Should().Be(valorCarrier);
    }

    [Theory]
    [InlineData(9, -1)]
    [InlineData(9, 10)]
    [InlineData(-1, 10)]
    [InlineData(10, 10)]
    public void Si_JugadorAgregaUnDestroyerFueraDeLosLimitesDelTablero_Debe_LanzarExcepcion(int fila, int columna)
    {
        var acorazados = new Acorazados(10, 10);
        var jugador1 = "jugador 1";
        acorazados.AgregarJugador(jugador1);

        var caller = () => acorazados.Jugadores[jugador1].AgregarDestroyer(fila, columna, Orientacion.Vertical);
        caller.Should().ThrowExactly<IndexOutOfRangeException>()
            .WithMessage($"Nave fuera del rango");
    }

    [Theory]
    [InlineData(9, -1)]
    [InlineData(9, 10)]
    [InlineData(-1, 10)]
    [InlineData(10, 10)]
    public void Si_JugadorAgregaUnCarrierFueraDeLosLimitesDelTablero_Debe_LanzarExcepcion(int fila, int columna)
    {
        var acorazados = new Acorazados(10, 10);
        var jugador1 = "jugador 1";
        acorazados.AgregarJugador(jugador1);

        var caller = () => acorazados.Jugadores[jugador1].AgregarCarrier(fila, columna, Orientacion.Vertical);
        caller.Should().ThrowExactly<IndexOutOfRangeException>()
            .WithMessage("Nave fuera del rango");
    }


    [Theory]
    [InlineData(Orientacion.Vertical)]
    [InlineData(Orientacion.Horizontal)]
    public void Si_JugadorAgregaUnCarrierEnOrientacionIndicadaSinTenerElEspacioSuficiente_Debe_LanzarExcepcion(
        Orientacion orientacion)
    {
        var acorazados = new Acorazados(10, 10);
        var jugador1 = "jugador 1";
        acorazados.AgregarJugador(jugador1);

        var caller = () => acorazados.Jugadores[jugador1].AgregarCarrier(9, 7, orientacion);
        caller.Should().ThrowExactly<IndexOutOfRangeException>()
            .WithMessage("Nave fuera del rango");
    }

    [Fact]
    public void Si_Jugador1AgregaUnGunshipEnLaPosicion00_Debe_ImprimirTableroGunShip()
    {
        var acorazados = new Acorazados(10, 10);
        var jugador1 = "jugador 1";

        string expected = " |0|1|2|3|4|5|6|7|8|9|\r\n" +
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


        acorazados.AgregarJugador(jugador1);
        acorazados.Jugadores[jugador1].AgregarGunShip(0, 0);

        acorazados.Jugadores[jugador1].ImprimirTablero().Should().Be(expected);
    }
}