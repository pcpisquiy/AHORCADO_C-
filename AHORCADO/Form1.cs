using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Reflection;

namespace AHORCADO
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        string palabra_aleatoria = "";
        List<string> Letras_usadas = new List<string>();
        int limite = 0;
        int contador = 0;
  
        private void seleccionar_palabra()
        {
            Random rnd = new Random();
            int numero = rnd.Next(1, 15);
            switch (numero)
            {
                case 1:
                    palabra_aleatoria = "mono";
                    break;
                case 2:
                    palabra_aleatoria = "perro";
                    break;
                case 3:
                    palabra_aleatoria = "pajaro";
                    break;
                case 4:
                    palabra_aleatoria = "minero";
                    break;
                case 5:
                    palabra_aleatoria = "macaco";
                    break;
                case 6:
                    palabra_aleatoria = "mono";
                    break;
                case 7:
                    palabra_aleatoria = "cocina";
                    break;
                case 8:
                    palabra_aleatoria = "cama";
                    break;
                case 9:
                    palabra_aleatoria = "aguja";
                    break;
                case 10:
                    palabra_aleatoria = "cuaderno";
                    break;
                case 11:
                    palabra_aleatoria = "espejo";
                    break;
                case 12:
                    palabra_aleatoria = "piedra";
                    break;
                case 13:
                    palabra_aleatoria = "tierra";
                    break;
                case 14:
                    palabra_aleatoria = "bandera";
                    break;
                case 15:
                    palabra_aleatoria = "baño";
                    break;
            }
            MessageBox.Show(palabra_aleatoria.ToString());
        }
        private void limpiar_mostrar_textbox()
        {
            try
            {
                limite =palabra_aleatoria.Length;
                int sobrante = 8 - limite;
                for (int i = 0; i < limite; i++)
                {
                    string txt_name = "txtletra" + (i).ToString();
                    TextBox pbletra = this.Controls.Find(txt_name, true).FirstOrDefault() as TextBox;
                    pbletra.Clear();
                    pbletra.Show();

                }
                if (sobrante > 0) {
                    for (int i = limite; i < sobrante; i++)
                    {
                        string txt_name = "txtletra" + (i).ToString();
                        TextBox pbletra = this.Controls.Find(txt_name, true).FirstOrDefault() as TextBox;
                        pbletra.Clear();
                        pbletra.Show();

                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("ERROR: {0}", ex.Message);
            }

        }
        public void mostrar_error() {
            switch (contador) {
                case 1:
                    pictureBox1.Visible = true;
                    pictureBox1.Image = Properties.Resources._1;
                    break;
                case 2:
                    pictureBox1.Image = Properties.Resources._2;
                    break;
                case 3:
                    pictureBox1.Image = Properties.Resources._3;
                    break;
                case 4:
                    pictureBox1.Image = Properties.Resources._4;
                    break;
                case 5:
                    pictureBox1.Image = Properties.Resources._5;
                    break;
                case 6:
                    pictureBox1.Image = Properties.Resources._6;
                    break;
                default:
                    MessageBox.Show("PERDIO");
                    txtletra.Enabled = false;
                    var r = MessageBox.Show("Desea Volver a jugar?", "AHORCADO", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (r == DialogResult.Yes) {
                        Iniciar_partida();
                    } else {
                        txtletra.Enabled = false;
                        btnValidar.Enabled = false;
                    }
                    break;
            }
        }
        private void colocar_letra()
        {
            string letra_ingresada = "", letra_palabra = "";
            letra_ingresada = txtletra.Text.ToUpper();
            bool letra_encontrada = false;
            for (int x = 0; x < palabra_aleatoria.Length; x++)
            {
                letra_palabra = palabra_aleatoria[x].ToString().ToUpper();
                if (letra_ingresada == letra_palabra)
                {
                    string txt_name = "txtletra" + (x).ToString();
                    TextBox pbletra = this.Controls.Find(txt_name, true).FirstOrDefault() as TextBox;
                    pbletra.Text = palabra_aleatoria[x].ToString();
                    txtletra.Clear();
                    Letras_usadas.Add(letra_ingresada);
                    letra_encontrada = true;
                    string palabra = "";
                    for (int y = 0; y < limite; y++) {
                        string txt_name_letra = "txtletra" + (y).ToString();
                        TextBox pbletra_colocada = this.Controls.Find(txt_name_letra, true).FirstOrDefault() as TextBox;
                        palabra += pbletra_colocada.Text;
                    }
                    if (palabra == palabra_aleatoria) {

                        MessageBox.Show("Ganaste");
                        var r = MessageBox.Show("Desea Volver a jugar?", "AHORCADO", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        if (r == DialogResult.Yes)
                        {
                            Iniciar_partida();
                        }
                        else
                        {
                            txtletra.Enabled = false;
                            btnValidar.Enabled = false;
                        }
                    }
                }
            }
            if (!letra_encontrada) {
                MessageBox.Show("Letra erronea");
                Letras_usadas.Add(letra_ingresada);
                contador += 1;
                mostrar_error();
                txtletra.Clear();

            }

        }
        private void Iniciar_partida()
        {

            palabra_aleatoria = "";
            seleccionar_palabra();
            limpiar_mostrar_textbox();
            Letras_usadas.Clear();
            txtletra.Enabled = true;
            btnValidar.Enabled = true;

        }
        private void Form1_Load(object sender, EventArgs e)
        {
            Iniciar_partida();
        }

        public bool Letra_usada(string letra)
        {
            bool bandera = false;
            int tamaño = Letras_usadas.ToArray().Length;
            if (tamaño >0)
            {
                foreach (string LETRA_BUSQUEDA in Letras_usadas)
                {
                    if (txtletra.Text.ToUpper() == LETRA_BUSQUEDA) {
                        bandera = true;
                    }
                }
            }
            return bandera;
        }
        public void Ingreso_letra() {
            bool flag = Letra_usada(txtletra.Text);
            if (flag)
            {
                MessageBox.Show("Letra ya usada ingrese otra");
                txtletra.Clear();
            }
            else
            {
                if (this.txtletra.Text.Length >= 2 || this.txtletra.Text.Length == 0)
                {
                    txtletra.Clear();
                    MessageBox.Show("El dato ingresado es invalido, ingrese una sola letra");
                    txtletra.Clear();
                }
                else
                {
                    colocar_letra();
                }
            }
        }
        private void txtletra_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar==Convert.ToChar(13)) {
                Ingreso_letra();
            }
        }

        private void btnValidar_Click(object sender, EventArgs e)
        {
            Ingreso_letra();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Iniciar_partida();
        }
    }
}
