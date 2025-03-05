using minimal_api.DTOs;
using minimal_api.Services;

namespace minimal_api.Endpoints
{
    public static class AutenticacaoEndpoint
    {
        public static void MapAutenticacaoEndpoint(this WebApplication app)
        {   
            app.MapPost("/login", (LoginDTO login) =>
            {
                var aunt = new AutenticacaoService();
                aunt.AutenticarLogin(login.Email, login.Senha);
            });
        }
    }   
}