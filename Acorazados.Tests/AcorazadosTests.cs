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

        acorazados.AgregarJugador("jugador 1");

        acorazados.Jugadores[0].Alias.Should().Be("jugador 1");
    }

    [Fact]
    public void Si_JugadorAgregaCanoneroEnLaPosicionFila2Columna7_Debe_EnTableroEnPosicionX7Y2TenerG()
    {
        var acorozados = new Acorazados(10, 10);
        acorozados.AgregarJugador("jugador 1");

        acorozados.Jugadores[0].AgregarCanonero(2, 7);

        acorozados.ObtenerElemento(2, 7).Should().Be("g");
    }
    
}