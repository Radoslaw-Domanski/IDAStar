using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
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
        public List<Wezel> wezlyWyszukane;
        public IDAStar ida;
        public List<Wezel> listaTmp;
        public bool sciezkaWyszukiwana = false;


        public Form1()
        {            
            InitializeComponent();
            CheckForIllegalCrossThreadCalls = false;
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
                return "manhattan";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int wymiar = (Int32)wymiaryNumeric.Value;
            labirynt = new Labirynt(wymiar);
            buttons = new Button[wymiar*wymiar];
            int index = 0;
            for(int i = 0; i < wymiar; i++)
            {
                for(int j = 0; j < wymiar; j++)
                {
                    Button b = new Button();
                    Button b2 = new Button();
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

        public void zdarzenieZmianyBadanejSciezki(object sender, EventArgs e)
        {
            listaTmp = sender as List<Wezel>;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (labirynt == null) return;

            Control.ControlCollection kontrolki = panel1.Controls;
            if (monitorujCheckBox.Checked)
            {
                panel2.Controls.Clear();
                foreach (Button b in kontrolki)
                {
                    Button button = new Button();
                    button.Tag = b.Tag;
                    button.BackColor = b.BackColor;
                    button.Size = b.Size;
                    button.Location = b.Location;
                    button.Text = b.Text;
                    panel2.Controls.Add(button);
                }
            }

            Thread watek = new Thread(() =>
            {
                sciezkaWyszukiwana = true;
                double kosztAkcji = (Double)kosztAkcjiNumeric.Value;
                
                // z opoznieniem i sledzeniem zmian
                if (monitorujCheckBox.Checked)
                {
                    ida = new IDAStar(wezelPoczatkowy.x, wezelPoczatkowy.y, wezelKoncowy.x, wezelKoncowy.y, labirynt, sprawdzRadio(),kosztAkcji, (Int32)opoznienieNumeric.Value);
                }
                //bez
                else
                {
                    ida = new IDAStar(wezelPoczatkowy.x, wezelPoczatkowy.y, wezelKoncowy.x, wezelKoncowy.y, labirynt, sprawdzRadio(), kosztAkcji,0);
                }

                ida.zglosZdarzenie += zdarzenieZmianyBadanejSciezki;

                timeTextBox.Text = "...";
                powodzeniaTextBox.Text = "...";
                niepowodzeniaTextBox.Text = "...";
                sredniaDlugoscSciezkiTextBox.Text = "...";
                iloscRozwinietychWezlowTextBox.Text = "...";

                DateTime data1,data2;

                if (maxCzasWykonaniaCheckBox.Checked)
                {
                    int maxCzasWykonania = (Int32)maxCzasNumeric.Value;
                    data1 = DateTime.Now;
                    wezlyWyszukane = ida.szukajSciezki(wezelPoczatkowy.x, wezelPoczatkowy.y, wezelKoncowy.x, wezelKoncowy.y, labirynt, maxCzasWykonania);
                    data2 = DateTime.Now;
                }
                else
                {
                    data1 = DateTime.Now;
                    wezlyWyszukane = ida.szukajSciezki(wezelPoczatkowy.x, wezelPoczatkowy.y, wezelKoncowy.x, wezelKoncowy.y, labirynt);
                    data2 = DateTime.Now;
                }
            
                if(wezlyWyszukane.Count == 0)
                {
                    if (ida.uplynalCzasWykonywania)
                    {
                        timeTextBox.Text = ida.maxCzasWykonania + "s minęło";
                        powodzeniaTextBox.Text = ida.maxCzasWykonania + "s minęło";
                        niepowodzeniaTextBox.Text = ida.maxCzasWykonania + "s minęło";
                        sredniaDlugoscSciezkiTextBox.Text = ida.maxCzasWykonania + "s minęło";
                        iloscRozwinietychWezlowTextBox.Text = ida.maxCzasWykonania + "s minęło";
                    }
                    else
                    {
                        timeTextBox.Text = "-";
                        powodzeniaTextBox.Text = "-";
                        niepowodzeniaTextBox.Text = "-";
                        sredniaDlugoscSciezkiTextBox.Text = "-";
                        iloscRozwinietychWezlowTextBox.Text = "-";
                    }
                }
                else
                {
                    wezlyWyszukane.RemoveAt(0);
                    wezlyWyszukane.RemoveAt(0);

                    foreach (Wezel w in wezlyWyszukane)
                    {
                        foreach (Control kontrolka in kontrolki)
                        {
                            Wezel wezelKontrolka = (Wezel)kontrolka.Tag;
                            if (wezelKontrolka.x.Equals(w.x) && wezelKontrolka.y.Equals(w.y))
                            {
                                kontrolka.BackColor = Color.Yellow;
                            }
                        }
                    }

                    timeTextBox.Text = Math.Ceiling((data2 - data1).TotalMilliseconds).ToString();
                    powodzeniaTextBox.Text = ida.iloscPowodzen.ToString();
                    niepowodzeniaTextBox.Text = ida.iloscNiepowodzen.ToString();
                    sredniaDlugoscSciezkiTextBox.Text = ((Double)ida.lacznaDlugoscSciezki / (ida.iloscNiepowodzen + ida.iloscPowodzen)).ToString();
                    iloscRozwinietychWezlowTextBox.Text = ida.wezlyOdwiedzone.ToString();
                    sciezkaWyszukiwana = false;
                }
            });
            
            watek.Start();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            panel1.Controls.Clear();
            panel2.Controls.Clear();
            manhattanRadio.Checked = true;
            wymiaryNumeric.Value = 5;
            wezelKoncowy = null;
            labirynt = null;
            buttons = null;
            wybranyStart = true;
            wybranyKoniec = true;
            wezelPoczatkowy = null;
            wezlyWyszukane = null;
            ida = null;
            timeTextBox.Text = "";
            powodzeniaTextBox.Text = "";
            niepowodzeniaTextBox.Text = "";
            sredniaDlugoscSciezkiTextBox.Text = "";
            iloscRozwinietychWezlowTextBox.Text = "";
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (ida == null || listaTmp == null || !monitorujCheckBox.Checked) return;
            if (!sciezkaWyszukiwana) return;

            Control.ControlCollection kontrolki = panel2.Controls;
            List<Wezel> zablokowane = ida.labirynt.pobierzZablokowane();
            // wyczyszczenie kolorow + dodanie przeszkod
            foreach (Button kontrolka in kontrolki)
            {
                kontrolka.BackColor = Color.White;
                Wezel wezelKontrolka = (Wezel)kontrolka.Tag;
                foreach (Wezel w in zablokowane)
                {
                    if (wezelKontrolka.x.Equals(w.x) && wezelKontrolka.y.Equals(w.y))
                    {
                        kontrolka.BackColor = Color.Gray;
                    }
                }
            }
            // dodanie aktualnie badanej sciezki            
            try
            {
                if (listaTmp == null) return;
                foreach (Wezel wezel in listaTmp)
                {
                    foreach (Button kontrolka in kontrolki)
                    {
                        Wezel wezelKontrolka = (Wezel)kontrolka.Tag;
                        if (wezelKontrolka.x.Equals(wezel.x) && wezelKontrolka.y.Equals(wezel.y))
                        {
                            kontrolka.BackColor = Color.Yellow;
                        }
                    }
                }
            }catch(Exception exc){ }
            // narysowanie poczatku i konca
            foreach (Button kontrolka in kontrolki)
            {
                Wezel wezelKontrolka = (Wezel)kontrolka.Tag;
                if (wezelKontrolka.x.Equals(ida.koniec.x) && wezelKontrolka.y.Equals(ida.koniec.y))
                {
                    kontrolka.BackColor = Color.Red;
                }
                else if (wezelKontrolka.x.Equals(ida.start.x) && wezelKontrolka.y.Equals(ida.start.y))
                {
                    kontrolka.BackColor = Color.Green;
                }
            }
        }
    }
}
