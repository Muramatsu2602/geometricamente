using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BD.Util
{
    public class Conexao
    {
        SQLiteConnection conn = null;
        String strConn = @"Data Source=C:\\ICJ_Geometria\\arquivosBD\\geodb.s3db";
        public SQLiteConnection conectar()
        {
            try
            {
                conn = new SQLiteConnection(strConn);
                conn.Open();                
                return conn;
            }
            catch (Exception er)
            {
                throw er;
            }
        }

        public void desconectar()
        {
            try
            {
                conn.Close();
            }
            catch (Exception er)
            {
                throw er;
            }
        }

    }


}
