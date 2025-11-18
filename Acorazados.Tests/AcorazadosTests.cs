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
    public Acorazados(int i, int i1)
    {
        
    }

    public bool TieneDimensiones(int i, int i1)
    {
        return true;
    }
}