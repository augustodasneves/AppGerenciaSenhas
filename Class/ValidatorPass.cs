using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using Microsoft.VisualBasic;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace AppGerenciaSenhas.Class
{
    enum ForcaQuesito
    {
        Fraca,
        Média,
        Forte,
    }
    class ValidatorPass
    {
        protected ForcaQuesito[] Forca = new ForcaQuesito[5];

        public void ValidaSenha(string pass){
            VerificaTamanho(pass);
            VerificaTipoCaractere(pass);
            VerificaDicionario(pass);
            VerificaSequencia(pass);
            VerificaDatas(pass);

        }
        private void VerificaTamanho(string password)
        {
            if (password.Length <= 3)
            {
                Forca[0] = ForcaQuesito.Fraca;
            }
            else if (password.Length > 3 && password.Length <= 8)
            {
                Forca[0] = ForcaQuesito.Média;
            }
            else
            {
                Forca[0] = ForcaQuesito.Forte;
            }
        }

        private void VerificaTipoCaractere(string password)
        {
            int val = 0;
             //MINUSCULA
            if (Regex.Match(password, @"[a-z]").Success)
            {
                val += 1;
            }

            //MAIUSCULA
            if (Regex.Match(password, @"[A-Z]").Success)
            {
                val += 1;
            }

            //NUMERO
            if (Regex.Match(password, @"\d").Success)
            {
                val += 1;
            }

            //CARACTERES ESPECIAIS
            if (Regex.Match(password, @"[!#$%&'()*+,-./:;?@[\\\]_`{|}~]").Success)
            {
                val += 1;
            }

            if (val == 4)
            {
                Forca[1] = ForcaQuesito.Forte;
            }
            else
            {
                Forca[1] = ForcaQuesito.Fraca;
            }
        }

        private async void VerificaDicionario(string password)
        {
            // settings
            // same as (ms-appx:///MyFolder/MyFile.txt)
            var _Folder = Windows.ApplicationModel.Package.Current.InstalledLocation;
            _Folder = await _Folder.GetFolderAsync("Assets");

            // acquire file
            var _File = await _Folder.GetFileAsync("dict_passes.csv");
            
            // read content
            var _ReadThis = await Windows.Storage.FileIO.ReadTextAsync(_File);

        }

        private void VerificaSequencia(string password)
        {
            
        }

        private void VerificaDatas(string password)
        {
            CultureInfo provider=CultureInfo.InvariantCulture;
            try{
                DateTime t;
                DateTime.ParseExact(password, "ddmmaaaa", provider);
                Forca[4]=ForcaQuesito.Fraca;
                
                return;
            }
            finally { }
            try{
                DateTime t;
                DateTime.ParseExact(password,"ddmmaa",provider);
                Forca[4]=ForcaQuesito.Média;
                return;
            }
            finally {  }
            Forca[4] = ForcaQuesito.Forte;               
        }
    }
}
