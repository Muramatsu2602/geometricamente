using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace Geometricamente_V1
{
    public partial class frmEscolhePasta : Form
    {
        String[] dados = new string[100];
        public frmEscolhePasta(String[] dados)
        {
            InitializeComponent();
            this.dados = dados;
        }
        FolderBrowserDialog fbd1 = new FolderBrowserDialog();
        private void btnSelecionarPasta_Click(object sender, EventArgs e)
        {
            try
            {
                //Define as propriedades do controle FolderBrowserDialog
                fbd1.Description = "Selecione uma pasta exibir as imagens";
                //fbd1.RootFolder = Environment.SpecialFolder.Desktop;
                fbd1.ShowNewFolderButton = true;

                //Exibe a caixa de diálogo
                if (fbd1.ShowDialog() == DialogResult.OK)
                {
                    //Exibe a pasta selecionada
                    txtDiretorio.Text = fbd1.SelectedPath;
                }
                ExibeArquivosDaPastaSelecionada(fbd1.SelectedPath);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void ExibeArquivosDaPastaSelecionada(string pasta)
        {
            String pastaOrigem = pasta;
            var filtros = new String[] { "jpg", "jpeg", "png", "gif", "tiff", "bmp" };
            var arquivos = GetArquivosDaPasta(pastaOrigem, filtros, false);
            int l = 0;
            int c = 0;
            for (int i = 0; i < arquivos.Length; i++)
            {
                FileInfo arquivo = new FileInfo(arquivos[i]);
                // quero enviar o nome da imagem no array dados, slot 3
                string caminhoImagem = fbd1.SelectedPath + "\\" + arquivo.Name;
                PictureBox picture = new PictureBox
                {
                    Name = "pictureBox" + i,
                    BackColor = Color.Black,
                    Size = new Size(200, 200),
                    SizeMode = PictureBoxSizeMode.StretchImage,
                    Location = new Point(c, l),
                    Image = Image.FromFile(caminhoImagem)
                };
                panel3.Controls.Add(picture);

                // aqui vai ir o nome da imagem
                //this.dados[2] = arquivo.Name;

                picture.Click += new EventHandler(AbreForm);
               
                if (c > (panel3.Size.Width - 210))
                {
                    l = l + 210;
                    c = 0;
                }
                else
                {
                    c += 210;
                }
            }
        }
        public void AbreForm(object sender, EventArgs e)
        {
            var box = (PictureBox)sender;
            frmGravaDescricao f2 = new frmGravaDescricao( box.Image, dados); // aqui o
            f2.Show();
        }

        public static string[] GetArquivosDaPasta(String pastaRaiz, String[] filtros, bool isRecursiva)
        {
            List<String> arquivosEncontrados = new List<String>();
            SearchOption opcaoDeBusca = isRecursiva ? SearchOption.AllDirectories : SearchOption.TopDirectoryOnly;
            foreach (var filtro in filtros)
            {
                arquivosEncontrados.AddRange(Directory.GetFiles(pastaRaiz, String.Format("*.{0}", filtro), opcaoDeBusca));
            }
            return arquivosEncontrados.ToArray();
        }
                
        private void button1_Click(object sender, EventArgs e)
        {
            for (int i = Application.OpenForms.Count - 1; i >= 0; i--)
            {
                if (Application.OpenForms[i].Name != "Form1")
                    Application.OpenForms[i].Close();

            }
            this.Close();
        }

    }
}
