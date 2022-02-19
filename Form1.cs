using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace Laboratorio_2_Josué_Robles
{
    public partial class ROGA : Form
    {
        public ROGA()
        {
            InitializeComponent();
        }
        private void BtIr_Click(object sender, EventArgs e)
        {
            String url = null;
            if (comboBox1.Text == null)//Si seleccióno una de las paginas favoritas
            {
                if (comboBox1.SelectedItem != null)
                {
                    url = comboBox1.SelectedItem.ToString();
                    webBrowser1.Navigate(new Uri(url));
                }
            }
            else//Si escribio una dirección
            {
                if (!comboBox1.Text.Contains("."))
                {
                    url = "https://www.google.com/search?q=" + comboBox1.Text.ToString();
                    webBrowser1.Navigate(new Uri(url));
                }
                else if (!comboBox1.Text.Contains("https://"))
                {
                    url = "https://" + comboBox1.Text.ToString();
                    webBrowser1.Navigate(new Uri(url));
                }
                else
                {
                    url = comboBox1.Text.ToString();
                    webBrowser1.Navigate(new Uri(url));
                }
            }

            bool verificador = true;

            for(int i = 0; i < comboBox1.Items.Count; i++)
                if (url == comboBox1.Items[i].ToString())
                    verificador = false;

            if (verificador)
                Guardar("archivo.txt", url);
        }
        private void inicioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            webBrowser1.GoHome();
        }

        private void haciaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            webBrowser1.GoBack();
        }

        private void haciaAdelanteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            webBrowser1.GoForward();
        }

        private void ROGA_Load(object sender, EventArgs e)
        {
            comboBox1.SelectedIndex = 0;
            webBrowser1.GoHome();
            string fileName = @"C:\Users\Usuario\source\repos\Laboratorio_2 Josué Robles\bin\Debug\archivo.txt";
            FileStream stream = new FileStream(fileName, FileMode.Open, FileAccess.Read);
            StreamReader reader = new StreamReader(stream);

            while (reader.Peek() > -1)
            {
                String texto = reader.ReadLine();
                comboBox1.Items.Add(texto);
            }
            reader.Close();
        }

        private void Guardar(string nombreArchvio, string texto)
        {
            FileStream stream = new FileStream(nombreArchvio, FileMode.Append, FileAccess.Write);
            StreamWriter writer = new StreamWriter(stream);
            writer.Write(texto + "\n");
            writer.Close();
        }
    }
}
