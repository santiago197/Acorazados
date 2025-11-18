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
    public void Si_AgregoUnJugador_Debe_SerIgualAJugador1()
    {
        var acorazados = new Acorazados(10, 10);
        
        acorazados.AgregarJugador("jugador 1");
        
        acorazados.Jugadores.Should().Be("jugador 1");
    }
}

public class Acorazados
{
    private string[,] _tablero;

    public Acorazados(int x, int y)
    {
        _tablero = new string[x, y];
    }

    public string Jugadores { get; set; }

    public bool TieneDimensiones(int x, int y)
    {
        return EsCantidadFilasIgualA(x) && EsCantidadColumnasIgualA(y);
    }

    private bool EsCantidadColumnasIgualA(int y)
    {
        return _tablero.GetLength(1) == y;
    }

    private bool EsCantidadFilasIgualA(int x)
    {
        return _tablero.GetLength(0) == x;
    }

    public void AgregarJugador(string jugador)
    {
        throw new NotImplementedException();
    }
}