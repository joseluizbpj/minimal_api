using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace minimal_api.ModelViews
{
    public struct Home
    {
        public string Documentacao { get => "/swagger"; }
        public string Mensagem { get => "Bem vindo à API de veículos"; }    
    }
}