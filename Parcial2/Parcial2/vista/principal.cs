using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;
using Parcial2.modelo;

namespace Parcial2.vista
{
    public partial class principal : Form
    {
        public principal()
        {
            InitializeComponent();
        }
        private void principal_Load(object sender, EventArgs e)
        {
            try
            {
                var dt = conexion.realizarConsulta("SELECT * FROM BUSINNES");
            
                dataGridView3.DataSource = dt;
            }
            catch (Exception ex)
            { 
                MessageBox.Show("ERROR");  
            }
                        
            try
            {
                var dt = conexion.realizarConsulta("SELECT * FROM APPUSER");
            
                dataGridView1.DataSource = dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show("ERROR");
            }
            
            try
            {
                var dt = conexion.realizarConsulta("SELECT * FROM PRODUCT");
            
                dataGridView2.DataSource = dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show("ERROR");
            }
                        
            try
            {
                var dt = conexion.realizarConsulta("SELECT * FROM APPORDER");
            
                dataGridView4.DataSource = dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show("ERROR");
            }
                        
            var usu = conexion.realizarConsulta("SELECT username FROM APPUSER ");
            var userCombo = new List<string>();
            
            foreach (DataRow dr in usu.Rows)
            {
                userCombo.Add(dr[0].ToString());
                
            }
                        
            comboBox2.DataSource = userCombo;
            
        }
        
        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox2.Text.Equals("") ||
                textBox3.Text.Equals(""))
            {
                MessageBox.Show($"No debe de dejar los campos vacios!",
                                "Parcial2", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                           
                try
                {
                    conexion.realizarAccion($"INSERT INTO BUSINESS(name, description) " +
                                            $"VALUES('{textBox3.Text}', '{textBox2.Text}')");
            
                    MessageBox.Show($"el negocio fue agregado",
                        "Parcial2", MessageBoxButtons.OK, MessageBoxIcon.Information);
            
                    principal_Load(sender, e);
            
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
                MessageBox.Show("No debe de dejar los campos vacios",
                    "Parcial2", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {
                try
                {
                    string nonQuery = $"delete from BUSINESS "+
                                      $"where idbusiness='{textBox4.Text}';";
                            
                            
                    conexion.realizarAccion(nonQuery);
                            
                            
                            
                    MessageBox.Show("Se ha eliminado",
                        "Parcial2", MessageBoxButtons.OK, MessageBoxIcon.Information);   
                            
                    principal_Load(sender,e);
            
                }
                catch (Exception exception)
                {
                    MessageBox.Show($"ERROR",
                        "Parcial2", MessageBoxButtons.OK, MessageBoxIcon.Error);   
                }
                            
            }
        }
        
        private void button2_Click(object sender, EventArgs e)
        {
            if (textBox5.Text.Equals("") ||
                textBox6.Text.Equals("") ||
                comboBox1.Text.Equals(""))
            {
                MessageBox.Show($"No debe de dejar los campos vacios",
                    "Parcial2", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                bool encontrado = false;
                foreach (usuario u in UsuarioDAO.getLista())
                {
                    if (u.user.Equals(textBox5.Text))
                    {
                        encontrado = true;
                    }
                }
            
                if (!encontrado)
                {
                    try
                    {
                        conexion.realizarAccion($"INSERT INTO APPUSER(fullname, username, password, usertype) " +
                                                $"VALUES('{textBox6.Text}', '{textBox5.Text}', '{textBox5.Text}', " +
                                                $"{comboBox1.Text})");
            
                        MessageBox.Show($"Se ha agregado un usuario nuevo",
                            "Parcial2", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            
            
            
            
                        principal_Load(sender, e);
            
                    }
                    catch (Exception exception)
                    {
                        MessageBox.Show($"ERROR");
                    }
                }
                else
                {
                    MessageBox.Show($"Ya existe",
                        "Parcial2", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (comboBox2.Text.Equals(""))
            {
                MessageBox.Show("No debe de dejar los campos vacios!",
                    "Parcial2", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {
                try
                {
                    string nonQuery = $"delete from APPUSER "+
                                      $"where username='{comboBox2.Text}';";
                
                
                    conexion.realizarAccion(nonQuery);
                
                
                
                    MessageBox.Show("Se ha eliminado el usuario",
                        "Parcial2", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);   
                
                    principal_Load(sender,e);

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
            if (textBox7.Text.Equals("") ||
                textBox1.Text.Equals(""))
            {
                MessageBox.Show($"No debe de dejar los campos vacios",
                    "Parcial2", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            { 
                try
                {
                    conexion.realizarAccion($"INSERT INTO PRODUCT(idbusiness, name) " +
                                            $"VALUES('{textBox7.Text}', '{textBox1.Text}')");
            
                    MessageBox.Show($"Nuevo Producto en Inventario",
                        "Parcial2", MessageBoxButtons.OK, MessageBoxIcon.Information);
            
                    principal_Load(sender, e);
            
                }
                catch (Exception exception)
                {
                    MessageBox.Show($"ERROR");
                }
            }   

        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (textBox8.Text.Equals(""))
            {
                MessageBox.Show("No debe de dejar los campos vacios",
                    "Parcial2", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {
                try
                {
                    string nonQuery = $"delete from PRODUCT "+
                                      $"where idproduct='{textBox8.Text}';";
                           
                           
                    conexion.realizarAccion(nonQuery);
                           
                           
                           
                    MessageBox.Show("Se ha eliminado un producto",
                        "Parcial2", MessageBoxButtons.OK, MessageBoxIcon.Information);   
                           
                    principal_Load(sender,e);
           
                }
                catch (Exception exception)
                {
                    MessageBox.Show($"ERROR",
                        "Parcial2", MessageBoxButtons.OK, MessageBoxIcon.Error);   
                }
                           
            }        
        }
        
        
        private void principal_FormClosed_1(object sender, FormClosedEventArgs e)
        {
           Application.Exit(); 
        }

        private void principal_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }
    }
}

    

