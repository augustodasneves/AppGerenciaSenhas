using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppGerenciaSenhas.DAO
{
    class Password
    {
        protected int id;
        protected string sistema;
        protected string usuario;
        protected string senhacriptografada;

        Password(int id,string sistema,string usuario,string senhacriptografada)
        {
            this.id = id;
            this.sistema = sistema;
            this.usuario = usuario;
            this.senhacriptografada = senhacriptografada;
        }
    }
}
