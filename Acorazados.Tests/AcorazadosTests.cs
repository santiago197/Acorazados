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
        var acorozados = new Acorazados(10, 10);
        var jugador1 = "jugador 1";
        acorozados.AgregarJugador(jugador1);

        acorozados.Jugadores[jugador1].AgregarCanonero(2, 7);

        acorozados.ObtenerElemento(jugador1, 2, 7).Should().Be(Nave.GunShip);
    }

    [Fact]
    public void Si_JugadorAgregaDestroyerEnLaFila3Columna2YOrientacionHorizontal_Debe_TableroOcuparDesde32A34_TenerD()
    {
        var acorazados = new Acorazados(10, 10);
        var jugador1 = "jugador 1";
        acorazados.AgregarJugador(jugador1);

        acorazados.Jugadores[jugador1].AgregarDestroyer(3, 2, Orientacion.Horizontal);

        acorazados.ObtenerElemento(jugador1, 3, 2).Should().Be(Nave.Destroyer);
        acorazados.ObtenerElemento(jugador1, 3, 3).Should().Be(Nave.Destroyer);
        acorazados.ObtenerElemento(jugador1, 3, 4).Should().Be(Nave.Destroyer);
    }

    [Fact]
    public void Si_JugadorAgregaDestroyerEnLaFila7Columna5YOrientacionVertical_Debe_TableroOcuparDesde75A95_TenerD()
    {
        var acorazados = new Acorazados(10, 10);
        var jugador1 = "jugador 1";
        acorazados.AgregarJugador(jugador1);

        acorazados.Jugadores[jugador1].AgregarDestroyer(7, 5, Orientacion.Vertical);

        acorazados.ObtenerElemento(jugador1, 7, 5).Should().Be(Nave.Destroyer);
        acorazados.ObtenerElemento(jugador1, 8, 5).Should().Be(Nave.Destroyer);
        acorazados.ObtenerElemento(jugador1, 9, 5).Should().Be(Nave.Destroyer);
    }


    [Fact]
    public void Si_JugadorAgregaCarrierEnLaFila4Columna8YOrientacionVertical_Debe_TableroOcuparDesde48A78_TenerC()
    {
        var acorazados = new Acorazados(10, 10);
        var jugador1 = "jugador 1";
        acorazados.AgregarJugador(jugador1);

        acorazados.Jugadores[jugador1].AgregarCarrier(4, 8, Orientacion.Vertical);

        acorazados.ObtenerElemento(jugador1, 4, 8).Should().Be(Nave.Carrier);
        acorazados.ObtenerElemento(jugador1, 5, 8).Should().Be(Nave.Carrier);
        acorazados.ObtenerElemento(jugador1, 6, 8).Should().Be(Nave.Carrier);
        acorazados.ObtenerElemento(jugador1, 7, 8).Should().Be(Nave.Carrier);
    }

    [Fact]
    public void Si_JugadorAgregaCarrierEnLaFila9Columna0YOrientacionHorizontal_Debe_TableroOcuparDesde90A93_TenerC()
    {
        var acorazados = new Acorazados(10, 10);
        var jugador1 = "jugador 1";
        acorazados.AgregarJugador(jugador1);

        acorazados.Jugadores[jugador1].AgregarCarrier(9, 0, Orientacion.Horizontal);

        acorazados.ObtenerElemento(jugador1, 9, 0).Should().Be(Nave.Carrier);
        acorazados.ObtenerElemento(jugador1, 9, 1).Should().Be(Nave.Carrier);
        acorazados.ObtenerElemento(jugador1, 9, 2).Should().Be(Nave.Carrier);
        acorazados.ObtenerElemento(jugador1, 9, 3).Should().Be(Nave.Carrier);
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

    [Fact]
    public void Si_JugadorAgregaUnCarrierEnOrientacionHorizontalSinTenerElEspacioSuficiente_Debe_LanzarExcepcion()
    {
        var acorazados = new Acorazados(10, 10);
        var jugador1 = "jugador 1";
        acorazados.AgregarJugador(jugador1);

        var caller = () => acorazados.Jugadores[jugador1].AgregarCarrier(9, 7, Orientacion.Horizontal);
        caller.Should().ThrowExactly<IndexOutOfRangeException>()
            .WithMessage("Nave fuera del rango");
    }

    [Fact]
    public void Si_JugadorAgregaUnCarrierEnOrientacionVerticalSinTenerElEspacioSuficiente_Debe_LanzarExcepcion()
    {
        var acorazados = new Acorazados(10, 10);
        var jugador1 = "jugador 1";
        acorazados.AgregarJugador(jugador1);

        var caller = () => acorazados.Jugadores[jugador1].AgregarCarrier(9, 7, Orientacion.Vertical);
        caller.Should().ThrowExactly<IndexOutOfRangeException>()
            .WithMessage("Nave fuera del rango");
    }
}