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

        acorozados.ObtenerElemento(jugador1, 2, 7).Should().Be("g");
    }

    [Fact]
    public void Si_JugadorAgregaDestroyerEnLaFila3Columna2YOrientacionHorizontal_Debe_TableroOcuparDesde32A34_TenerD()
    {
        var acorazados = new Acorazados(10, 10);
        var jugador1 = "jugador 1";
        acorazados.AgregarJugador(jugador1);
        
        acorazados.Jugadores[jugador1].AgregarDestroyer(3, 2, "horizontal");
        
        acorazados.ObtenerElemento(jugador1,3, 2).Should().Be("d");
        acorazados.ObtenerElemento(jugador1, 3, 3).Should().Be("d");
        acorazados.ObtenerElemento(jugador1, 3, 4).Should().Be("d");
    }
    
}