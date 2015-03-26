using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppGerenciaSenhas.Security
{
    enum Algoritmo
    {
        MD5,
        SHA1,
        SHA256,
        SHA384,
        AES
    }
    interface ICifra
    {
        byte[] Encripta(Algoritmo NomeAlgoritmo, byte[] IV, byte[] cifra);
        byte[] Decripta(Algoritmo NomeAlgoritmo, byte[] IV, byte[] cifra);
    }
}
