using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Ejercicio1.Models;

namespace Ejercicio1
{
    public partial class Form1 : Form
    {
        List<Vehiculo> lista=new List<Vehiculo>();
        public Form1()
        {
            InitializeComponent();
        }

        private void btnListar_Click(object sender, EventArgs e)
        {
            string path = "C:\\Users\\Alumno\\source\\repos\\tup_prog_2_2025_actividad8\\Guia8\\Ejercicio1\\bin\\Debug\\Vehiculos.csv";
            string[] lineas = File.ReadAllLines(path);


            foreach (string line in lineas)
            {
                string[] s = line.Split(';');
                txtMostrar.Text += s[0] + " " + s[1] + "\r\n";
            }
            OpenFileDialog ofd=new OpenFileDialog();
            ofd.Filter = "Archivo CSV|*.csv|todos los " +
                "archivos|*.*";
            if (ofd.ShowDialog()==DialogResult.OK)
            {
                string name = ofd.FileName;
                FileStream fs = null;
                StreamReader sr = null;

                try
                {
                    fs = new FileStream(name,
                       FileMode.Open, FileAccess.Read);

                    sr = new StreamReader(fs);


                    sr.ReadLine();
                    while (sr.EndOfStream != true)
                    {
                        string cadena = sr.ReadLine().Trim();
                        string[] separator = cadena.Split(';');

                        string patente = separator[0];
                        double importe = Convert.ToDouble(separator[1]);

                        Vehiculo vehiculo = new Vehiculo(patente, importe);
                        lista.Add(vehiculo);

                    }
                }
                catch
                {

                    MessageBox.ShowDialog("Error");
                    MessageBox.Text
                    
                }
                finally
                {

                }

                foreach (Vehiculo v in lista)
                {
                    txtMostrar.Text = v.ToString();
                }

            }
        }
    }
}
