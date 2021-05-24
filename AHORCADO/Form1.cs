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
        private void msgbox(string mensaje, MessageBoxButtons btns_stile, MessageBoxIcon icons) {
            MessageBox.Show(mensaje,"AHORCADO",btns_stile,icons);

        }
        private void seleccionar_palabra() {
            Random rnd = new Random();
            int numero = rnd.Next(1,15);
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
                case  9:
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
        private void limpiar_mostrar_textbox() {
            try {

                foreach (TextBox txtbox in this.Controls)
                {
                    if (txtbox is TextBox && txtbox != txtletra)
                    {
                        txtbox.Clear();
                        txtbox.Hide();
                    }
                }
                int limite = palabra_aleatoria.Length;
                for (int i = 1; i <= limite; i++)
                {
                    string txt_name = "txtletra" + i.ToString();
                    TextBox pbletra = this.Controls.Find(txt_name,true).FirstOrDefault() as TextBox;
                    pbletra.Show();

                }
            } catch (Exception ex) {
                MessageBox.Show("ERROR: {0}", ex.Message);
            }

        }
        private void colocar_letra() {
            for (int x = 0; x < palabra_aleatoria.Length; x++) {

                if (txtletra.Text.ToUpper() == palabra_aleatoria[x].ToString().ToUpper()) {
                    string txt_name = "txtletra" + (x + 1).ToString();
                    TextBox pbletra = this.Controls.Find(txt_name, true).FirstOrDefault() as TextBox;
                    pbletra.Text = palabra_aleatoria[x].ToString();
                    txtletra.Clear();
                }
            }

        }
        private void Iniciar_partida() {

            msgbox("BIENVENIDO, DEBE INGRESAR LAS LETRAS",MessageBoxButtons.OK,MessageBoxIcon.Information);
            palabra_aleatoria = "";
            seleccionar_palabra();
            limpiar_mostrar_textbox();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            Iniciar_partida();
        }

        private void txtletra_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (this.txtletra.Text.Length > 1 )
            {
                txtletra.Clear();
                MessageBox.Show("El dato ingresado es invalido, ingrese una sola letra");
                txtletra.Clear();
            }
            else {
                colocar_letra();
            }
        }
    }
}
