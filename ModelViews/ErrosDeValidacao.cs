using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace minimal_api.ModelViews
{
    public struct ErrosDeValidacao
    {
        public List<string> Mensagens { get; set; }

        public ErrosDeValidacao()
        {
            Mensagens = new List<string>();
        }
    }
}