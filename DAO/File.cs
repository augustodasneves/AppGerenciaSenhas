using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppGerenciaSenhas.DAO
{
    class File 
    {
        protected string filename; 
        protected string path;
        protected float filesize;

        File(string filename,string path,float filesize)
        {
            this.filename = filename;
            this.path = path;
            this.filesize = filesize;
        }
        
        public void salvar()
        {

        }
    }
}
