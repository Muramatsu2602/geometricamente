using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Geometricamente_V1.Model
{
    class Video
    {
        private int id_video;
        private int audio_id;
        private string artista;
        private int idade;
        private string data;
        private string nome_arquivo;

        public int Id_video { get => id_video; set => id_video = value; }
        public int Audio_id { get => audio_id; set => audio_id = value; }
        public string Artista { get => artista; set => artista = value; }
        public int Idade { get => idade; set => idade = value; }
        public string Data { get => data; set => data = value; }
        public string Nome_arquivo { get => nome_arquivo; set => nome_arquivo = value; }
    }
}
