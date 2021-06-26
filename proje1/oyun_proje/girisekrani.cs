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

namespace oyun_proje
{
    public partial class girisekrani : Form
    {
        public girisekrani()
        {
            InitializeComponent();
        }

        public static int alanx;
        public static int alany;
        public static int altinoran;
        public static int gizlialtinoran;
        public static int hamlemaliyet;
        public static int hamlesayisi;
        public static int kasaaltinmiktari;
        public static int gizlialtinacma;
        public static int Ahedefmaliyet;
        public static int Bhedefmaliyet;
        public static int Chedefmaliyet;
        public static int Dhedefmaliyet;
        private void girisekrani_Load(object sender, EventArgs e)
        {
            this.Location = new Point(50, 50);



        }

        private void button_basla_Click(object sender, EventArgs e)
        {

            alanx = Convert.ToInt32(textbox_alanx.Text);
            alany = Convert.ToInt32(textbox_alany.Text);
            altinoran = Convert.ToInt32(textbox_altinorani.Text);
            gizlialtinoran = Convert.ToInt32(textbox_gizlialtinoran.Text);
            hamlemaliyet = Convert.ToInt32(textbox_hamleucret.Text);
            hamlesayisi = Convert.ToInt32(textbox_hamlesayisi.Text);
            kasaaltinmiktari = Convert.ToInt32(textbox_kasaaltindegeri.Text);
            gizlialtinacma = Convert.ToInt32(textbox_gizlialtinacma.Text);
            Ahedefmaliyet = Convert.ToInt32(textbox_Ahedefmaliyet.Text);
            Bhedefmaliyet = Convert.ToInt32(textbox_Bhedefmaliyet.Text);
            Chedefmaliyet = Convert.ToInt32(textbox_Chedefmaliyet.Text);
            Dhedefmaliyet = Convert.ToInt32(textbox_Dhedefmaliyet.Text);

            // Oyun Başlangıcında Txt dosyalarını sıfırlıyor..
            StreamWriter sw = new StreamWriter(@"A.txt", false);
            sw.Write("");
            sw.Flush();
            sw.Close();

            StreamWriter sw1 = new StreamWriter(@"B.txt", false);
            sw1.Write("");
            sw1.Flush();
            sw1.Close();

            StreamWriter sw2 = new StreamWriter(@"C.txt", false);
            sw2.Write("");
            sw2.Flush();
            sw2.Close();

            StreamWriter sw3 = new StreamWriter(@"D.txt", false);
            sw3.Write("");
            sw3.Flush();
            sw3.Close();


            this.Hide();
            oyunalani oyunalani = new oyunalani();
            oyunalani.Show();
        }

        private void button_exit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
