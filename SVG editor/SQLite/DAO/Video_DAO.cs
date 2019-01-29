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
    class Video_DAO
    {
        Conexao cn;
        SQLiteConnection conn = null;
        public Video_DAO()
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
                string sql = "SELECT id_video,audio_id,artista,idade,data,nome_arquivo FROM video";
                DataTable dt = new DataTable();
                SQLiteDataAdapter da = new SQLiteDataAdapter(sql, conn);
                da.Fill(dt);
                return da;
            }
            catch (Exception er)
            {
                MessageBox.Show("Erro ao exibir os registros da tabela Video !!\n Mais detalhes" + er.Message);
                return null;
            }
            finally
            {
                conn.Close();
            }

        }

        public int inserir(Video video)
        {
            int resultado = -1;

            if (conn.State != ConnectionState.Open)
                conn = cn.conectar();

            if (conn.State == ConnectionState.Open)
            {
                SQLiteCommand cmd = new SQLiteCommand(conn);

                cmd.CommandText = "INSERT INTO video(audio_id,artista,idade,data,nome_arquivo) VALUES (@audio_id,@artista,@idade,@data,@nome_arquivo)";
                cmd.Prepare();
                cmd.Parameters.AddWithValue("@audio_id", video.Audio_id);
                cmd.Parameters.AddWithValue("@artista", video.Artista);
                cmd.Parameters.AddWithValue("@idade", video.Idade);
                cmd.Parameters.AddWithValue("@data", video.Data);
                cmd.Parameters.AddWithValue("@nome_arquivo", video.Nome_arquivo);

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
