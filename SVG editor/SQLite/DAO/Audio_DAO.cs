using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Geometricamente_V1.Util;
using System.Data;
using System.Data.SQLite;
using System.Windows.Forms;
using Geometricamente_V1.Model;

namespace Geometricamente_V1.DAO
{
    class Audio_DAO
    {
        Conexao cn;
        SQLiteConnection conn = null;
        public Audio_DAO()
        {

            cn = new Conexao();
            conn = cn.conectar();
            MessageBox.Show(conn.State.ToString());

        }

        public SQLiteDataAdapter listarTodos()
        {
            try
            {
                if (conn.State != ConnectionState.Open)
                    conn = cn.conectar();
                string sql = "SELECT id_audio,nome_imagem,narrador,idade,data,nome_arquivo FROM audio";
                DataTable dt = new DataTable();
                SQLiteDataAdapter da = new SQLiteDataAdapter(sql, conn);
                da.Fill(dt);
                return da;
            }
            catch (Exception er)
            {
                MessageBox.Show("Erro ao exibir os registros da tabela Audio !!\n Mais detalhes" + er.Message);
                return null;
            }
            finally
            {
                conn.Close();
            }

        }

        public int inserir(Audio audio)
        {
            int resultado = -1;

            if (conn.State != ConnectionState.Open)
                conn = cn.conectar();

            if (conn.State == ConnectionState.Open)
            {
                SQLiteCommand cmd = new SQLiteCommand(conn);

                cmd.CommandText = "INSERT INTO audio(nome_imagem,narrador,idade,data,nome_arquivo) VALUES (@nome_imagem,@narrador,@idade,@data,@nome_arquivo)";
                cmd.Prepare();
                cmd.Parameters.AddWithValue("@nome_imagem", audio.Nome_imagem);
                cmd.Parameters.AddWithValue("@narrador", audio.Narrador);
                cmd.Parameters.AddWithValue("@idade", audio.Idade);
                cmd.Parameters.AddWithValue("@data", audio.Data);
                cmd.Parameters.AddWithValue("@nome_arquivo", audio.Nome_arquivo);
                
                try
                {
                    resultado = cmd.ExecuteNonQuery();
                }
                catch (SQLiteException ex)
                {
                    throw ex;
                }
                finally
                {
                    conn.Close();
                }
            }

            return resultado;
        }

    }
}
