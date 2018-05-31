using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IDAStar
{
    public partial class Form1 : Form
    {
        public Labirynt labirynt;
        public Button[] buttons;
        public bool wybranyStart = true;
        public bool wybranyKoniec = true;
        public Wezel wezelPoczatkowy;
        public Wezel wezelKoncowy;

        public Form1()
        {
            InitializeComponent();
        }
        public string sprawdzRadio()
        {
            if (chebyshevRadio.Checked)
            {
                return "chebyshev";
            }
            else if (euclideanRadio.Checked)
            {
                return "euclidean";
            }
            else
            {
                return "manhattan";
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string heurystyka = sprawdzRadio();
            int wymiar = (Int32)wymiaryNumeric.Value;
            labirynt = new Labirynt(wymiar);
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
                    b.Tag = labirynt.getWezel(i, j);
                    b.BackColor = Color.White;
                    b.Click += new EventHandler(buttonClick);
                    buttons[index++] = b;
                }
            }
            buttons[0].BackColor = Color.Green;
            wezelPoczatkowy = labirynt.getWezel(0, 0);
            buttons[buttons.Length - 1].BackColor = Color.Red;
            wezelKoncowy = labirynt.getWezel(wymiar - 1, wymiar - 1);

            panel1.Controls.AddRange(buttons);
        }

        protected void buttonClick(object sender, EventArgs e)
        {
            
            Button b = sender as Button;
            Wezel wezel = (Wezel)b.Tag;
            //textBox1.Text = wezel.x + " " + wezel.y;
            
            if (b.BackColor.Equals(Color.Green))
            {
                b.BackColor = Color.White;
                wybranyStart = false;
            }
            else if (b.BackColor.Equals(Color.Red))
            {
                b.BackColor = Color.White;
                wybranyKoniec = false;
            }
            else if (b.BackColor.Equals(Color.Gray))
            {
                b.BackColor = Color.White;
                labirynt.ustawOdblokowane(wezel.x, wezel.y, true);
            }
            else if (b.BackColor.Equals(Color.White)){
                if (!wybranyStart)
                {
                    b.BackColor = Color.Green;
                    wybranyStart = true;
                    wezelPoczatkowy = wezel;
                }
                else if (!wybranyKoniec)
                {
                    b.BackColor = Color.Red;
                    wybranyKoniec = true;
                    wezelKoncowy = wezel;
                }
                else
                {
                    labirynt.ustawOdblokowane(wezel.x, wezel.y, false);
                    b.BackColor = Color.Gray;
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Control.ControlCollection kontrolki = panel1.Controls;
            IDAStar ida = new IDAStar(wezelPoczatkowy.x, wezelPoczatkowy.y, wezelKoncowy.x, wezelKoncowy.y, labirynt, new Heurystyka());
            List<Wezel> wezlyWyszukane = ida.szukajSciezki(wezelPoczatkowy.x, wezelPoczatkowy.y, wezelKoncowy.x, wezelKoncowy.y, labirynt);
            
            if(wezlyWyszukane.Count == 0)
            {
                //textBox1.Text = "Nie da sie";
            }
            else
            {
                wezlyWyszukane.RemoveAt(0);
                wezlyWyszukane.RemoveAt(0);

                using (StreamWriter writer = new StreamWriter("wynik.txt"))
                {
                    foreach (Wezel w in wezlyWyszukane)
                    {
                        writer.WriteLine(w.x + " " + w.y);
                        foreach (Control kontrolka in kontrolki)
                        {
                            Wezel wezelKontrolka = (Wezel)kontrolka.Tag;
                            if (wezelKontrolka.x.Equals(w.x) && wezelKontrolka.y.Equals(w.y))
                            {
                                kontrolka.BackColor = Color.Yellow;
                            }
                        }
                    }
                }
            }
        }
    }
}
