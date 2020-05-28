using System;
using System.Windows.Forms;
using Parcial2.modelo;
using Parcial2.controls;


namespace Parcial2.vista
{
    public partial class ActContra : Form
    {


        private void frmActualizarContra_Load(object sender, EventArgs e)
        {
            comboBox1.DataSource = null;
            comboBox1.ValueMember = "contraseña";
            comboBox1.DisplayMember = "user";
            comboBox1.DataSource = UsuarioDAO.getLista();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            bool actualIgual = comboBox1.SelectedValue.Equals(textBox1.Text);
            bool nuevaIgual = textBox2.Text.Equals(textBox3.Text);
            bool nuevaValida = textBox2.Text.Length > 0;

            if (actualIgual && nuevaIgual && nuevaValida)
            {
                try
                {
                    UsuarioDAO.actContra(comboBox1.Text, encriptador.CrearMD5(textBox2.Text));
                    
                    MessageBox.Show("¡Su contraseña ha sido actualizada!", 
                        "Parcial2", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    
                    this.Close();
                }
                catch (Exception)
                {
                    MessageBox.Show($"¡ERROR! contraseña no actualizada, intentar otra vez", 
                        "Parcial2", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
                MessageBox.Show("Revisar los datos sean corretos", 
                "Parcial2", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}