using minimal_api.DTOs;
using minimal_api.Entidades;

namespace minimal_api.Interfaces
{
    public interface IAdministradorService
    {
        Administrador? Login(LoginDTO loginDTO);
        Administrador Incluir(Administrador administrador);
        List<Administrador> Todos(int? pagina);
    }
}
