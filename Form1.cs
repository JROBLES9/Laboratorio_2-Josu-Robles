using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

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
            if (comboBox1.Text == null)//Si seleccióno una de las paginas favoritas
            {
                if (comboBox1.SelectedItem != null)
                    webBrowser1.Navigate(new Uri(comboBox1.SelectedItem.ToString()));
            }
            else//Si escribio una dirección
            {
                if (!comboBox1.Text.Contains("."))
                    webBrowser1.Navigate(new Uri("https://www.google.com/search?q=" + comboBox1.Text.ToString()));
                else if (!comboBox1.Text.Contains("https://"))
                    webBrowser1.Navigate(new Uri("https://" + comboBox1.Text.ToString()));
                else
                    webBrowser1.Navigate(new Uri(comboBox1.Text.ToString()));
            }
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
        }
    }
}
