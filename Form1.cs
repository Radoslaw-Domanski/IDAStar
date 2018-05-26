using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IDAStar
{
    public partial class Form1 : Form
    {
        Grid grid;
        Button[] buttons;

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string x = textBox1.Text;
            int wymiar = Int32.Parse(x);
            grid = new Grid(wymiar);
            buttons = new Button[wymiar*wymiar];
            int index = 0;
            for(int i = 0; i < wymiar; i++)
            {
                for(int j = 0; j < wymiar; j++)
                {
                    Button b = new Button();
                    b.Size = new Size(30, 30);
                    b.Location = new Point(i * 30, j * 30);
                    b.Text = i + " " + j;
                    b.Tag = grid.getWezel(i, j);
                    b.Click += new EventHandler(buttonClick);
                    buttons[index++] = b;
                }
            }
            panel1.Controls.AddRange(buttons);
        }

        protected void buttonClick(object sender, EventArgs e)
        {
            Button b = sender as Button;
            Wezel wezel = (Wezel)b.Tag;
            textBox1.Text = wezel.x + " " + wezel.y;
            
        }
    }
}
