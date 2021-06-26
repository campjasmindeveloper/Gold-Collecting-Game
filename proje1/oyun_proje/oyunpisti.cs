using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace oyun_proje
{
    public partial class oyunalani : Form
    {
        public oyunalani()
        {
            InitializeComponent();
        }
        /// <summary>
        /// oyunalanımatriste, oyuncu konumları altın değerleri mevcut
        /// gizlialtinmatris  gizli altınların yerleri tutualmaktadır.
        /// altındeğer matrisinde ise altın değerleri tutalmaktadır.
        /// 
        /// </summary>

        Label[,] label = new Label[girisekrani.alanx, girisekrani.alany];
        int[,] altindegermatris = new int[girisekrani.alanx, girisekrani.alany];
        int[,] gizlialtinmatris = new int[girisekrani.alanx, girisekrani.alany];
        int[,] oyunalanimatris = new int[girisekrani.alanx, girisekrani.alany];
        Random rast = new Random();
        public int Toplamaltin = 0;

        private void oyunalani_Load(object sender, EventArgs e)
        {
            groupBox1.Visible = false;
            this.Location = new Point(50, 50); //form konumlandırma
            this.Height = 700; //form yükseklik boyutu
            this.Width = 600; // form genişlik boyutu   


            oyunalaniolustur();

            Aoyuncu.xkonum = 0; Aoyuncu.ykonum = 0;
            Aoyuncu.xhedef = 0; Aoyuncu.yhedef = 0;
            Aoyuncu.kasaaltin = girisekrani.kasaaltinmiktari;
            Aoyuncu.hamlesayisi = 0;
            Aoyuncu.harcananaltin = 0;
            Aoyuncu.toplananaltin = 0;
            Aoyuncu.durumu = true;


            Boyuncu.xkonum = 0; Boyuncu.ykonum = girisekrani.alany - 1;
            Boyuncu.xhedef = 0; Boyuncu.yhedef = 0;
            Boyuncu.kasaaltin = girisekrani.kasaaltinmiktari;
            Boyuncu.hamlesayisi = 0;
            Boyuncu.harcananaltin = 0;
            Boyuncu.toplananaltin = 0;
            Boyuncu.durumu = true;

            Coyuncu.xkonum = girisekrani.alanx - 1; Coyuncu.ykonum = girisekrani.alany - 1;
            Coyuncu.xhedef = 0; Coyuncu.yhedef = 0;
            Coyuncu.kasaaltin = girisekrani.kasaaltinmiktari;
            Coyuncu.hamlesayisi = 0;
            Coyuncu.harcananaltin = 0;
            Coyuncu.toplananaltin = 0;
            Coyuncu.durumu = true;

            Doyuncu.xkonum = girisekrani.alanx - 1; Doyuncu.ykonum = 0;
            Doyuncu.xhedef = 0; Doyuncu.yhedef = 0;
            Doyuncu.kasaaltin = girisekrani.kasaaltinmiktari;
            Doyuncu.hamlesayisi = 0;
            Doyuncu.harcananaltin = 0;
            Doyuncu.toplananaltin = 0;
            Doyuncu.durumu = true;

            label_Akasaaltin.Text = "A oyuncu :" + Aoyuncu.kasaaltin.ToString() + " Altın";
            label_Bkasaaltin.Text = "B oyuncu :" + Boyuncu.kasaaltin.ToString() + " Altın";
            label_Ckasaaltin.Text = "C oyuncu :" + Coyuncu.kasaaltin.ToString() + " Altın";
            label_Dkasaaltin.Text = "D oyuncu :" + Doyuncu.kasaaltin.ToString() + " Altın";           
        }

        public void oyunalaniolustur()
        {
            pictureBox1.BorderStyle = BorderStyle.FixedSingle; //picture dizisini ekleyediğimiz picturebox ayarları
            pictureBox1.Height = 25 * girisekrani.alanx;
            pictureBox1.Width = 25 * girisekrani.alany;
            int üst = 0, sol = 0;
            for (int i = 0; i < girisekrani.alanx; i++)
            {
                for (int j = 0; j < girisekrani.alany; j++) //pictureleri picturebox1 kısmına eklediğimiz kod
                {
                    label[i, j] = new Label();
                    label[i, j].Height = 25; //picturebox genel ayarları boyutu çerçevesi rengi vs..
                    label[i, j].Width = 25;
                    label[i, j].Top = üst;
                    label[i, j].Left = sol;
                    label[i, j].BackColor = Color.LightGray;
                    label[i, j].BorderStyle = BorderStyle.FixedSingle;                    
                    pictureBox1.Controls.Add(label[i, j]);
                    sol += 25;
                }
                sol = 0;
                üst += 25;
            }

            label[0, 0].Text = "A"; //Oyunculara köşelere yazılıyor..
            label[0, oyunalanimatris.GetUpperBound(1)].Text = "B";
            label[oyunalanimatris.GetUpperBound(0), oyunalanimatris.GetUpperBound(1)].Text = "C";
            label[oyunalanimatris.GetUpperBound(0), 0].Text = "D";

            for (int i = 0; i < girisekrani.alanx; i++) //Matrisleri dolduruyoruz..
            {
                for (int j = 0; j < girisekrani.alany; j++)
                {

                    altindegermatris[i, j] = 0;
                    oyunalanimatris[i, j] = 0;
                    gizlialtinmatris[i, j] = 0;
                }
            }

            oyunalanimatris[0, 0] = 3; //A
            oyunalanimatris[0, oyunalanimatris.GetUpperBound(1)] = 3; //B
            oyunalanimatris[oyunalanimatris.GetUpperBound(0), oyunalanimatris.GetUpperBound(1)] = 3;//C
            oyunalanimatris[oyunalanimatris.GetUpperBound(0), 0] = 3;//D

            //Altındegermatrisine altın değerlerini ekliyoruz.

            double altinsayisi = (girisekrani.alanx * girisekrani.alany * girisekrani.altinoran) / 100;
            double gizlialtinsayisi = (altinsayisi * girisekrani.gizlialtinoran) / 100;

            int sayac = 0; // rastgele altın ekleme
            while (sayac < Math.Ceiling(altinsayisi))
            {
                int sayi1 = rast.Next(0, girisekrani.alanx);
                int sayi2 = rast.Next(0, girisekrani.alany);
                if (oyunalanimatris[sayi1, sayi2] == 0)
                {
                    oyunalanimatris[sayi1, sayi2] = 1;
                    sayac++;
                }
            }
            sayac = 0; // rastgele altın ekleme
            while (sayac < Math.Ceiling(gizlialtinsayisi))
            {
                int sayi1 = rast.Next(0, girisekrani.alanx);
                int sayi2 = rast.Next(0, girisekrani.alany);
                if (oyunalanimatris[sayi1, sayi2] == 1)
                {
                    oyunalanimatris[sayi1, sayi2] = 2;
                    gizlialtinmatris[sayi1, sayi2] = 1;
                    sayac++;
                }
            }

            for (int i = 0; i < girisekrani.alanx; i++)
            {
                for (int j = 0; j < girisekrani.alany; j++)
                {
                    if (oyunalanimatris[i, j] == 1 || oyunalanimatris[i, j] == 2)
                    {
                        int deger = rast.Next(1, 5) * 5;
                        altindegermatris[i, j] = deger;
                        Toplamaltin += deger;
                    }
                }
            }

            // Oyuntahtasına altın değerlerini yazma kodu

            for (int i = 0; i < girisekrani.alanx; i++)
            {
                for (int j = 0; j < girisekrani.alany; j++)
                {
                    if (oyunalanimatris[i, j] == 1)
                    {
                        label[i, j].Text = altindegermatris[i, j].ToString();
                        label[i, j].BackColor = Color.GreenYellow;
                    }
                }
            }
        }

        private void button_basla_Click(object sender, EventArgs e)
        {
            int a;

            for (int i = Toplamaltin; i > 0; )
            {
                if (Boyuncu.durumu == false && Aoyuncu.durumu == false && Coyuncu.durumu == false && Doyuncu.durumu == false)
                {
                    break;
                }

                
                if (Aoyuncu.xhedef == 0 && Aoyuncu.yhedef == 0)
                {
                    Ahedefsec();
                }
                for (int j = girisekrani.hamlesayisi; j >0; )
                {
                    if (Aoyuncu.durumu == true)
                    {
                        if (Aoyuncu.xhedef == 0 && Aoyuncu.yhedef == 0)
                        {
                            break;
                        }
                        else
                        {
                            Ahedefegit();
                            j--;
                            Thread.Sleep(200); this.Refresh();
                        }
                    }
                    else
                    {
                        j--;
                    }
                   
                }
                Thread.Sleep(200); this.Refresh();

               
                if (Boyuncu.xhedef == 0 && Boyuncu.yhedef == 0)
                {
                    Bhedefsec();
                }
                for (int j = girisekrani.hamlesayisi; j > 0; )
                {
                    if (Boyuncu.durumu == true)
                    {
                        if (Boyuncu.xhedef == 0 && Boyuncu.yhedef == 0)
                        {

                            break;
                        }
                        else
                        {
                            Bhedefegit();
                            j--;
                            Thread.Sleep(200); this.Refresh();
                        }
                    }
                    else
                    {
                        j--;
                    }
                    
                }
                Thread.Sleep(200); this.Refresh();

                
                if (Coyuncu.xhedef == 0 && Coyuncu.yhedef == 0)
                {
                    Chedefsec();
                }
                for (int j = girisekrani.hamlesayisi; j > 0; )
                {
                    if (Coyuncu.durumu == true)
                    {
                        if (Coyuncu.xhedef == 0 && Coyuncu.yhedef == 0)
                        {
                            break;
                        }
                        else
                        {
                            Chedefegit();
                            j--;
                            Thread.Sleep(200); this.Refresh();
                        }
                    }
                    else
                    {
                        j--;
                    }
                   
                }
                Thread.Sleep(200); this.Refresh();

                
                if (Doyuncu.xhedef == 0 && Doyuncu.yhedef == 0)
                {
                    Dhedefsec();
                }
                for (int j = girisekrani.hamlesayisi; j > 0;)
                {
                    if (Doyuncu.durumu == true)
                    {
                        if (Doyuncu.xhedef == 0 && Doyuncu.yhedef == 0)
                        {
                            break;
                        }
                        else
                        {
                            Dhedefegit();
                            j--;
                            Thread.Sleep(200); this.Refresh();
                        }
                    }
                    else
                    {
                        j--;
                    }
                   
                }
                Thread.Sleep(200); this.Refresh();

            }
            MessageBox.Show("Oyun Bitti");
           
        }

        private void button_oyuncik_Click(object sender, EventArgs e)
        {

            groupBox1.Height = this.Height;
            groupBox1.Width = this.Width;
            groupBox1.Left = 0;
            groupBox1.Top = 0;
            groupBox1.Visible = true;

            Aoyuncukasaaltin.Text = Aoyuncu.kasaaltin.ToString();
            Aoyuncuadim.Text = Aoyuncu.hamlesayisi.ToString();
            Aoyuncutoplananaltin.Text = Aoyuncu.toplananaltin.ToString();
            Aoyuncuharcananaltin.Text = Aoyuncu.harcananaltin.ToString();

            Boyuncukasaaltin.Text = Boyuncu.kasaaltin.ToString();
            Boyuncuadim.Text = Boyuncu.hamlesayisi.ToString();
            Boyuncutoplananaltin.Text = Boyuncu.toplananaltin.ToString();
            Boyuncuharcananaltin.Text = Boyuncu.harcananaltin.ToString();

            Coyuncukasaaltin.Text = Coyuncu.kasaaltin.ToString();
            Coyuncuadim.Text = Coyuncu.hamlesayisi.ToString();
            Coyuncutoplananaltin.Text = Coyuncu.toplananaltin.ToString();
            Coyuncuharcananaltin.Text = Coyuncu.harcananaltin.ToString();

            Doyuncukasaaltin.Text = Doyuncu.kasaaltin.ToString();
            Doyuncuadim.Text = Doyuncu.hamlesayisi.ToString();
            Doyuncutoplananaltin.Text = Doyuncu.toplananaltin.ToString();
            Doyuncuharcananaltin.Text = Doyuncu.harcananaltin.ToString();

        }

        private void button_kapat_Click(object sender, EventArgs e)
        {

            this.Close();
            girisekrani girisekrani = new girisekrani();
            girisekrani.Show();
        }

        //************* A Oyuncu Kod kısmı
        public class Aoyuncu
        {
            public static int xkonum { get; set; } = 0;
            public static int ykonum { get; set; } = 0;
            public static int xhedef { get; set; } = 0;
            public static int yhedef { get; set; } = 0;
            public static int kasaaltin { get; set; } = girisekrani.kasaaltinmiktari;
            public static int hamlesayisi { get; set; } = 0;
            public static int harcananaltin { get; set; } = 0;
            public static int toplananaltin { get; set; } = 0;
            public static bool durumu { get; set; } = true;

        }
          
        public void Ahedefsec()
        {
            int maxuzaklik = Int16.MaxValue; 

            if (Aoyuncu.kasaaltin < girisekrani.Ahedefmaliyet || Toplamaltin <= 0)
            {
                Aoyuncu.durumu = false;
            }

            if (Aoyuncu.durumu != false)
            {
                if (Aoyuncu.xhedef == 0 && Aoyuncu.yhedef == 0) //hedef yoksa hedef ücreti ödüyor
                {
                    Aoyuncu.kasaaltin -= girisekrani.Ahedefmaliyet;
                    Aoyuncu.harcananaltin += girisekrani.Ahedefmaliyet;
                    label_Akasaaltin.Text = " A oyuncu :" + Aoyuncu.kasaaltin.ToString() + " Altın";

                }
                //oyunalanımatriste A oyuncunun konuma yakın olan altının x koordinatı ile y koordinat toplamları kullanılarak yakın altın bulunuyor.
                for (int i = 0; i <= oyunalanimatris.GetUpperBound(0); i++) 
                {
                    for (int j = 0; j <= oyunalanimatris.GetUpperBound(1); j++)
                    {
                        if (oyunalanimatris[i, j] == 1)
                        {
                            int yoluzaklik = (Aoyuncu.xkonum - i) + (Aoyuncu.ykonum - j); // oyuncunun hedefe ulaşması için toplam adım sayısı, maxuzaklıktan küçükse , hedef olarak küçük olanı seçer 
                            if (yoluzaklik < 0)
                            {
                                yoluzaklik *= -1;
                            }
                            if (yoluzaklik < 0)
                            {
                                yoluzaklik *= -1;
                            }

                            if (yoluzaklik < maxuzaklik)
                            {
                                maxuzaklik = yoluzaklik;
                                Aoyuncu.xhedef = i;
                                Aoyuncu.yhedef = j;
                            }

                        }
                    }
                }                
            }

        }

        public void Ahedefegit()
        {
            int xkoordinat = Aoyuncu.xkonum - Aoyuncu.xhedef;
            int ykoordinat = Aoyuncu.ykonum - Aoyuncu.yhedef;
            if (xkoordinat < 0)
            {
                xkoordinat *= -1;
            }
            if (ykoordinat < 0)
            {
                ykoordinat *= -1;
            }
                    

            if (Aoyuncu.kasaaltin < girisekrani.hamlemaliyet || Toplamaltin <= 0)
            {
                Aoyuncu.durumu = false;
            }

            if (Aoyuncu.durumu != false) //önce x koordinat üzerinde hareket eder daha sonra y koordinat  hareket ederek hedefe ulaşır.
            {
                if (xkoordinat != 0)
                {
                    if (Aoyuncu.xkonum < Aoyuncu.xhedef)
                    {
                        label[Aoyuncu.xkonum, Aoyuncu.ykonum].Text = "";
                        oyunalanimatris[Aoyuncu.xkonum, Aoyuncu.ykonum] = 0;
                        Aoyuncu.xkonum++;
                        label[Aoyuncu.xkonum, Aoyuncu.ykonum].Text = "A";
                        Aoyuncu.hamlesayisi++;
                        Aoyuncu.harcananaltin += girisekrani.hamlemaliyet;
                        Aoyuncu.kasaaltin -= girisekrani.hamlemaliyet;
                        label_Akasaaltin.Text = "A oyuncu :" + Aoyuncu.kasaaltin.ToString() + " Altın";
                        if (gizlialtinmatris[Aoyuncu.xkonum - 1, Aoyuncu.ykonum] == 1) // önceki konumda gizlialtın varsa onu görünür hale getiriyor.
                        {
                            label[Aoyuncu.xkonum - 1, Aoyuncu.ykonum].BackColor = Color.GreenYellow;
                            label[Aoyuncu.xkonum - 1, Aoyuncu.ykonum].Text = altindegermatris[Aoyuncu.xkonum - 1, Aoyuncu.ykonum].ToString();
                            oyunalanimatris[Aoyuncu.xkonum - 1, Aoyuncu.ykonum] = 1;
                            gizlialtinmatris[Aoyuncu.xkonum - 1, Aoyuncu.ykonum] = 0;
                        }
                        if (oyunalanimatris[Aoyuncu.xkonum, Aoyuncu.ykonum] == 1) // ilerlerken hedef altının dışında altın üzerinde durursa altını alıyor..
                        {
                            Aoyuncu.toplananaltin += altindegermatris[Aoyuncu.xkonum, Aoyuncu.ykonum];
                            Aoyuncu.kasaaltin += altindegermatris[Aoyuncu.xkonum, Aoyuncu.ykonum];
                            label[Aoyuncu.xkonum, Aoyuncu.ykonum].BackColor = Color.LightGray;
                            Toplamaltin -= altindegermatris[Aoyuncu.xkonum, Aoyuncu.ykonum];
                            altindegermatris[Aoyuncu.xkonum, Aoyuncu.ykonum] = 0;
                            oyunalanimatris[Aoyuncu.xkonum, Aoyuncu.ykonum] = 3;
                        }
                        oyunalanimatris[Aoyuncu.xkonum, Aoyuncu.ykonum] = 3;
                        Aoyuncuyaz();
                        Thread.Sleep(200); this.Refresh();


                    }
                    if (Aoyuncu.xkonum > Aoyuncu.xhedef)
                    {
                        label[Aoyuncu.xkonum, Aoyuncu.ykonum].Text = "";
                        oyunalanimatris[Aoyuncu.xkonum, Aoyuncu.ykonum] = 0;
                        Aoyuncu.xkonum--;
                        label[Aoyuncu.xkonum, Aoyuncu.ykonum].Text = "A";
                        Aoyuncu.hamlesayisi++;
                        Aoyuncu.harcananaltin += girisekrani.hamlemaliyet;
                        Aoyuncu.kasaaltin -= girisekrani.hamlemaliyet;
                        label_Akasaaltin.Text = "A oyuncu :" + Aoyuncu.kasaaltin.ToString() + " Altın";
                        if (gizlialtinmatris[Aoyuncu.xkonum + 1, Aoyuncu.ykonum] == 1)
                        {
                            label[Aoyuncu.xkonum + 1, Aoyuncu.ykonum].BackColor = Color.GreenYellow;
                            label[Aoyuncu.xkonum + 1, Aoyuncu.ykonum].Text = altindegermatris[Aoyuncu.xkonum + 1, Aoyuncu.ykonum].ToString();
                            oyunalanimatris[Aoyuncu.xkonum + 1, Aoyuncu.ykonum] = 1;
                            gizlialtinmatris[Aoyuncu.xkonum + 1, Aoyuncu.ykonum] = 0;
                        }
                        if (oyunalanimatris[Aoyuncu.xkonum, Aoyuncu.ykonum] == 1)
                        {
                            Aoyuncu.toplananaltin += altindegermatris[Aoyuncu.xkonum, Aoyuncu.ykonum];
                            Aoyuncu.kasaaltin += altindegermatris[Aoyuncu.xkonum, Aoyuncu.ykonum];
                            label[Aoyuncu.xkonum, Aoyuncu.ykonum].BackColor = Color.LightGray;
                            Toplamaltin -= altindegermatris[Aoyuncu.xkonum, Aoyuncu.ykonum];
                            altindegermatris[Aoyuncu.xkonum, Aoyuncu.ykonum] = 0;
                            oyunalanimatris[Aoyuncu.xkonum, Aoyuncu.ykonum] = 3;
                        }
                        oyunalanimatris[Aoyuncu.xkonum, Aoyuncu.ykonum] = 3;
                        Aoyuncuyaz();
                        Thread.Sleep(200); this.Refresh();

                    }
                }
                if (xkoordinat == 0)
                {
                    if (ykoordinat != 0)
                    {
                        if (Aoyuncu.ykonum < Aoyuncu.yhedef)
                        {
                            label[Aoyuncu.xkonum, Aoyuncu.ykonum].Text = "";
                            oyunalanimatris[Aoyuncu.xkonum, Aoyuncu.ykonum] = 0;
                            Aoyuncu.ykonum++;
                            label[Aoyuncu.xkonum, Aoyuncu.ykonum].Text = "A";
                            Aoyuncu.hamlesayisi++;
                            Aoyuncu.harcananaltin += girisekrani.hamlemaliyet;
                            Aoyuncu.kasaaltin -= girisekrani.hamlemaliyet;
                            label_Akasaaltin.Text = "A oyuncu :" + Aoyuncu.kasaaltin.ToString() + " Altın";
                            if (gizlialtinmatris[Aoyuncu.xkonum, Aoyuncu.ykonum - 1] == 1)
                            {
                                label[Aoyuncu.xkonum, Aoyuncu.ykonum - 1].BackColor = Color.GreenYellow;
                                label[Aoyuncu.xkonum, Aoyuncu.ykonum - 1].Text = altindegermatris[Aoyuncu.xkonum, Aoyuncu.ykonum - 1].ToString();
                                oyunalanimatris[Aoyuncu.xkonum, Aoyuncu.ykonum - 1] = 1;
                                gizlialtinmatris[Aoyuncu.xkonum, Aoyuncu.ykonum - 1] = 0;
                            }
                            if (oyunalanimatris[Aoyuncu.xkonum, Aoyuncu.ykonum] == 1)
                            {
                                Aoyuncu.toplananaltin += altindegermatris[Aoyuncu.xkonum, Aoyuncu.ykonum];
                                Aoyuncu.kasaaltin += altindegermatris[Aoyuncu.xkonum, Aoyuncu.ykonum];
                                label[Aoyuncu.xkonum, Aoyuncu.ykonum].BackColor = Color.LightGray;
                                Toplamaltin -= altindegermatris[Aoyuncu.xkonum, Aoyuncu.ykonum];
                                altindegermatris[Aoyuncu.xkonum, Aoyuncu.ykonum] = 0;
                                oyunalanimatris[Aoyuncu.xkonum, Aoyuncu.ykonum] = 3;
                            }
                            oyunalanimatris[Aoyuncu.xkonum, Aoyuncu.ykonum] = 3;
                            Aoyuncuyaz();
                            Thread.Sleep(200); this.Refresh();
                        }
                        if (Aoyuncu.ykonum > Aoyuncu.yhedef)
                        {
                            label[Aoyuncu.xkonum, Aoyuncu.ykonum].Text = "";
                            oyunalanimatris[Aoyuncu.xkonum, Aoyuncu.ykonum] = 0;
                            Aoyuncu.ykonum--;
                            label[Aoyuncu.xkonum, Aoyuncu.ykonum].Text = "A";
                            Aoyuncu.hamlesayisi++;
                            Aoyuncu.harcananaltin += girisekrani.hamlemaliyet;
                            Aoyuncu.kasaaltin -= girisekrani.hamlemaliyet;
                            label_Akasaaltin.Text = "A oyuncu :" + Aoyuncu.kasaaltin.ToString() + " Altın";
                            if (gizlialtinmatris[Aoyuncu.xkonum, Aoyuncu.ykonum + 1] == 1)
                            {
                                label[Aoyuncu.xkonum, Aoyuncu.ykonum + 1].BackColor = Color.GreenYellow;
                                label[Aoyuncu.xkonum, Aoyuncu.ykonum + 1].Text = altindegermatris[Aoyuncu.xkonum, Aoyuncu.ykonum + 1].ToString();
                                oyunalanimatris[Aoyuncu.xkonum, Aoyuncu.ykonum + 1] = 1;
                                gizlialtinmatris[Aoyuncu.xkonum, Aoyuncu.ykonum + 1] = 0;
                            }
                            if (oyunalanimatris[Aoyuncu.xkonum, Aoyuncu.ykonum] == 1)
                            {
                                Aoyuncu.toplananaltin += altindegermatris[Aoyuncu.xkonum, Aoyuncu.ykonum];
                                Aoyuncu.kasaaltin += altindegermatris[Aoyuncu.xkonum, Aoyuncu.ykonum];
                                label[Aoyuncu.xkonum, Aoyuncu.ykonum].BackColor = Color.LightGray;
                                Toplamaltin -= altindegermatris[Aoyuncu.xkonum, Aoyuncu.ykonum];
                                altindegermatris[Aoyuncu.xkonum, Aoyuncu.ykonum] = 0;
                                oyunalanimatris[Aoyuncu.xkonum, Aoyuncu.ykonum] = 3;
                            }
                            oyunalanimatris[Aoyuncu.xkonum, Aoyuncu.ykonum] = 3;
                            Aoyuncuyaz();
                            Thread.Sleep(200); this.Refresh();
                        }
                    }
                }

                xkoordinat = Aoyuncu.xkonum - Aoyuncu.xhedef;
                ykoordinat = Aoyuncu.ykonum - Aoyuncu.yhedef;
                if (xkoordinat < 0)
                {
                    xkoordinat *= -1;
                }
                if (ykoordinat < 0)
                {
                    ykoordinat *= -1;
                }

                if (xkoordinat == 0 && ykoordinat == 0) // hedefe vardığında yapılacak işlemler.
                {
                    label[Aoyuncu.xkonum, Aoyuncu.ykonum].Text = "A";
                    label[Aoyuncu.xkonum, Aoyuncu.ykonum].BackColor = Color.LightGray;
                    Aoyuncu.toplananaltin += altindegermatris[Aoyuncu.xkonum, Aoyuncu.ykonum];
                    Aoyuncu.kasaaltin += altindegermatris[Aoyuncu.xkonum, Aoyuncu.ykonum];
                    Toplamaltin -= altindegermatris[Aoyuncu.xkonum, Aoyuncu.ykonum];
                    label_Akasaaltin.Text = "A oyuncu :" + Aoyuncu.kasaaltin.ToString() + " Altın";
                    Thread.Sleep(200); this.Refresh();
                    oyunalanimatris[Aoyuncu.xkonum, Aoyuncu.ykonum] = 3;
                    altindegermatris[Aoyuncu.xkonum, Aoyuncu.ykonum] = 0;
                    Aoyuncu.xhedef = 0;
                    Aoyuncu.yhedef = 0;

                    if (Aoyuncu.xkonum == Boyuncu.xhedef && Aoyuncu.ykonum == Boyuncu.yhedef)
                    {
                        Boyuncu.xhedef = 0;
                        Boyuncu.yhedef = 0;
                    }
                    if (Aoyuncu.xkonum == Coyuncu.xhedef && Aoyuncu.ykonum == Coyuncu.yhedef)
                    {
                        Coyuncu.xhedef = 0;
                        Coyuncu.yhedef = 0;
                    }
                    if (Aoyuncu.xkonum == Doyuncu.xhedef && Aoyuncu.ykonum == Doyuncu.yhedef)
                    {
                        Doyuncu.xhedef = 0;
                        Doyuncu.yhedef = 0;
                    }

                    Aoyuncuyaz();
                }

            }

        }

        //*************B Oyuncu Kod kısmı

        public class Boyuncu
        {
            public static int xkonum { get; set; } = 0;
            public static int ykonum { get; set; } = girisekrani.alany - 1;
            public static int xhedef { get; set; } = 0;
            public static int yhedef { get; set; } = 0;
            public static int kasaaltin { get; set; } = girisekrani.kasaaltinmiktari;
            public static int hamlesayisi { get; set; } = 0;
            public static int harcananaltin { get; set; } = 0;
            public static int toplananaltin { get; set; } = 0;
            public static bool durumu { get; set; } = true;
        }

        public void Bhedefsec()
        {
            int maxuzaklik = Int16.MaxValue;

            if (Boyuncu.kasaaltin < girisekrani.Bhedefmaliyet || Toplamaltin <= 0)
            {
                Boyuncu.durumu = false;
            }

            if (Boyuncu.durumu != false)
            {
                if (Boyuncu.xhedef == 0 && Boyuncu.yhedef == 0)
                {
                    Boyuncu.kasaaltin -= girisekrani.Bhedefmaliyet;
                    Boyuncu.harcananaltin += girisekrani.Bhedefmaliyet;
                    label_Bkasaaltin.Text = "B oyuncu :" + Boyuncu.kasaaltin.ToString() + " Altın";

                }
                for (int i = 0; i <= oyunalanimatris.GetUpperBound(0); i++)
                {
                    for (int j = 0; j <= oyunalanimatris.GetUpperBound(1); j++)
                    {
                        if (oyunalanimatris[i, j] == 1)
                        {
                            int yoluzaklik = (Boyuncu.xkonum - i) + (Boyuncu.ykonum - j);
                            if (yoluzaklik < 0)
                            {
                                yoluzaklik *= -1;
                            }
                            if (yoluzaklik < 0)
                            {
                                yoluzaklik *= -1;
                            }

                            int yolmaliyet = ((yoluzaklik * girisekrani.hamlemaliyet) + girisekrani.Bhedefmaliyet) - altindegermatris[i, j];
                            if (yolmaliyet < maxuzaklik)
                            {
                                maxuzaklik = yolmaliyet;
                                Boyuncu.xhedef = i;
                                Boyuncu.yhedef = j;
                            }

                        }
                    }
                }
            }

        }

        public void Bhedefegit()
        {
            int xkoordinat = Boyuncu.xkonum - Boyuncu.xhedef;
            int ykoordinat = Boyuncu.ykonum - Boyuncu.yhedef;
            if (xkoordinat < 0)
            {
                xkoordinat *= -1;
            }
            if (ykoordinat < 0)
            {
                ykoordinat *= -1;
            }

            if (Boyuncu.kasaaltin < girisekrani.hamlemaliyet || Toplamaltin <= 0)
            {
                Boyuncu.durumu = false;
            }

            if (Boyuncu.durumu != false)
            {
                if (xkoordinat != 0)
                {
                    if (Boyuncu.xkonum < Boyuncu.xhedef)
                    {
                        label[Boyuncu.xkonum, Boyuncu.ykonum].Text = "";
                        oyunalanimatris[Boyuncu.xkonum, Boyuncu.ykonum] = 0;
                        Boyuncu.xkonum++;
                        label[Boyuncu.xkonum, Boyuncu.ykonum].Text = "B";
                        Boyuncu.hamlesayisi++;
                        Boyuncu.harcananaltin += girisekrani.hamlemaliyet;
                        Boyuncu.kasaaltin -= girisekrani.hamlemaliyet;
                        label_Bkasaaltin.Text = "B oyuncu :" + Boyuncu.kasaaltin.ToString() + " Altın";
                        if (gizlialtinmatris[Boyuncu.xkonum - 1, Boyuncu.ykonum] == 1)
                        {
                            label[Boyuncu.xkonum - 1, Boyuncu.ykonum].BackColor = Color.GreenYellow;
                            label[Boyuncu.xkonum - 1, Boyuncu.ykonum].Text = altindegermatris[Boyuncu.xkonum - 1, Boyuncu.ykonum].ToString();
                            oyunalanimatris[Boyuncu.xkonum - 1, Boyuncu.ykonum] = 1;
                            gizlialtinmatris[Boyuncu.xkonum - 1, Boyuncu.ykonum] = 0;
                        }
                        if (oyunalanimatris[Boyuncu.xkonum, Boyuncu.ykonum] == 1)
                        {
                            Boyuncu.toplananaltin += altindegermatris[Boyuncu.xkonum, Boyuncu.ykonum];
                            Boyuncu.kasaaltin += altindegermatris[Boyuncu.xkonum, Boyuncu.ykonum];
                            label[Boyuncu.xkonum, Boyuncu.ykonum].BackColor = Color.LightGray;
                            Toplamaltin -= altindegermatris[Boyuncu.xkonum, Boyuncu.ykonum];
                            altindegermatris[Boyuncu.xkonum, Boyuncu.ykonum] = 0;
                            oyunalanimatris[Boyuncu.xkonum, Boyuncu.ykonum] = 3;
                        }
                        oyunalanimatris[Boyuncu.xkonum, Boyuncu.ykonum] = 3;
                        Boyuncuyaz();
                        Thread.Sleep(200); this.Refresh();
                    }
                    if (Boyuncu.xkonum > Boyuncu.xhedef)
                    {
                        label[Boyuncu.xkonum, Boyuncu.ykonum].Text = "";
                        oyunalanimatris[Boyuncu.xkonum, Boyuncu.ykonum] = 0;
                        Boyuncu.xkonum--;
                        label[Boyuncu.xkonum, Boyuncu.ykonum].Text = "B";
                        Boyuncu.hamlesayisi++;
                        Boyuncu.harcananaltin += girisekrani.hamlemaliyet;
                        Boyuncu.kasaaltin -= girisekrani.hamlemaliyet;
                        label_Bkasaaltin.Text = "B oyuncu :" + Boyuncu.kasaaltin.ToString() + " Altın";
                        if (gizlialtinmatris[Boyuncu.xkonum + 1, Boyuncu.ykonum] == 1)
                        {
                            label[Boyuncu.xkonum + 1, Boyuncu.ykonum].BackColor = Color.GreenYellow;
                            label[Boyuncu.xkonum + 1, Boyuncu.ykonum].Text = altindegermatris[Boyuncu.xkonum + 1, Boyuncu.ykonum].ToString();
                            oyunalanimatris[Boyuncu.xkonum + 1, Boyuncu.ykonum] = 1;
                            gizlialtinmatris[Boyuncu.xkonum + 1, Boyuncu.ykonum] = 0;
                        }
                        if (oyunalanimatris[Boyuncu.xkonum, Boyuncu.ykonum] == 1)
                        {
                            Boyuncu.toplananaltin += altindegermatris[Boyuncu.xkonum, Boyuncu.ykonum];
                            Boyuncu.kasaaltin += altindegermatris[Boyuncu.xkonum, Boyuncu.ykonum];
                            label[Boyuncu.xkonum, Boyuncu.ykonum].BackColor = Color.LightGray;
                            Toplamaltin -= altindegermatris[Boyuncu.xkonum, Boyuncu.ykonum];
                            altindegermatris[Boyuncu.xkonum, Boyuncu.ykonum] = 0;
                            oyunalanimatris[Boyuncu.xkonum, Boyuncu.ykonum] = 3;
                        }
                        oyunalanimatris[Boyuncu.xkonum, Boyuncu.ykonum] = 3;
                        Boyuncuyaz();
                        Thread.Sleep(200); this.Refresh();
                    }
                }
                if (xkoordinat == 0)
                {
                    if (ykoordinat != 0)
                    {
                        if (Boyuncu.ykonum < Boyuncu.yhedef)
                        {
                            label[Boyuncu.xkonum, Boyuncu.ykonum].Text = "";
                            oyunalanimatris[Boyuncu.xkonum, Boyuncu.ykonum] = 0;
                            Boyuncu.ykonum++;
                            label[Boyuncu.xkonum, Boyuncu.ykonum].Text = "B";
                            Boyuncu.hamlesayisi++;
                            Boyuncu.harcananaltin += girisekrani.hamlemaliyet;
                            Boyuncu.kasaaltin -= girisekrani.hamlemaliyet;
                            label_Bkasaaltin.Text = "B oyuncu :" + Boyuncu.kasaaltin.ToString() + " Altın";
                            if (gizlialtinmatris[Boyuncu.xkonum, Boyuncu.ykonum - 1] == 1)
                            {
                                label[Boyuncu.xkonum, Boyuncu.ykonum - 1].BackColor = Color.GreenYellow;
                                label[Boyuncu.xkonum, Boyuncu.ykonum - 1].Text = altindegermatris[Boyuncu.xkonum, Boyuncu.ykonum - 1].ToString();
                                oyunalanimatris[Boyuncu.xkonum, Boyuncu.ykonum - 1] = 1;
                                gizlialtinmatris[Boyuncu.xkonum, Boyuncu.ykonum - 1] = 0;
                            }
                            if (oyunalanimatris[Boyuncu.xkonum, Boyuncu.ykonum] == 1)
                            {
                                Boyuncu.toplananaltin += altindegermatris[Boyuncu.xkonum, Boyuncu.ykonum];
                                Boyuncu.kasaaltin += altindegermatris[Boyuncu.xkonum, Boyuncu.ykonum];
                                label[Boyuncu.xkonum, Boyuncu.ykonum].BackColor = Color.LightGray;
                                Toplamaltin -= altindegermatris[Boyuncu.xkonum, Boyuncu.ykonum];
                                altindegermatris[Boyuncu.xkonum, Boyuncu.ykonum] = 0;
                                oyunalanimatris[Boyuncu.xkonum, Boyuncu.ykonum] = 3;
                            }
                            oyunalanimatris[Boyuncu.xkonum, Boyuncu.ykonum] = 3;
                            Boyuncuyaz();
                            Thread.Sleep(200); this.Refresh();
                        }
                        if (Boyuncu.ykonum > Boyuncu.yhedef)
                        {
                            label[Boyuncu.xkonum, Boyuncu.ykonum].Text = "";
                            oyunalanimatris[Boyuncu.xkonum, Boyuncu.ykonum] = 0;
                            Boyuncu.ykonum--;
                            label[Boyuncu.xkonum, Boyuncu.ykonum].Text = "B";
                            Boyuncu.hamlesayisi++;
                            Boyuncu.harcananaltin += girisekrani.hamlemaliyet;
                            Boyuncu.kasaaltin -= girisekrani.hamlemaliyet;
                            label_Bkasaaltin.Text = "B oyuncu :" + Boyuncu.kasaaltin.ToString() + " Altın";
                            if (gizlialtinmatris[Boyuncu.xkonum, Boyuncu.ykonum + 1] == 1)
                            {
                                label[Boyuncu.xkonum, Boyuncu.ykonum + 1].BackColor = Color.GreenYellow;
                                label[Boyuncu.xkonum, Boyuncu.ykonum + 1].Text = altindegermatris[Boyuncu.xkonum, Boyuncu.ykonum + 1].ToString();
                                oyunalanimatris[Boyuncu.xkonum, Boyuncu.ykonum + 1] = 1;
                                gizlialtinmatris[Boyuncu.xkonum, Boyuncu.ykonum + 1] = 0;
                            }
                            if (oyunalanimatris[Boyuncu.xkonum, Boyuncu.ykonum] == 1)
                            {
                                Boyuncu.toplananaltin += altindegermatris[Boyuncu.xkonum, Boyuncu.ykonum];
                                Boyuncu.kasaaltin += altindegermatris[Boyuncu.xkonum, Boyuncu.ykonum];
                                label[Boyuncu.xkonum, Boyuncu.ykonum].BackColor = Color.LightGray;
                                Toplamaltin -= altindegermatris[Boyuncu.xkonum, Boyuncu.ykonum];
                                altindegermatris[Boyuncu.xkonum, Boyuncu.ykonum] = 0;
                                oyunalanimatris[Boyuncu.xkonum, Boyuncu.ykonum] = 3;
                            }
                            oyunalanimatris[Boyuncu.xkonum, Boyuncu.ykonum] = 3;
                            Boyuncuyaz();
                            Thread.Sleep(200); this.Refresh();
                        }
                    }
                }

                xkoordinat = Boyuncu.xkonum - Boyuncu.xhedef;
                ykoordinat = Boyuncu.ykonum - Boyuncu.yhedef;
                if (xkoordinat < 0)
                {
                    xkoordinat *= -1;
                }
                if (ykoordinat < 0)
                {
                    ykoordinat *= -1;
                }

                if (xkoordinat == 0 && ykoordinat == 0)
                {
                    label[Boyuncu.xkonum, Boyuncu.ykonum].Text = "B";
                    label[Boyuncu.xkonum, Boyuncu.ykonum].BackColor = Color.LightGray;
                    Boyuncu.toplananaltin += altindegermatris[Boyuncu.xkonum, Boyuncu.ykonum];
                    Boyuncu.kasaaltin += altindegermatris[Boyuncu.xkonum, Boyuncu.ykonum];
                    Toplamaltin -= altindegermatris[Boyuncu.xkonum, Boyuncu.ykonum];
                    label_Bkasaaltin.Text = "B oyuncu :" + Boyuncu.kasaaltin.ToString() + " Altın";
                    Thread.Sleep(200); this.Refresh();
                    oyunalanimatris[Boyuncu.xkonum, Boyuncu.ykonum] = 3;
                    altindegermatris[Boyuncu.xkonum, Boyuncu.ykonum] = 0;
                    Boyuncu.xhedef = 0;
                    Boyuncu.yhedef = 0;

                    if (Boyuncu.xkonum == Aoyuncu.xhedef && Boyuncu.ykonum == Aoyuncu.yhedef)
                    {
                        Aoyuncu.xhedef = 0;
                        Aoyuncu.yhedef = 0;
                    }
                    if (Boyuncu.xkonum == Coyuncu.xhedef && Boyuncu.ykonum == Coyuncu.yhedef)
                    {
                        Coyuncu.xhedef = 0;
                        Coyuncu.yhedef = 0;
                    }
                    if (Boyuncu.xkonum == Doyuncu.xhedef && Boyuncu.ykonum == Doyuncu.yhedef)
                    {
                        Doyuncu.xhedef = 0;
                        Doyuncu.yhedef = 0;
                    }

                    Boyuncuyaz();
                }

            }
        }

        //************* C Oyuncu kod kısmı
        public class Coyuncu
        {
            public static int xkonum { get; set; } = girisekrani.alanx - 1;
            public static int ykonum { get; set; } = girisekrani.alany - 1;
            public static int xhedef { get; set; } = 0;
            public static int yhedef { get; set; } = 0;
            public static int kasaaltin { get; set; } = girisekrani.kasaaltinmiktari;
            public static int hamlesayisi { get; set; } = 0;
            public static int harcananaltin { get; set; } = 0;
            public static int toplananaltin { get; set; } = 0;
            public static bool durumu { get; set; } = true;
        }

        public void Chedefsec()
        {
            int a = girisekrani.gizlialtinacma;
            int b = Int16.MaxValue; int c = 0; int m = 0, n = 0;

            int maxuzaklik = Int16.MaxValue;

            if (Coyuncu.kasaaltin < girisekrani.Chedefmaliyet || Toplamaltin <= 0)
            {
                Coyuncu.durumu = false;
            }

            if (Coyuncu.durumu != false)
            {
                if (Coyuncu.xhedef == 0 && Coyuncu.yhedef == 0)
                {
                    //gizlialtın açma kodu
                    while (a > 0)
                    {
                        for (int i = 0; i <= oyunalanimatris.GetUpperBound(0); i++)
                        {
                            for (int j = 0; j <= oyunalanimatris.GetUpperBound(1); j++)
                            {
                                if (oyunalanimatris[i, j] == 2)
                                {
                                    int gizlialtinyol = Math.Abs(Coyuncu.xkonum - i) + Math.Abs(Coyuncu.ykonum - j);
                                    if (gizlialtinyol < b)
                                    {
                                        b = a; c = 1; m = i; n = j;
                                    }
                                }
                            }
                        }
                        if (c == 1)
                        {
                            oyunalanimatris[m, n] = 1;
                            gizlialtinmatris[m, n] = 0;
                            label[m, n].Text = altindegermatris[m, n].ToString();
                            label[m, n].BackColor = Color.GreenYellow;
                        }
                        else
                        {
                            //MessageBox.Show("Gizli altin yok");
                            break;
                        }
                        a--;
                    } //****


                    Coyuncu.kasaaltin -= girisekrani.Chedefmaliyet;
                    Coyuncu.harcananaltin += girisekrani.Chedefmaliyet;
                    label_Ckasaaltin.Text = "C oyuncu :" + Coyuncu.kasaaltin.ToString() + " Altın";

                }

                for (int i = 0; i <= oyunalanimatris.GetUpperBound(0); i++)
                {
                    for (int j = 0; j <= oyunalanimatris.GetUpperBound(1); j++)
                    {
                        if (oyunalanimatris[i, j] == 1)
                        {
                            int yoluzaklik = (Coyuncu.xkonum - i) + (Coyuncu.ykonum - j);
                            if (yoluzaklik < 0)
                            {
                                yoluzaklik *= -1;
                            }
                            if (yoluzaklik < 0)
                            {
                                yoluzaklik *= -1;
                            }

                            int yolmaliyet = ((yoluzaklik * girisekrani.hamlemaliyet) + girisekrani.Chedefmaliyet) - altindegermatris[i, j];
                            if (yolmaliyet < maxuzaklik)
                            {
                                maxuzaklik = yolmaliyet;
                                Coyuncu.xhedef = i;
                                Coyuncu.yhedef = j;
                            }

                        }
                    }
                }                
            }
        }

        public void Chedefegit()
        {
            int xkoordinat = Coyuncu.xkonum - Coyuncu.xhedef;
            int ykoordinat = Coyuncu.ykonum - Coyuncu.yhedef;
            if (xkoordinat < 0)
            {
                xkoordinat *= -1;
            }
            if (ykoordinat < 0)
            {
                ykoordinat *= -1;
            }

            if (Coyuncu.kasaaltin < girisekrani.hamlemaliyet || Toplamaltin <= 0)
            {
                Coyuncu.durumu = false;
            }

            if (Coyuncu.durumu != false)
            {
                if (xkoordinat != 0)
                {
                    if (Coyuncu.xkonum < Coyuncu.xhedef)
                    {
                        label[Coyuncu.xkonum, Coyuncu.ykonum].Text = "";
                        oyunalanimatris[Coyuncu.xkonum, Coyuncu.ykonum] = 0;
                        Coyuncu.xkonum++;
                        label[Coyuncu.xkonum, Coyuncu.ykonum].Text = "C";
                        Coyuncu.hamlesayisi++;
                        Coyuncu.harcananaltin += girisekrani.hamlemaliyet;
                        Coyuncu.kasaaltin -= girisekrani.hamlemaliyet;
                        label_Ckasaaltin.Text = "C oyuncu :" + Coyuncu.kasaaltin.ToString() + " Altın";
                        if (gizlialtinmatris[Coyuncu.xkonum - 1, Coyuncu.ykonum] == 1)
                        {
                            label[Coyuncu.xkonum - 1, Coyuncu.ykonum].BackColor = Color.GreenYellow;
                            label[Coyuncu.xkonum - 1, Coyuncu.ykonum].Text = altindegermatris[Coyuncu.xkonum - 1, Coyuncu.ykonum].ToString();
                            oyunalanimatris[Coyuncu.xkonum - 1, Coyuncu.ykonum] = 1;
                            gizlialtinmatris[Coyuncu.xkonum - 1, Coyuncu.ykonum] = 0;
                        }
                        if (oyunalanimatris[Coyuncu.xkonum, Coyuncu.ykonum] == 1)
                        {
                            Coyuncu.toplananaltin += altindegermatris[Coyuncu.xkonum, Coyuncu.ykonum];
                            Coyuncu.kasaaltin += altindegermatris[Coyuncu.xkonum, Coyuncu.ykonum];
                            label[Coyuncu.xkonum, Coyuncu.ykonum].BackColor = Color.LightGray;
                            Toplamaltin -= altindegermatris[Coyuncu.xkonum, Coyuncu.ykonum];
                            altindegermatris[Coyuncu.xkonum, Coyuncu.ykonum] = 0;
                            oyunalanimatris[Coyuncu.xkonum, Coyuncu.ykonum] = 3;
                        }
                        oyunalanimatris[Coyuncu.xkonum, Coyuncu.ykonum] = 3;
                        Coyuncuyaz();
                        Thread.Sleep(200); this.Refresh();
                    }
                    if (Coyuncu.xkonum > Coyuncu.xhedef)
                    {
                        label[Coyuncu.xkonum, Coyuncu.ykonum].Text = "";
                        oyunalanimatris[Coyuncu.xkonum, Coyuncu.ykonum] = 0;
                        Coyuncu.xkonum--;
                        label[Coyuncu.xkonum, Coyuncu.ykonum].Text = "C";
                        Coyuncu.hamlesayisi++;
                        Coyuncu.harcananaltin += girisekrani.hamlemaliyet;
                        Coyuncu.kasaaltin -= girisekrani.hamlemaliyet;
                        label_Ckasaaltin.Text = "C oyuncu :" + Coyuncu.kasaaltin.ToString() + " Altın";
                        if (gizlialtinmatris[Coyuncu.xkonum + 1, Coyuncu.ykonum] == 1)
                        {
                            label[Coyuncu.xkonum + 1, Coyuncu.ykonum].BackColor = Color.GreenYellow;
                            label[Coyuncu.xkonum + 1, Coyuncu.ykonum].Text = altindegermatris[Coyuncu.xkonum + 1, Coyuncu.ykonum].ToString();
                            oyunalanimatris[Coyuncu.xkonum + 1, Coyuncu.ykonum] = 1;
                            gizlialtinmatris[Coyuncu.xkonum + 1, Coyuncu.ykonum] = 0;
                        }
                        if (oyunalanimatris[Coyuncu.xkonum, Coyuncu.ykonum] == 1)
                        {
                            Coyuncu.toplananaltin += altindegermatris[Coyuncu.xkonum, Coyuncu.ykonum];
                            Coyuncu.kasaaltin += altindegermatris[Coyuncu.xkonum, Coyuncu.ykonum];
                            label[Coyuncu.xkonum, Coyuncu.ykonum].BackColor = Color.LightGray;
                            Toplamaltin -= altindegermatris[Coyuncu.xkonum, Coyuncu.ykonum];
                            altindegermatris[Coyuncu.xkonum, Coyuncu.ykonum] = 0;
                            oyunalanimatris[Coyuncu.xkonum, Coyuncu.ykonum] = 3;
                        }
                        oyunalanimatris[Coyuncu.xkonum, Coyuncu.ykonum] = 3;
                        Coyuncuyaz();
                        Thread.Sleep(200); this.Refresh();
                    }
                }
                if (xkoordinat == 0)
                {
                    if (ykoordinat != 0)
                    {
                        if (Coyuncu.ykonum < Coyuncu.yhedef)
                        {
                            label[Coyuncu.xkonum, Coyuncu.ykonum].Text = "";
                            oyunalanimatris[Coyuncu.xkonum, Coyuncu.ykonum] = 0;
                            Coyuncu.ykonum++;
                            label[Coyuncu.xkonum, Coyuncu.ykonum].Text = "C";
                            Coyuncu.hamlesayisi++;
                            Coyuncu.harcananaltin += girisekrani.hamlemaliyet;
                            Coyuncu.kasaaltin -= girisekrani.hamlemaliyet;
                            label_Ckasaaltin.Text = "C oyuncu :" + Coyuncu.kasaaltin.ToString() + " Altın";
                            if (gizlialtinmatris[Coyuncu.xkonum, Coyuncu.ykonum - 1] == 1)
                            {
                                label[Coyuncu.xkonum, Coyuncu.ykonum - 1].BackColor = Color.GreenYellow;
                                label[Coyuncu.xkonum, Coyuncu.ykonum - 1].Text = altindegermatris[Coyuncu.xkonum, Coyuncu.ykonum - 1].ToString();
                                oyunalanimatris[Coyuncu.xkonum, Coyuncu.ykonum - 1] = 1;
                                gizlialtinmatris[Coyuncu.xkonum, Coyuncu.ykonum - 1] = 0;
                            }
                            if (oyunalanimatris[Coyuncu.xkonum, Coyuncu.ykonum] == 1)
                            {
                                Coyuncu.toplananaltin += altindegermatris[Coyuncu.xkonum, Coyuncu.ykonum];
                                Coyuncu.kasaaltin += altindegermatris[Coyuncu.xkonum, Coyuncu.ykonum];
                                label[Coyuncu.xkonum, Coyuncu.ykonum].BackColor = Color.LightGray;
                                Toplamaltin -= altindegermatris[Coyuncu.xkonum, Coyuncu.ykonum];
                                altindegermatris[Coyuncu.xkonum, Coyuncu.ykonum] = 0;
                                oyunalanimatris[Coyuncu.xkonum, Coyuncu.ykonum] = 3;
                            }
                            oyunalanimatris[Coyuncu.xkonum, Coyuncu.ykonum] = 3;
                            Coyuncuyaz();
                            Thread.Sleep(200); this.Refresh();
                        }
                        if (Coyuncu.ykonum > Coyuncu.yhedef)
                        {
                            label[Coyuncu.xkonum, Coyuncu.ykonum].Text = "";
                            oyunalanimatris[Coyuncu.xkonum, Coyuncu.ykonum] = 0;
                            Coyuncu.ykonum--;
                            label[Coyuncu.xkonum, Coyuncu.ykonum].Text = "C";
                            Coyuncu.hamlesayisi++;
                            Coyuncu.harcananaltin += girisekrani.hamlemaliyet;
                            Coyuncu.kasaaltin -= girisekrani.hamlemaliyet;
                            label_Ckasaaltin.Text = "C oyuncu :" + Coyuncu.kasaaltin.ToString() + " Altın";
                            if (gizlialtinmatris[Coyuncu.xkonum, Coyuncu.ykonum + 1] == 1)
                            {
                                label[Coyuncu.xkonum, Coyuncu.ykonum + 1].BackColor = Color.GreenYellow;
                                label[Coyuncu.xkonum, Coyuncu.ykonum + 1].Text = altindegermatris[Coyuncu.xkonum, Coyuncu.ykonum + 1].ToString();
                                oyunalanimatris[Coyuncu.xkonum, Coyuncu.ykonum + 1] = 1;
                                gizlialtinmatris[Coyuncu.xkonum, Coyuncu.ykonum + 1] = 0;
                            }
                            if (oyunalanimatris[Coyuncu.xkonum, Coyuncu.ykonum] == 1)
                            {
                                Coyuncu.toplananaltin += altindegermatris[Coyuncu.xkonum, Coyuncu.ykonum];
                                Coyuncu.kasaaltin += altindegermatris[Coyuncu.xkonum, Coyuncu.ykonum];
                                label[Coyuncu.xkonum, Coyuncu.ykonum].BackColor = Color.LightGray;
                                Toplamaltin -= altindegermatris[Coyuncu.xkonum, Coyuncu.ykonum];
                                altindegermatris[Coyuncu.xkonum, Coyuncu.ykonum] = 0;
                                oyunalanimatris[Coyuncu.xkonum, Coyuncu.ykonum] = 3;
                            }
                            oyunalanimatris[Coyuncu.xkonum, Coyuncu.ykonum] = 3;
                            Coyuncuyaz();
                            Thread.Sleep(200); this.Refresh();
                        }
                    }
                }

                xkoordinat = Coyuncu.xkonum - Coyuncu.xhedef;
                ykoordinat = Coyuncu.ykonum - Coyuncu.yhedef;
                if (xkoordinat < 0)
                {
                    xkoordinat *= -1;
                }
                if (ykoordinat < 0)
                {
                    ykoordinat *= -1;
                }

                if (xkoordinat == 0 && ykoordinat == 0)
                {
                    label[Coyuncu.xkonum, Coyuncu.ykonum].Text = "C";
                    label[Coyuncu.xkonum, Coyuncu.ykonum].BackColor = Color.LightGray;

                    Coyuncu.toplananaltin += altindegermatris[Coyuncu.xkonum, Coyuncu.ykonum];
                    Coyuncu.kasaaltin += altindegermatris[Coyuncu.xkonum, Coyuncu.ykonum];
                    Toplamaltin -= altindegermatris[Coyuncu.xkonum, Coyuncu.ykonum];
                    label_Ckasaaltin.Text = "C oyuncu :" + Coyuncu.kasaaltin.ToString() + " Altın";
                    Thread.Sleep(200); this.Refresh();

                    oyunalanimatris[Coyuncu.xkonum, Coyuncu.ykonum] = 3;
                    altindegermatris[Coyuncu.xkonum, Coyuncu.ykonum] = 0;
                    Coyuncu.xhedef = 0;
                    Coyuncu.yhedef = 0;

                    if (Coyuncu.xkonum == Aoyuncu.xhedef && Coyuncu.ykonum == Aoyuncu.yhedef)
                    {
                        Aoyuncu.xhedef = 0;
                        Aoyuncu.yhedef = 0;
                    }
                    if (Coyuncu.xkonum == Boyuncu.xhedef && Coyuncu.ykonum == Boyuncu.yhedef)
                    {
                        Boyuncu.xhedef = 0;
                        Boyuncu.yhedef = 0;
                    }
                    if (Coyuncu.xkonum == Doyuncu.xhedef && Coyuncu.ykonum == Doyuncu.yhedef)
                    {
                        Doyuncu.xhedef = 0;
                        Doyuncu.yhedef = 0;
                    }

                    Coyuncuyaz();
                }

            }

        }

        //******** D Oyuncu kod kısmı

        public class Doyuncu
        {
            public static int xkonum { get; set; } = girisekrani.alanx - 1;
            public static int ykonum { get; set; } = 0;
            public static int xhedef { get; set; } = 0;
            public static int yhedef { get; set; } = 0;
            public static int kasaaltin { get; set; } = girisekrani.kasaaltinmiktari;
            public static int hamlesayisi { get; set; } = 0;
            public static int harcananaltin { get; set; } = 0;
            public static int toplananaltin { get; set; } = 0;
            public static bool durumu { get; set; } = true;
        }

        public void Dhedefsec()
        {
            int maxuzaklik = Int16.MaxValue; bool dyetenek = false;

            if (Doyuncu.kasaaltin < girisekrani.Dhedefmaliyet || Toplamaltin <= 0)
            {
                Doyuncu.durumu = false;
            }

            if (Doyuncu.durumu != false)
            {
                if (Doyuncu.xhedef == 0 && Doyuncu.yhedef == 0)
                {
                    Doyuncu.kasaaltin -= girisekrani.Dhedefmaliyet;
                    Doyuncu.harcananaltin += girisekrani.Dhedefmaliyet;
                    label_Dkasaaltin.Text = "D oyuncu :" + Doyuncu.kasaaltin.ToString() + " Altın";

                }
                //Aoyuncu hedefini kontrol eder
                int ahedefi = (Aoyuncu.xkonum - Aoyuncu.xhedef) + (Aoyuncu.ykonum - Aoyuncu.yhedef);
                if (ahedefi < 0)
                {
                    ahedefi *= -1;
                }
                if (ahedefi < 0)
                {
                    ahedefi *= -1;
                }

                int a_d_hedefi = (Doyuncu.xkonum - Aoyuncu.xhedef) +(Doyuncu.ykonum - Aoyuncu.yhedef);
                if (a_d_hedefi < 0)
                {
                    a_d_hedefi *= -1;
                }
                if (a_d_hedefi < 0)
                {
                    a_d_hedefi *= -1;
                }
                //Boyuncu hedefini kontrol eder
                int bhedefi = (Boyuncu.xkonum - Boyuncu.xhedef) + (Boyuncu.ykonum - Boyuncu.yhedef);
                if (bhedefi < 0)
                {
                    bhedefi *= -1;
                }
                if (bhedefi < 0)
                {
                    bhedefi *= -1;
                }
                int b_d_hedefi = (Doyuncu.xkonum - Boyuncu.xhedef) + (Doyuncu.ykonum - Boyuncu.yhedef);
                if (b_d_hedefi < 0)
                {
                    b_d_hedefi *= -1;
                }
                if (b_d_hedefi < 0)
                {
                    b_d_hedefi *= -1;
                }
                //Coyuncu hedefini kontrol eder
                int chedefi = (Coyuncu.xkonum - Coyuncu.xhedef) + (Coyuncu.ykonum - Coyuncu.yhedef);
                if (chedefi < 0)
                {
                    chedefi *= -1;
                }
                if (chedefi < 0)
                {
                    chedefi *= -1;
                }
                int c_d_hedefi = (Doyuncu.xkonum - Aoyuncu.xhedef) + (Doyuncu.ykonum - Aoyuncu.yhedef);
                if (c_d_hedefi < 0)
                {
                    c_d_hedefi *= -1;
                }
                if (c_d_hedefi < 0)
                {
                    c_d_hedefi *= -1;
                }

                if (a_d_hedefi < ahedefi && Aoyuncu.xhedef != 0 && Aoyuncu.yhedef != 0)
                {
                    dyetenek = true;
                }
                else if (b_d_hedefi < bhedefi && Boyuncu.xhedef != 0 && Boyuncu.yhedef != 0)
                {
                    dyetenek = true;
                }
                else if (c_d_hedefi < chedefi && Coyuncu.xhedef != 0 && Coyuncu.yhedef != 0)
                {
                    dyetenek = true;
                }
                else
                {
                    dyetenek = false; //MessageBox.Show("D oyuncusu diğer oyuncuların hedeflerine yakın değil");
                }

                if (dyetenek == true)
                {
                    if (a_d_hedefi < b_d_hedefi || a_d_hedefi < c_d_hedefi)
                    {
                        Doyuncu.xhedef = Aoyuncu.xhedef;
                        Doyuncu.yhedef = Aoyuncu.yhedef;
                        //MessageBox.Show("D oyuncusu A oyuncunun hedefini daha önce alır");
                        
                    }
                    if (b_d_hedefi < a_d_hedefi || b_d_hedefi < c_d_hedefi)
                    {
                        Doyuncu.xhedef = Boyuncu.xhedef;
                        Doyuncu.yhedef = Boyuncu.yhedef;
                        //MessageBox.Show("D oyuncusu B oyuncunun hedefini daha önce alır");
                       
                    }
                    if (c_d_hedefi < a_d_hedefi || c_d_hedefi < b_d_hedefi)
                    {
                        Doyuncu.xhedef = Coyuncu.xhedef;
                        Doyuncu.yhedef = Coyuncu.yhedef;
                        // MessageBox.Show("D oyuncusu C oyuncunun hedefini daha önce alır");
                        
                    }
                }
                if (dyetenek == false)
                {
                    for (int i = 0; i <= oyunalanimatris.GetUpperBound(0); i++)
                    {
                        for (int j = 0; j <= oyunalanimatris.GetUpperBound(1); j++)
                        {
                            if (oyunalanimatris[i, j] == 1)
                            {
                                int yoluzaklik = (Doyuncu.xkonum - i) + (Doyuncu.ykonum - j);
                                if (yoluzaklik < 0)
                                {
                                    yoluzaklik *= -1;
                                }
                                if (yoluzaklik < 0)
                                {
                                    yoluzaklik *= -1;
                                }
                                int yolmaliyet = ((yoluzaklik * girisekrani.hamlemaliyet) + girisekrani.Dhedefmaliyet) - altindegermatris[i, j];
                                if (yolmaliyet < maxuzaklik)
                                {
                                    maxuzaklik = yolmaliyet;
                                    if (Aoyuncu.xhedef != i && Aoyuncu.yhedef != j
                                            || Boyuncu.xhedef != i && Boyuncu.yhedef != j
                                                || Coyuncu.xhedef != i && Coyuncu.yhedef != j)
                                    {
                                        Doyuncu.xhedef = i;
                                        Doyuncu.yhedef = j;
                                    }

                                }

                            }
                        }
                    }                    
                }

            }
        }

        public void Dhedefegit()
        {
            int xkoordinat = Doyuncu.xkonum - Doyuncu.xhedef;
            int ykoordinat = Doyuncu.ykonum - Doyuncu.yhedef;
            if (xkoordinat < 0)
            {
                xkoordinat *= -1;
            }
            if (ykoordinat < 0)
            {
                ykoordinat *= -1;
            }

            if (Doyuncu.kasaaltin < girisekrani.hamlemaliyet || Toplamaltin <= 0)
            {
                Doyuncu.durumu = false;
            }


            if (Doyuncu.durumu != false)
            {
                if (xkoordinat != 0)
                {
                    if (Doyuncu.xkonum < Doyuncu.xhedef)
                    {
                        label[Doyuncu.xkonum, Doyuncu.ykonum].Text = "";
                        oyunalanimatris[Doyuncu.xkonum, Doyuncu.ykonum] = 0;
                        Doyuncu.xkonum++;
                        label[Doyuncu.xkonum, Doyuncu.ykonum].Text = "D";
                        Doyuncu.hamlesayisi++;
                        Doyuncu.harcananaltin += girisekrani.hamlemaliyet;
                        Doyuncu.kasaaltin -= girisekrani.hamlemaliyet;
                        label_Dkasaaltin.Text = "D oyuncu :" + Doyuncu.kasaaltin.ToString() + " Altın";
                        if (gizlialtinmatris[Doyuncu.xkonum - 1, Doyuncu.ykonum] == 1)
                        {
                            label[Doyuncu.xkonum - 1, Doyuncu.ykonum].BackColor = Color.GreenYellow;
                            label[Doyuncu.xkonum - 1, Doyuncu.ykonum].Text = altindegermatris[Doyuncu.xkonum - 1, Doyuncu.ykonum].ToString();
                            oyunalanimatris[Doyuncu.xkonum - 1, Doyuncu.ykonum] = 1;
                            gizlialtinmatris[Doyuncu.xkonum - 1, Doyuncu.ykonum] = 0;
                        }
                        if (oyunalanimatris[Doyuncu.xkonum, Doyuncu.ykonum] == 1)
                        {
                            Doyuncu.toplananaltin += altindegermatris[Doyuncu.xkonum, Doyuncu.ykonum];
                            Doyuncu.kasaaltin += altindegermatris[Doyuncu.xkonum, Doyuncu.ykonum];
                            label[Doyuncu.xkonum, Doyuncu.ykonum].BackColor = Color.LightGray;
                            Toplamaltin -= altindegermatris[Doyuncu.xkonum, Doyuncu.ykonum];
                            altindegermatris[Doyuncu.xkonum, Doyuncu.ykonum] = 0;
                            oyunalanimatris[Doyuncu.xkonum, Doyuncu.ykonum] = 3;
                        }
                        oyunalanimatris[Doyuncu.xkonum, Doyuncu.ykonum] = 3;
                        Doyuncuyaz();
                        Thread.Sleep(200); this.Refresh();
                    }
                    if (Doyuncu.xkonum > Doyuncu.xhedef)
                    {
                        label[Doyuncu.xkonum, Doyuncu.ykonum].Text = "";
                        oyunalanimatris[Doyuncu.xkonum, Doyuncu.ykonum] = 0;
                        Doyuncu.xkonum--;
                        label[Doyuncu.xkonum, Doyuncu.ykonum].Text = "D";
                        Doyuncu.hamlesayisi++;
                        Doyuncu.harcananaltin += girisekrani.hamlemaliyet;
                        Doyuncu.kasaaltin -= girisekrani.hamlemaliyet;
                        label_Dkasaaltin.Text = "D oyuncu :" + Doyuncu.kasaaltin.ToString() + " Altın";
                        if (gizlialtinmatris[Doyuncu.xkonum + 1, Doyuncu.ykonum] == 1)
                        {
                            label[Doyuncu.xkonum + 1, Doyuncu.ykonum].BackColor = Color.GreenYellow;
                            label[Doyuncu.xkonum + 1, Doyuncu.ykonum].Text = altindegermatris[Doyuncu.xkonum + 1, Doyuncu.ykonum].ToString();
                            oyunalanimatris[Doyuncu.xkonum + 1, Doyuncu.ykonum] = 1;
                            gizlialtinmatris[Doyuncu.xkonum + 1, Doyuncu.ykonum] = 0;
                        }
                        if (oyunalanimatris[Doyuncu.xkonum, Doyuncu.ykonum] == 1)
                        {
                            Doyuncu.toplananaltin += altindegermatris[Doyuncu.xkonum, Doyuncu.ykonum];
                            Doyuncu.kasaaltin += altindegermatris[Doyuncu.xkonum, Doyuncu.ykonum];
                            label[Doyuncu.xkonum, Doyuncu.ykonum].BackColor = Color.LightGray;
                            Toplamaltin -= altindegermatris[Doyuncu.xkonum, Doyuncu.ykonum];
                            altindegermatris[Doyuncu.xkonum, Doyuncu.ykonum] = 0;
                            oyunalanimatris[Doyuncu.xkonum, Doyuncu.ykonum] = 3;
                        }
                        oyunalanimatris[Doyuncu.xkonum, Doyuncu.ykonum] = 3;
                        Doyuncuyaz();
                        Thread.Sleep(200); this.Refresh();
                    }
                }
                if (xkoordinat == 0)
                {
                    if (ykoordinat != 0)
                    {
                        if (Doyuncu.ykonum < Doyuncu.yhedef)
                        {
                            label[Doyuncu.xkonum, Doyuncu.ykonum].Text = "";
                            oyunalanimatris[Doyuncu.xkonum, Doyuncu.ykonum] = 0;
                            Doyuncu.ykonum++;
                            label[Doyuncu.xkonum, Doyuncu.ykonum].Text = "D";
                            Doyuncu.hamlesayisi++;
                            Doyuncu.harcananaltin += girisekrani.hamlemaliyet;
                            Doyuncu.kasaaltin -= girisekrani.hamlemaliyet;
                            label_Dkasaaltin.Text = "D oyuncu :" + Doyuncu.kasaaltin.ToString() + " Altın";
                            if (gizlialtinmatris[Doyuncu.xkonum, Doyuncu.ykonum - 1] == 1)
                            {
                                label[Doyuncu.xkonum, Doyuncu.ykonum - 1].BackColor = Color.GreenYellow;
                                label[Doyuncu.xkonum, Doyuncu.ykonum - 1].Text = altindegermatris[Doyuncu.xkonum, Doyuncu.ykonum - 1].ToString();
                                oyunalanimatris[Doyuncu.xkonum, Doyuncu.ykonum - 1] = 1;
                                gizlialtinmatris[Doyuncu.xkonum, Doyuncu.ykonum - 1] = 0;
                            }
                            if (oyunalanimatris[Doyuncu.xkonum, Doyuncu.ykonum] == 1)
                            {
                                Doyuncu.toplananaltin += altindegermatris[Doyuncu.xkonum, Doyuncu.ykonum];
                                Doyuncu.kasaaltin += altindegermatris[Doyuncu.xkonum, Doyuncu.ykonum];
                                label[Doyuncu.xkonum, Doyuncu.ykonum].BackColor = Color.LightGray;
                                Toplamaltin -= altindegermatris[Doyuncu.xkonum, Doyuncu.ykonum];
                                altindegermatris[Doyuncu.xkonum, Doyuncu.ykonum] = 0;
                                oyunalanimatris[Doyuncu.xkonum, Doyuncu.ykonum] = 3;
                            }
                            oyunalanimatris[Doyuncu.xkonum, Doyuncu.ykonum] = 3;
                            Doyuncuyaz();
                            Thread.Sleep(200); this.Refresh();
                        }
                        if (Doyuncu.ykonum > Doyuncu.yhedef)
                        {
                            label[Doyuncu.xkonum, Doyuncu.ykonum].Text = "";
                            oyunalanimatris[Doyuncu.xkonum, Doyuncu.ykonum] = 0;
                            Doyuncu.ykonum--;
                            label[Doyuncu.xkonum, Doyuncu.ykonum].Text = "D";
                            Doyuncu.hamlesayisi++;
                            Doyuncu.harcananaltin += girisekrani.hamlemaliyet;
                            Doyuncu.kasaaltin -= girisekrani.hamlemaliyet;
                            label_Dkasaaltin.Text = "D oyuncu :" + Doyuncu.kasaaltin.ToString() + " Altın";
                            if (gizlialtinmatris[Doyuncu.xkonum, Doyuncu.ykonum + 1] == 1)
                            {
                                label[Doyuncu.xkonum, Doyuncu.ykonum + 1].BackColor = Color.GreenYellow;
                                label[Doyuncu.xkonum, Doyuncu.ykonum + 1].Text = altindegermatris[Doyuncu.xkonum, Doyuncu.ykonum + 1].ToString();
                                oyunalanimatris[Doyuncu.xkonum, Doyuncu.ykonum + 1] = 1;
                                gizlialtinmatris[Doyuncu.xkonum, Doyuncu.ykonum + 1] = 0;
                            }
                            if (oyunalanimatris[Doyuncu.xkonum, Doyuncu.ykonum] == 1)
                            {
                                Doyuncu.toplananaltin += altindegermatris[Doyuncu.xkonum, Doyuncu.ykonum];
                                Doyuncu.kasaaltin += altindegermatris[Doyuncu.xkonum, Doyuncu.ykonum];
                                label[Doyuncu.xkonum, Doyuncu.ykonum].BackColor = Color.LightGray;
                                Toplamaltin -= altindegermatris[Doyuncu.xkonum, Doyuncu.ykonum];
                                altindegermatris[Doyuncu.xkonum, Doyuncu.ykonum] = 0;
                                oyunalanimatris[Doyuncu.xkonum, Doyuncu.ykonum] = 3;
                            }
                            oyunalanimatris[Doyuncu.xkonum, Doyuncu.ykonum] = 3;
                            Doyuncuyaz();
                            Thread.Sleep(200); this.Refresh();
                        }
                    }
                }

                xkoordinat = Doyuncu.xkonum - Doyuncu.xhedef;
                ykoordinat = Doyuncu.ykonum - Doyuncu.yhedef;
                if (xkoordinat < 0)
                {
                    xkoordinat *= -1;
                }
                if (ykoordinat < 0)
                {
                    ykoordinat *= -1;
                }

                if (xkoordinat == 0 && ykoordinat == 0)
                {
                    label[Doyuncu.xkonum, Doyuncu.ykonum].Text = "D";
                    label[Doyuncu.xkonum, Doyuncu.ykonum].BackColor = Color.LightGray;

                    Doyuncu.toplananaltin += altindegermatris[Doyuncu.xkonum, Doyuncu.ykonum];
                    Doyuncu.kasaaltin += altindegermatris[Doyuncu.xkonum, Doyuncu.ykonum];
                    Toplamaltin -= altindegermatris[Doyuncu.xkonum, Doyuncu.ykonum];
                    label_Dkasaaltin.Text = "D oyuncu :" + Doyuncu.kasaaltin.ToString() + " Altın";
                    Thread.Sleep(200); this.Refresh();

                    oyunalanimatris[Doyuncu.xkonum, Doyuncu.ykonum] = 3;
                    altindegermatris[Doyuncu.xkonum, Doyuncu.ykonum] = 0;
                    Doyuncu.xhedef = 0;
                    Doyuncu.yhedef = 0;

                    if (Doyuncu.xkonum == Aoyuncu.xhedef && Doyuncu.ykonum == Aoyuncu.yhedef)
                    {
                        Aoyuncu.xhedef = 0;
                        Aoyuncu.yhedef = 0;
                    }
                    if (Doyuncu.xkonum == Boyuncu.xhedef && Doyuncu.ykonum == Boyuncu.yhedef)
                    {
                        Boyuncu.xhedef = 0;
                        Boyuncu.yhedef = 0;
                    }
                    if (Doyuncu.xkonum == Coyuncu.xhedef && Doyuncu.ykonum == Coyuncu.yhedef)
                    {
                        Coyuncu.xhedef = 0;
                        Coyuncu.yhedef = 0;
                    }
                    Doyuncuyaz();

                }

            }

        }
        //**********

        public void Aoyuncuyaz()
        {
            StreamWriter sw = new StreamWriter(@"A.txt", true);

            try
            {
                sw.Write("******************");
                sw.WriteLine();
                for (int i = 0; i < girisekrani.alanx; i++)
                {
                    for (int j = 0; j < girisekrani.alany; j++)
                    {
                        sw.Write(oyunalanimatris[i, j].ToString() + "0");
                    }
                    sw.WriteLine();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hata!!" + ex);
            }

            sw.Flush();
            sw.Close();

        }

        //***********
        public void Boyuncuyaz()
        {
            StreamWriter sw = new StreamWriter(@"B.txt", true);

            try
            {
                sw.Write("******************");
                sw.WriteLine();
                for (int i = 0; i < girisekrani.alanx; i++)
                {
                    for (int j = 0; j < girisekrani.alany; j++)
                    {
                        sw.Write(oyunalanimatris[i, j].ToString());
                    }
                    sw.WriteLine();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hata!!" + ex);
            }

            sw.Flush();
            sw.Close();

        }
        //**********
        public void Coyuncuyaz()
        {
            StreamWriter sw = new StreamWriter(@"C.txt", true);

            try
            {
                sw.Write("******************");
                sw.WriteLine();
                for (int i = 0; i < girisekrani.alanx; i++)
                {
                    for (int j = 0; j < girisekrani.alany; j++)
                    {
                        sw.Write(oyunalanimatris[i, j].ToString());
                    }
                    sw.WriteLine();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hata!!" + ex);
            }
            sw.Flush();
            sw.Close();

        }
        //*************
        public void Doyuncuyaz()
        {
            StreamWriter sw = new StreamWriter(@"D.txt", true);

            try
            {
                sw.Write("******************");
                sw.WriteLine();
                for (int i = 0; i < girisekrani.alanx; i++)
                {
                    for (int j = 0; j < girisekrani.alany; j++)
                    {
                        sw.Write(oyunalanimatris[i, j].ToString());
                    }
                    sw.WriteLine();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hata!!" + ex);
            }
            sw.Flush();
            sw.Close();

        }
        //**********
    }
}
