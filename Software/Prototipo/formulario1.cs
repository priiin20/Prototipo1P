using formulario1.clases;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Odbc;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace formulario1
{
    public partial class Form1 : Form
    {

        OdbcDataAdapter datos;
        DataTable dt;

        Conexion cn = new Conexion();
        public Form1()
        {
            InitializeComponent();
            CargarDatos();
        }


        private bool insertarProducto()
        {
            try
            {
                string cadena = "INSERT INTO producto (Nombre,precio,cantidad, descripcion) VALUES ('" +textBox1.Text+ "','" +textBox2.Text+ "','" +textBox3.Text+ "','" +textBox4.Text+"');";
                OdbcCommand consulta = new OdbcCommand(cadena, cn.conexion());
                consulta.ExecuteNonQuery();
                consulta.Connection.Close();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                MessageBox.Show("Error al guardar Datos", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                borraDatos();
                CargarDatos();
                return false;
            }
        }

        void borraDatos()
        {
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
        }

        private void button1_Click(object sender, EventArgs e)
        {

            if (insertarProducto() == true)
            {
                borraDatos();
                MessageBox.Show("Datos Correctamente Guardados", "Guardar", MessageBoxButtons.OK, MessageBoxIcon.Information);
                CargarDatos();
            }
            else
            {
                MessageBox.Show("Datos No se pudieron guardar intentelo de nuevo", "Guardar", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

        }

        void CargarDatos()
        {
            try
            {
                string cadena = "SELECT id_producto, Nombre, precio, cantidad, descripcion FROM producto";
                datos = new OdbcDataAdapter(cadena, cn.conexion());
                dt = new DataTable();
                datos.Fill(dt);
                dataGridView1.DataSource = dt;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                MessageBox.Show("Error al cargar datos", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        string sCadena;
        int iID;
        int iIDEliminar;

        private void dataGridView1_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                
                    if (dataGridView1.CurrentRow != null)
                    {
                        string cadena = "UPDATE video SET id_producto ='" + int.Parse(dataGridView1.Rows[e.RowIndex].Cells["id_producto"].Value.ToString()) + "', Nombre='" + dataGridView1.Rows[e.RowIndex].Cells["Nombre"].Value.ToString() +
                            "',precio='" + dataGridView1.Rows[e.RowIndex].Cells["precio"].Value.ToString() + "', cantidad='" + dataGridView1.Rows[e.RowIndex].Cells["cantidad"].Value.ToString() +
                            "',descripcion='" + dataGridView1.Rows[e.RowIndex].Cells["descripcion"].Value.ToString() + "' WHERE id_producto='" + iID + "';";
                        datos = new OdbcDataAdapter(cadena, cn.conexion());
                        dt = new DataTable();
                        datos.Fill(dt);
                        dataGridView1.DataSource = dt;
                        MessageBox.Show("Datos Correctamente Actualizados", "Actualizacion/Modificacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        CargarDatos();
                    }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                MessageBox.Show("Error al guardar Datos", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void button3_Click(object sender, EventArgs e)
        {
            Help.ShowHelp(this, "Ayudas/AyudaVenta.chm", "Venta.html");
        }
    }
}
