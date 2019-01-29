using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BD.Model
{
    public class Audio
    {
        private int id_audio;
        private string nome_imagem;
        private string narrador;
        private int idade;
        private string data;
        private string nome_arquivo;

        public int Id_audio { get => id_audio; set => id_audio = value; }
        public string Nome_imagem { get => nome_imagem; set => nome_imagem = value; }
        public string Narrador { get => narrador; set => narrador = value; }
        public int Idade { get => idade; set => idade = value; }
        public string Data { get => data; set => data = value; }
        public string Nome_arquivo { get => nome_arquivo; set => nome_arquivo = value; }
    }
}
