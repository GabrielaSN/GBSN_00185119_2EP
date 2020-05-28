using System;
using System.Windows.Forms;
using Parcial2.modelo;

namespace Parcial2.vista
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void poblarControles()
        {
            // Actualizar ComboBox
            comboBox1.DataSource = null;
            comboBox1.ValueMember = "passw";
            comboBox1.DisplayMember = "username";
            comboBox1.DataSource = UsuarioDAO.getLista();
        }

        private void Login_Load(object sender, EventArgs e)
        {
            poblarControles();
        }

        private void button1_Click(object sender, EventArgs e)
        {
                ActContra unaVentana = new ActContra();
                unaVentana.ShowDialog();
                poblarControles();
           
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (comboBox1.SelectedValue.Equals(textBox1.Text))
            {
                usuario user = (usuario) comboBox1.SelectedItem;
                MessageBox.Show("¡Bienvenido usuario!", 
                    "Parcial2", MessageBoxButtons.OK, MessageBoxIcon.Information);
                if (user.usertype.Equals(true))
                {
                    var ventana = new principal();
                    ventana.Show();
                    this.Hide();
                }
                else if(user.usertype.Equals(false))
                {
                    var ventana = new frmNormal();
                    ventana.Show();
                    this.Hide();
                }

            }
            else
                MessageBox.Show("¡Contraseña equivocada, intenta de nuevo!", "parcial2",
                    MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            
        }
    }
}