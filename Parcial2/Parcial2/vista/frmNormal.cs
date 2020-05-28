using System;
using System.Windows.Forms;
using Parcial2.modelo;

namespace Parcial2.vista
{
    public partial class frmNormal : Form
    {
        public frmNormal()
        {
            InitializeComponent();
        }

        private void frmNormal_Load(object sender, EventArgs e)
        {
            try
            {
                var dt = conexion.realizarConsulta(
                    $"SELECT ad.idAddress, ad.address FROM ADDRESS ad WHERE iduser = {usuario.iduser}");

                dataGridView1.DataSource = dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show("ERROR");
            }

            try
            {
                var dt = conexion.realizarConsulta($"SELECT ao.idOrder, ao.createDate, " +
                                                   $"pr.name, au.fullname, ad.address FROM APPORDER ao, " +
                                                   $"ADDRESS ad, PRODUCT pr, APPUSER au WHERE ao.idProduct" +
                                                   $" = pr.idProduct AND ao.idAddress = ad.idAddress AND " +
                                                   $"ad.idUser = au.idUser AND au.idUser = {usuario.iduser};");

                dataGridView2.DataSource = dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show("ERROR");
            }

            poblarControles();
            
        }

         private void poblarControles()
            {
                comboBox1.DataSource = null;
                comboBox1.ValueMember = "idproduct";
                comboBox1.DisplayMember = "name";
                comboBox1.DataSource = productDAO.getLista();
            }
         private void button1_Click(object sender, EventArgs e)
        {
            if (comboBox1.Text.Equals("") ||
                textBox1.Text.Equals(""))
                {
                    MessageBox.Show($"No debe de dejar los campos vacios",
                        "Parcial2", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            else
            {

                try
                {
                    conexion.realizarAccion($"INSERT INTO APPORDER(createDate, idProduct, idAddress) " +
                                            $"VALUES('{DateTime.Today.ToString("d")}'," +
                                            $" {comboBox1.SelectedValue.ToString()}, {textBox1.Text});");

                    MessageBox.Show($"Se ha tomado la orden",
                        "Parcial2", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    frmNormal_Load(sender, e);
                }
                catch (Exception exception)
                {
                    MessageBox.Show($"ERROR");
                }
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (textBox2.Text.Equals(""))
            {
                MessageBox.Show("No debe de dejar los campos vacios",
                    "Parcial2", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {
                try
                {
                    string nonQuery = $"delete from APPORDER "+
                                      $"where idorder='{textBox2.Text}';";
                         
                         
                    conexion.realizarAccion(nonQuery);
                         
                         
                         
                    MessageBox.Show("Se ha cancelado la orden en curso",
                        "Parcial2", MessageBoxButtons.OK, MessageBoxIcon.Information);
                             
                    frmNormal_Load(sender,e);
         
                }
                catch (Exception exception)
                {
                    MessageBox.Show($"ERROR",
                        "Parcial2", MessageBoxButtons.OK, MessageBoxIcon.Error);   
                }
                         
            }

        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (textBox3.Text.Equals(""))
            {
                MessageBox.Show($"No debe de dejar los campos vacios",
                    "Parcial2", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
            
                try
                {
                    conexion.realizarAccion($"INSERT INTO ADDRESS(iduser, address) " +
                                                            $"VALUES({usuario.iduser}, '{textBox3.Text}')");
            
                    MessageBox.Show($"La direccion ha sido agregada",
                        "Parcial2", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    
                    frmNormal_Load(sender,e);
                    
                }
                catch (Exception exception)
                {
                    MessageBox.Show($"ERROR");
                }
            }

        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (textBox4.Text.Equals(""))
            {
                MessageBox.Show("No debe de dejar los campor vacios",
                    "Parcial2", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {
                try
                { 
                    string nonQuery = $"delete from ADDRESS "+
                                    $"where idaddress='{textBox4.Text}';";
                
                
                    conexion.realizarAccion(nonQuery);
                
                
                
                    MessageBox.Show("La direccion ha sido eliminada",
                        "Parcial2", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);   
                    
                    frmNormal_Load(sender,e);
                

                }
                catch (Exception exception)
                {
                    MessageBox.Show($"ERROR",
                        "Parcial2", MessageBoxButtons.OK, MessageBoxIcon.Error);   
                }
            }
        }
    }
}

