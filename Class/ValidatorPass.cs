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

        public string ValidaSenha(string pass)
        {
            VerificaTamanho(pass);
            VerificaTipoCaractere(pass);
            VerificaDicionario(pass);
            VerificaSequencia(pass);
            VerificaDatas(pass);

            int cFraco = 0;
            int cMedia = 0;
            int cForte = 0;

            for (int i = 0; i < Forca.Length; i++)
            {
                if (Forca[i] == ForcaQuesito.Fraca)
                {
                    cFraco++;
                }
                else if (Forca[i] == ForcaQuesito.Média)
                {
                    cMedia++;
                }
                else if (Forca[i] == ForcaQuesito.Forte)
                {
                    cForte++;
                }

            }

            if (cFraco >= cMedia && cFraco >= cForte)
            {
                return "Fraco";
            }
            else if (cMedia >= cFraco && cMedia >= cForte)
            {
                return "Média";
            }
            else if (cForte >= cFraco && cForte >= cMedia)
            {
                return "Forte";
            }
            return "";
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

        private /*async*/ void VerificaDicionario(string password)
        {

            StreamReader sr = new StreamReader(@"~\..\..\..\Assets\dict_passes.csv");
            int cP = 0;
            foreach (var fv in sr.ReadLine())
            {
                if (password.Equals(fv))
                {
                    cP++;
                }
            }
            if (cP == 0)
            {
                Forca[2] = ForcaQuesito.Forte;
            }

            // settings
            // same as (ms-appx:///MyFolder/MyFile.txt)
            /*var _Folder = Windows.ApplicationModel.Package.Current.InstalledLocation;
            _Folder = await _Folder.GetFolderAsync("Assets");

            // acquire file
            var _File = await _Folder.GetFileAsync("dict_passes.csv");
            
            // read content
            var _ReadThis = await Windows.Storage.FileIO.ReadTextAsync(_File);*/

        }

        private void VerificaSequencia(string password)
        {
            int i = 0;
            int j = 0;
            foreach (var letra in password)
            {
                if (i > 0)
                {
                    if(password[i-1].Equals(password[i])){
                        j++;
                    }
                }
                i++;
            }
            if (j > 0)
            {
                Forca[3] = ForcaQuesito.Fraca;
            }
            else
            {
                i = 0;
                j = 0;
                foreach (var letra in password)
                {
                    if (i > 0)
                    {
                        if ((ASCIIEncoding.ASCII.GetBytes(password[i - 1].ToString())[0]+1).Equals(ASCIIEncoding.ASCII.GetBytes(password[i].ToString())[0]))
                        {
                            j++;
                        }
                    }
                    i++;
                }
                if (j > 0)
                {
                    Forca[3] = ForcaQuesito.Fraca;
                }
            }
        }

        private void VerificaDatas(string password)
        {
            CultureInfo provider = new CultureInfo("pt-BR");
            try
            {
                DateTime t;
                DateTime.ParseExact(password, "ddMMyy", provider);
                Forca[4] = ForcaQuesito.Fraca;

                return;
            }
            catch
            {
                System.Diagnostics.EventLog.WriteEntry("teste", "erro processa ddmmyy");
            }

            try
            {
                DateTime t;
                DateTime.ParseExact(password, "ddMMyyyy", provider);
                Forca[4] = ForcaQuesito.Média;
                return;
            }
            catch
            {
                System.Diagnostics.EventLog.WriteEntry("teste", "erro processa ddmmyyyy");
            }
            Forca[4] = ForcaQuesito.Forte;
        }
    }
}
