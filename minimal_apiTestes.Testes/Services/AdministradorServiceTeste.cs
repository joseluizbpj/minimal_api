using Microsoft.EntityFrameworkCore;
using minimal_api.Entidades;
using minimal_api.Repositorios;

namespace minimal_apiTestes.Testes.Services
{
    public class AdministradorServiceTeste
    {
        [Fact]
        public void TestarGetSetDePropriedades()
        {
            //Arrange
            var adm = new Administrador
            {
                Id = 1,
                Email = "teste@email.com",
                Senha = "123456",
                Perfil = "Adm"
            };

            using (var contexto = CriarContextoParaTeste())
            {
                //Act
                contexto.Administradores.Add(adm);
                contexto.SaveChanges();

                //Assert
                var admSalvo = contexto.Administradores.Find(1);

                Assert.NotNull(admSalvo);
                Assert.Equal(adm.Email, admSalvo.Email);
                Assert.Equal(adm.Senha, admSalvo.Senha);
                Assert.Equal(adm.Perfil, admSalvo.Perfil);
            }
        }

        private DbContexto CriarContextoParaTeste()
        {
            var options = new DbContextOptionsBuilder<DbContexto>().UseInMemoryDatabase(databaseName: "TestDatabase_" + Guid.NewGuid().ToString()).Options;

            return new DbContexto(options);
        }
    }
}