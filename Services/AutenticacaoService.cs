using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace minimal_api.Services
{
    public class AutenticacaoService
    {
        public string GerarToken(string email)
        {
            return "";
        }

        public bool AutenticarLogin(string email, string senha)
        {
            if(email == "adm@teste.com.br" && senha == "123456")
                return true;
            else
                return false;
        }
    }
}