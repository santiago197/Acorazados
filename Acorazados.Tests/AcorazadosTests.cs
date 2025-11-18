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
}

public class Acorazados
{
    public Acorazados(int x, int y)
    {
        
    }

    public bool TieneDimensiones(int x, int y)
    {
        return true;
    }
}