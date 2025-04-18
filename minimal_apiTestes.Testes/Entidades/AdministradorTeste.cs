using minimal_api.Entidades;

namespace minimal_apiTestes.Testes.Entidades;

public class AdministradorTeste
{
    [Fact]
    public void TestarGetSetDePropriedades()
    {
        //Arrange
        var adm = new Administrador();

        //Act
        adm.Id = 1;
        adm.Email = "teste@email.com";
        adm.Senha = "123456";
        adm.Perfil = "Adm";

        //Assert
        Assert.Equal(1, adm.Id);
        Assert.Equal("teste@email.com", adm.Email);
        Assert.Equal("123456", adm.Senha);
        Assert.Equal("Adm", adm.Perfil);
    }
}
