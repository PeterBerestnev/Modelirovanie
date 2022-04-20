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
        }
        private void valueButton_Click(object sender, EventArgs e) {
            Button numberButton = (Button)sender;
            textBox1.Text += numberButton.Text;
        }
        private void setDefaultColor()
        {
            label11.ForeColor = Color.Black;
            label12.ForeColor = Color.Black;
            label13.ForeColor = Color.Black;
            label14.ForeColor = Color.Black;
            label15.ForeColor = Color.Black;
            label16.ForeColor = Color.Black;
            label17.ForeColor = Color.Black;
            label18.ForeColor = Color.Black;
            label19.ForeColor = Color.Black;
            label20.ForeColor = Color.Black;
            label21.ForeColor = Color.Black;
            label22.ForeColor = Color.Black;
            label23.ForeColor = Color.Black;
            label24.ForeColor = Color.Black;
            label25.ForeColor = Color.Black;
        }
        private void button22_Click(object sender, EventArgs e)//ввод
        {
            if (checkBox1.Checked)
            {
                if (!calc.isEnd())
                {
                    calc.GeneralForm(textBox1.Text, true);//
                    switch (calc.getPntr())
                    {
                        case 0:
                            textBox116.Text = calc.PeekStack() + "";
                            setDefaultColor();
                            label25.ForeColor = Color.Red;
                            break;
                        case 1:
                            textBox115.Text = calc.PeekStack() + "";
                            setDefaultColor();
                            label24.ForeColor = Color.Red;
                            break;
                        case 2:
                            textBox114.Text = calc.PeekStack() + "";
                            setDefaultColor();
                            label23.ForeColor = Color.Red;
                            break;
                        case 3:
                            textBox113.Text = calc.PeekStack() + "";
                            setDefaultColor();
                            label22.ForeColor = Color.Red;
                            break;
                        case 4:
                            textBox112.Text = calc.PeekStack() + "";
                            setDefaultColor();
                            label21.ForeColor = Color.Red;
                            break;
                        case 5:
                            textBox111.Text = calc.PeekStack() + "";
                            setDefaultColor();
                            label20.ForeColor = Color.Red;
                            break;
                        case 6:
                            textBox110.Text = calc.PeekStack() + "";
                            setDefaultColor();
                            label19.ForeColor = Color.Red;
                            break;
                        case 7:
                            textBox109.Text = calc.PeekStack() + "";
                            setDefaultColor();
                            label18.ForeColor = Color.Red;
                            break;
                        case 8:
                            textBox108.Text = calc.PeekStack() + "";
                            setDefaultColor();
                            label17.ForeColor = Color.Red;
                            break;
                        case 9:
                            textBox107.Text = calc.PeekStack() + "";
                            setDefaultColor();
                            label16.ForeColor = Color.Red;
                            break;
                        case 10:
                            textBox106.Text = calc.PeekStack() + "";
                            setDefaultColor();
                            label15.ForeColor = Color.Red;
                            break;
                        case 11:
                            textBox104.Text = calc.PeekStack() + "";
                            setDefaultColor();
                            label14.ForeColor = Color.Red;
                            break;
                        case 12:
                            textBox105.Text = calc.PeekStack() + "";
                            setDefaultColor();
                            label13.ForeColor = Color.Red;
                            break;
                        case 13:
                            textBox103.Text = calc.PeekStack() + "";
                            setDefaultColor();
                            label12.ForeColor = Color.Red;
                            break;
                        case 14:
                            textBox102.Text = calc.PeekStack() + "";
                            setDefaultColor();
                            label11.ForeColor = Color.Red;
                            break;
                    }
                }
                else
                {
                    button22.Enabled = false;
                }
            }
            else
            {
                
                calc.GeneralForm(textBox1.Text, false);
                button22.Enabled = false;
            }
            textBox3.Text = calc.getStroka();
        }



        private void button23_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
            textBox3.Clear();
            calc.resetAll();
            if (button22.Enabled == false)
                button22.Enabled=true;
        }

        private void button21_Click(object sender, EventArgs e)
        {
            
           
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void button25_Click(object sender, EventArgs e)
        {
            string[] variables = { textBox118.Text, textBox119.Text, textBox120.Text, textBox121.Text, textBox122.Text, textBox123.Text, textBox124.Text, textBox125.Text, textBox126.Text, textBox127.Text };
            textBox117.Text = calc.getResult(variables);
        }
    }
}
