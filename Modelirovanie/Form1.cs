using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace Modelirovanie
{
    public partial class Form1 : Form
    {
        Colculator calc = new Colculator();
        //string template = "4*(5+4)-14-sin(6+235)+(3*ctg(4-3))";
        public Form1()
        {
            InitializeComponent();
            //textBox1.Text = template;
        }
        private void valueButton_Click(object sender, EventArgs e) {
            Button numberButton = (Button)sender;
            textBox1.Text += numberButton.Text;
        }
        private void button22_Click(object sender, EventArgs e)//ввод
        {
            if (checkBox1.Checked) 
                calc.Enumeration(textBox1.Text,false);//
            else
                calc.Enumeration(textBox1.Text, true);
            textBox3.Text = calc.getStroka();
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void button23_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
            textBox3.Clear();
        }

        private void button21_Click(object sender, EventArgs e)
        {
            
           
        }

        private void groupBox5_Enter(object sender, EventArgs e)
        {

        }
    }
}
