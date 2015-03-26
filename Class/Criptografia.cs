using AppGerenciaSenhas.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;
using Windows.Security.Cryptography.Core;

namespace AppGerenciaSenhas.Class
{
    class Criptografia:ICifra
    {
        protected HashAlgorithmProvider cifrado;
        public byte[] Encripta(Algoritmo NomeAlgoritmo, byte[] IV, byte[] cifra)
        {
            switch (NomeAlgoritmo)
            {
                case Algoritmo.MD5:
                    cifrado=HashAlgorithmProvider.OpenAlgorithm(HashAlgorithmNames.Md5);
                    break;
                case Algoritmo.SHA1:
                    cifrado = HashAlgorithmProvider.OpenAlgorithm(HashAlgorithmNames.Sha1);
                    break;
                case Algoritmo.SHA256:
                    cifrado = HashAlgorithmProvider.OpenAlgorithm(HashAlgorithmNames.Sha256);
                    break;
                case Algoritmo.SHA384:
                    cifrado = HashAlgorithmProvider.OpenAlgorithm(HashAlgorithmNames.Sha384);
                    break;
                case Algoritmo.AES:
                    
                    
                    break;
                default:
                    break;
            }  
            byte[] tt = new byte[10];
            return tt;
        }

        public byte[] Decripta(Algoritmo NomeAlgoritmo, byte[] IV, byte[] cifra)
        {
            byte[] tt = new byte[10];
            return tt;
        }
    }
}
