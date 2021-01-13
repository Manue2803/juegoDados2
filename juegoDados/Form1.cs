using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace juegoDados
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        public void Sonido(String NombreSonido)
        {
            var sonido = (Stream) Properties.Resources.ResourceManager.GetObject(NombreSonido);
            SoundPlayer SonidoCargado = new SoundPlayer(sonido);
            SonidoCargado.Play();
        }

        public void IniciarJuego()
        {
            pictureBox1.Image = (Bitmap)Properties.Resources.ResourceManager.GetObject(1.ToString());
            button1.Visible = true;
            button2.Visible = false;
            Sonido("readygo");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            timer1.Enabled = true;
            timer1.Start();
            button1.Visible = false;
            button2.Visible = true;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            IniciarJuego();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            Random rnd = new Random();
            int dado = rnd.Next(1, 7);
            pictureBox1.Image = (Bitmap)Properties.Resources.ResourceManager.GetObject(dado.ToString());
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Random rnd = new Random();
            timer1.Stop();
            button1.Visible = true;
            button2.Visible = false;
            int dado = rnd.Next(1, 7);
            pictureBox1.Image = (Bitmap)Properties.Resources.ResourceManager.GetObject(dado.ToString());
        }
    }
}
