using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite.WinRT;

namespace AppGerenciaSenhas
{
    class clsDB
    {
        SQLiteConnection connBanco;
        public clsDB()
        {
            
        }

        public SQLiteConnection conecta()
        {
            if(connBanco == null){
                connBanco = new SQLiteConnection(new SQLiteConnectionString("~/Data/banco.sqlite", false));
                return connBanco;
            }
            else
            {
                return connBanco;
            }
        }

        public int InsereDados(string tabela,string[] valores)
        {
            string CommandText = String.Format("INSERT INTO {0} VALUES({1})",tabela,String.Join(",",valores));
            SQLiteCommand scm=conecta().CreateCommand(CommandText);
            return scm.ExecuteNonQuery();
        }

        public int buscaDados(string tabela, string[] campos)
        {
            string CommandText = String.Format("SELECT {0} FROM {1}", String.Join(",",campos),tabela);
            SQLiteCommand scm = conecta().CreateCommand(CommandText);
            return scm.ExecuteNonQuery();
        }

        public int deletaDados(string tabela, string condicao,string valorcondicao)
        {
            string CommandText = String.Format("DELETE FROM {0} WHERE {1} = {2}", tabela,condicao,valorcondicao);
            SQLiteCommand scm = conecta().CreateCommand(CommandText);
            return scm.ExecuteNonQuery();
        }
    }
}
