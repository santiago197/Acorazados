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
    public void Si_InicializoUnTableroDe10x10_Debe_TenerDimensionesDe10X10()
    {
        var acorazados = new Acorazados(10, 10);

        acorazados.TieneDimensiones(11, 11).Should().BeFalse();
    }

    [Fact]
    public void Si_AgregoUnJugadorConElAliasJugador1_Debe_ExistirUnJugadorConElAliasJugador1()
    {
        var acorazados = new Acorazados(10, 10);

        acorazados.AgregarJugador("jugador 1");

        acorazados.Jugadores[0].Alias.Should().Be("jugador 1");
    }

    [Fact]
    public void Si_JugadorAgregaCanoneroEnLaPosicionX7Y2_Debe_EnTableroEnPosicionX7Y2TenerG()
    {
        var acorozados = new Acorazados(10, 10);
        acorozados.AgregarJugador("jugador 1");

        acorozados.Jugadores[0].AgregarCanonero(7, 2);

        acorozados.ObtenerElemento(7, 2).Should().Be("g");
    }
}