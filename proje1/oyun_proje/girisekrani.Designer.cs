namespace oyun_proje
{
    partial class girisekrani
    {
        /// <summary>
        ///Gerekli tasarımcı değişkeni.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///Kullanılan tüm kaynakları temizleyin.
        /// </summary>
        ///<param name="disposing">yönetilen kaynaklar dispose edilmeliyse doğru; aksi halde yanlış.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer üretilen kod

        /// <summary>
        /// Tasarımcı desteği için gerekli metot - bu metodun 
        ///içeriğini kod düzenleyici ile değiştirmeyin.
        /// </summary>
        private void InitializeComponent()
        {
            this.button_basla = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.textbox_Dhedefmaliyet = new System.Windows.Forms.TextBox();
            this.label_Dhedefmaliyet = new System.Windows.Forms.Label();
            this.textbox_Chedefmaliyet = new System.Windows.Forms.TextBox();
            this.label_Chedefmaliyet = new System.Windows.Forms.Label();
            this.textbox_Bhedefmaliyet = new System.Windows.Forms.TextBox();
            this.label_Bhedefmaliyet = new System.Windows.Forms.Label();
            this.textbox_Ahedefmaliyet = new System.Windows.Forms.TextBox();
            this.label_Ahedefmaliyet = new System.Windows.Forms.Label();
            this.textbox_gizlialtinacma = new System.Windows.Forms.TextBox();
            this.label_gizlialtinacma = new System.Windows.Forms.Label();
            this.textbox_kasaaltindegeri = new System.Windows.Forms.TextBox();
            this.label_kasaaltinmiktar = new System.Windows.Forms.Label();
            this.textbox_hamlesayisi = new System.Windows.Forms.TextBox();
            this.label_hamlesayisi = new System.Windows.Forms.Label();
            this.textbox_hamleucret = new System.Windows.Forms.TextBox();
            this.label_hamlemaliyet = new System.Windows.Forms.Label();
            this.textbox_gizlialtinoran = new System.Windows.Forms.TextBox();
            this.label_gizlialtinoran = new System.Windows.Forms.Label();
            this.textbox_altinorani = new System.Windows.Forms.TextBox();
            this.label_altinoran = new System.Windows.Forms.Label();
            this.textbox_alany = new System.Windows.Forms.TextBox();
            this.label_alany = new System.Windows.Forms.Label();
            this.textbox_alanx = new System.Windows.Forms.TextBox();
            this.label_alanx = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.button_exit = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // button_basla
            // 
            this.button_basla.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.button_basla.Location = new System.Drawing.Point(96, 334);
            this.button_basla.Name = "button_basla";
            this.button_basla.Size = new System.Drawing.Size(88, 36);
            this.button_basla.TabIndex = 3;
            this.button_basla.Text = "Başla";
            this.button_basla.UseVisualStyleBackColor = false;
            this.button_basla.Click += new System.EventHandler(this.button_basla_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.textbox_Dhedefmaliyet);
            this.groupBox1.Controls.Add(this.label_Dhedefmaliyet);
            this.groupBox1.Controls.Add(this.textbox_Chedefmaliyet);
            this.groupBox1.Controls.Add(this.label_Chedefmaliyet);
            this.groupBox1.Controls.Add(this.textbox_Bhedefmaliyet);
            this.groupBox1.Controls.Add(this.label_Bhedefmaliyet);
            this.groupBox1.Controls.Add(this.textbox_Ahedefmaliyet);
            this.groupBox1.Controls.Add(this.label_Ahedefmaliyet);
            this.groupBox1.Controls.Add(this.textbox_gizlialtinacma);
            this.groupBox1.Controls.Add(this.label_gizlialtinacma);
            this.groupBox1.Controls.Add(this.textbox_kasaaltindegeri);
            this.groupBox1.Controls.Add(this.label_kasaaltinmiktar);
            this.groupBox1.Controls.Add(this.textbox_hamlesayisi);
            this.groupBox1.Controls.Add(this.label_hamlesayisi);
            this.groupBox1.Controls.Add(this.textbox_hamleucret);
            this.groupBox1.Controls.Add(this.label_hamlemaliyet);
            this.groupBox1.Controls.Add(this.textbox_gizlialtinoran);
            this.groupBox1.Controls.Add(this.label_gizlialtinoran);
            this.groupBox1.Controls.Add(this.textbox_altinorani);
            this.groupBox1.Controls.Add(this.label_altinoran);
            this.groupBox1.Controls.Add(this.textbox_alany);
            this.groupBox1.Controls.Add(this.label_alany);
            this.groupBox1.Controls.Add(this.textbox_alanx);
            this.groupBox1.Controls.Add(this.label_alanx);
            this.groupBox1.Location = new System.Drawing.Point(29, 46);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(365, 270);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Ayar";
            // 
            // textbox_Dhedefmaliyet
            // 
            this.textbox_Dhedefmaliyet.Location = new System.Drawing.Point(244, 220);
            this.textbox_Dhedefmaliyet.Name = "textbox_Dhedefmaliyet";
            this.textbox_Dhedefmaliyet.Size = new System.Drawing.Size(58, 20);
            this.textbox_Dhedefmaliyet.TabIndex = 23;
            this.textbox_Dhedefmaliyet.Text = "20";
            // 
            // label_Dhedefmaliyet
            // 
            this.label_Dhedefmaliyet.AutoSize = true;
            this.label_Dhedefmaliyet.Location = new System.Drawing.Point(241, 201);
            this.label_Dhedefmaliyet.Name = "label_Dhedefmaliyet";
            this.label_Dhedefmaliyet.Size = new System.Drawing.Size(88, 13);
            this.label_Dhedefmaliyet.TabIndex = 22;
            this.label_Dhedefmaliyet.Text = "D hedef maliyeti :";
            // 
            // textbox_Chedefmaliyet
            // 
            this.textbox_Chedefmaliyet.Location = new System.Drawing.Point(244, 168);
            this.textbox_Chedefmaliyet.Name = "textbox_Chedefmaliyet";
            this.textbox_Chedefmaliyet.Size = new System.Drawing.Size(58, 20);
            this.textbox_Chedefmaliyet.TabIndex = 21;
            this.textbox_Chedefmaliyet.Text = "15";
            // 
            // label_Chedefmaliyet
            // 
            this.label_Chedefmaliyet.AutoSize = true;
            this.label_Chedefmaliyet.Location = new System.Drawing.Point(241, 146);
            this.label_Chedefmaliyet.Name = "label_Chedefmaliyet";
            this.label_Chedefmaliyet.Size = new System.Drawing.Size(87, 13);
            this.label_Chedefmaliyet.TabIndex = 20;
            this.label_Chedefmaliyet.Text = "C hedef maliyeti :";
            // 
            // textbox_Bhedefmaliyet
            // 
            this.textbox_Bhedefmaliyet.Location = new System.Drawing.Point(244, 111);
            this.textbox_Bhedefmaliyet.Name = "textbox_Bhedefmaliyet";
            this.textbox_Bhedefmaliyet.Size = new System.Drawing.Size(58, 20);
            this.textbox_Bhedefmaliyet.TabIndex = 19;
            this.textbox_Bhedefmaliyet.Text = "10";
            // 
            // label_Bhedefmaliyet
            // 
            this.label_Bhedefmaliyet.AutoSize = true;
            this.label_Bhedefmaliyet.Location = new System.Drawing.Point(241, 88);
            this.label_Bhedefmaliyet.Name = "label_Bhedefmaliyet";
            this.label_Bhedefmaliyet.Size = new System.Drawing.Size(87, 13);
            this.label_Bhedefmaliyet.TabIndex = 18;
            this.label_Bhedefmaliyet.Text = "B hedef maliyeti :";
            // 
            // textbox_Ahedefmaliyet
            // 
            this.textbox_Ahedefmaliyet.Location = new System.Drawing.Point(244, 50);
            this.textbox_Ahedefmaliyet.Name = "textbox_Ahedefmaliyet";
            this.textbox_Ahedefmaliyet.Size = new System.Drawing.Size(58, 20);
            this.textbox_Ahedefmaliyet.TabIndex = 17;
            this.textbox_Ahedefmaliyet.Text = "5";
            // 
            // label_Ahedefmaliyet
            // 
            this.label_Ahedefmaliyet.AutoSize = true;
            this.label_Ahedefmaliyet.Location = new System.Drawing.Point(241, 25);
            this.label_Ahedefmaliyet.Name = "label_Ahedefmaliyet";
            this.label_Ahedefmaliyet.Size = new System.Drawing.Size(87, 13);
            this.label_Ahedefmaliyet.TabIndex = 16;
            this.label_Ahedefmaliyet.Text = "A hedef maliyeti :";
            // 
            // textbox_gizlialtinacma
            // 
            this.textbox_gizlialtinacma.Location = new System.Drawing.Point(139, 220);
            this.textbox_gizlialtinacma.Name = "textbox_gizlialtinacma";
            this.textbox_gizlialtinacma.Size = new System.Drawing.Size(55, 20);
            this.textbox_gizlialtinacma.TabIndex = 15;
            this.textbox_gizlialtinacma.Text = "2";
            // 
            // label_gizlialtinacma
            // 
            this.label_gizlialtinacma.AutoSize = true;
            this.label_gizlialtinacma.Location = new System.Drawing.Point(125, 201);
            this.label_gizlialtinacma.Name = "label_gizlialtinacma";
            this.label_gizlialtinacma.Size = new System.Drawing.Size(108, 13);
            this.label_gizlialtinacma.TabIndex = 14;
            this.label_gizlialtinacma.Text = "Gizli altın açma sayısı:";
            // 
            // textbox_kasaaltindegeri
            // 
            this.textbox_kasaaltindegeri.Location = new System.Drawing.Point(35, 220);
            this.textbox_kasaaltindegeri.Name = "textbox_kasaaltindegeri";
            this.textbox_kasaaltindegeri.Size = new System.Drawing.Size(55, 20);
            this.textbox_kasaaltindegeri.TabIndex = 13;
            this.textbox_kasaaltindegeri.Text = "200";
            // 
            // label_kasaaltinmiktar
            // 
            this.label_kasaaltinmiktar.AutoSize = true;
            this.label_kasaaltinmiktar.Location = new System.Drawing.Point(18, 201);
            this.label_kasaaltinmiktar.Name = "label_kasaaltinmiktar";
            this.label_kasaaltinmiktar.Size = new System.Drawing.Size(92, 13);
            this.label_kasaaltinmiktar.TabIndex = 12;
            this.label_kasaaltinmiktar.Text = "Kasa altın miktarı: ";
            // 
            // textbox_hamlesayisi
            // 
            this.textbox_hamlesayisi.Location = new System.Drawing.Point(139, 168);
            this.textbox_hamlesayisi.Name = "textbox_hamlesayisi";
            this.textbox_hamlesayisi.Size = new System.Drawing.Size(55, 20);
            this.textbox_hamlesayisi.TabIndex = 11;
            this.textbox_hamlesayisi.Text = "3";
            // 
            // label_hamlesayisi
            // 
            this.label_hamlesayisi.AutoSize = true;
            this.label_hamlesayisi.Location = new System.Drawing.Point(136, 146);
            this.label_hamlesayisi.Name = "label_hamlesayisi";
            this.label_hamlesayisi.Size = new System.Drawing.Size(71, 13);
            this.label_hamlesayisi.TabIndex = 10;
            this.label_hamlesayisi.Text = "Hamle sayısı :";
            // 
            // textbox_hamleucret
            // 
            this.textbox_hamleucret.Location = new System.Drawing.Point(35, 168);
            this.textbox_hamleucret.Name = "textbox_hamleucret";
            this.textbox_hamleucret.Size = new System.Drawing.Size(55, 20);
            this.textbox_hamleucret.TabIndex = 9;
            this.textbox_hamleucret.Text = "5";
            // 
            // label_hamlemaliyet
            // 
            this.label_hamlemaliyet.AutoSize = true;
            this.label_hamlemaliyet.Location = new System.Drawing.Point(29, 146);
            this.label_hamlemaliyet.Name = "label_hamlemaliyet";
            this.label_hamlemaliyet.Size = new System.Drawing.Size(75, 13);
            this.label_hamlemaliyet.TabIndex = 8;
            this.label_hamlemaliyet.Text = "Hamle maliyet:";
            // 
            // textbox_gizlialtinoran
            // 
            this.textbox_gizlialtinoran.Location = new System.Drawing.Point(139, 111);
            this.textbox_gizlialtinoran.Name = "textbox_gizlialtinoran";
            this.textbox_gizlialtinoran.Size = new System.Drawing.Size(55, 20);
            this.textbox_gizlialtinoran.TabIndex = 7;
            this.textbox_gizlialtinoran.Text = "10";
            // 
            // label_gizlialtinoran
            // 
            this.label_gizlialtinoran.AutoSize = true;
            this.label_gizlialtinoran.Location = new System.Drawing.Point(125, 88);
            this.label_gizlialtinoran.Name = "label_gizlialtinoran";
            this.label_gizlialtinoran.Size = new System.Drawing.Size(91, 13);
            this.label_gizlialtinoran.TabIndex = 6;
            this.label_gizlialtinoran.Text = "Gizli altin orani  %:";
            // 
            // textbox_altinorani
            // 
            this.textbox_altinorani.Location = new System.Drawing.Point(35, 111);
            this.textbox_altinorani.Name = "textbox_altinorani";
            this.textbox_altinorani.Size = new System.Drawing.Size(55, 20);
            this.textbox_altinorani.TabIndex = 5;
            this.textbox_altinorani.Text = "20";
            // 
            // label_altinoran
            // 
            this.label_altinoran.AutoSize = true;
            this.label_altinoran.Location = new System.Drawing.Point(32, 88);
            this.label_altinoran.Name = "label_altinoran";
            this.label_altinoran.Size = new System.Drawing.Size(69, 13);
            this.label_altinoran.TabIndex = 4;
            this.label_altinoran.Text = "Altın oranı %ı:";
            // 
            // textbox_alany
            // 
            this.textbox_alany.Location = new System.Drawing.Point(139, 50);
            this.textbox_alany.Name = "textbox_alany";
            this.textbox_alany.Size = new System.Drawing.Size(54, 20);
            this.textbox_alany.TabIndex = 3;
            this.textbox_alany.Text = "20";
            // 
            // label_alany
            // 
            this.label_alany.AutoSize = true;
            this.label_alany.Location = new System.Drawing.Point(147, 25);
            this.label_alany.Name = "label_alany";
            this.label_alany.Size = new System.Drawing.Size(46, 13);
            this.label_alany.TabIndex = 2;
            this.label_alany.Text = "Y boyut:";
            // 
            // textbox_alanx
            // 
            this.textbox_alanx.Location = new System.Drawing.Point(35, 50);
            this.textbox_alanx.Name = "textbox_alanx";
            this.textbox_alanx.Size = new System.Drawing.Size(55, 20);
            this.textbox_alanx.TabIndex = 1;
            this.textbox_alanx.Text = "20";
            // 
            // label_alanx
            // 
            this.label_alanx.AutoSize = true;
            this.label_alanx.Location = new System.Drawing.Point(44, 25);
            this.label_alanx.Name = "label_alanx";
            this.label_alanx.Size = new System.Drawing.Size(46, 13);
            this.label_alanx.TabIndex = 0;
            this.label_alanx.Text = "X boyut:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Miriam CLM", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.label1.Location = new System.Drawing.Point(122, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(169, 17);
            this.label1.TabIndex = 4;
            this.label1.Text = "ALTIN TOPLAMA OYUNU";
            // 
            // button_exit
            // 
            this.button_exit.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.button_exit.Location = new System.Drawing.Point(234, 334);
            this.button_exit.Name = "button_exit";
            this.button_exit.Size = new System.Drawing.Size(88, 36);
            this.button_exit.TabIndex = 5;
            this.button_exit.Text = "Çıkış";
            this.button_exit.UseVisualStyleBackColor = false;
            this.button_exit.Click += new System.EventHandler(this.button_exit_Click);
            // 
            // girisekrani
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlDark;
            this.ClientSize = new System.Drawing.Size(426, 403);
            this.Controls.Add(this.button_exit);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button_basla);
            this.Controls.Add(this.groupBox1);
            this.Name = "girisekrani";
            this.Text = "Altın Toplama Oyunu";
            this.Load += new System.EventHandler(this.girisekrani_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button_basla;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox textbox_Dhedefmaliyet;
        private System.Windows.Forms.Label label_Dhedefmaliyet;
        private System.Windows.Forms.TextBox textbox_Chedefmaliyet;
        private System.Windows.Forms.Label label_Chedefmaliyet;
        private System.Windows.Forms.TextBox textbox_Bhedefmaliyet;
        private System.Windows.Forms.Label label_Bhedefmaliyet;
        private System.Windows.Forms.TextBox textbox_Ahedefmaliyet;
        private System.Windows.Forms.Label label_Ahedefmaliyet;
        private System.Windows.Forms.TextBox textbox_gizlialtinacma;
        private System.Windows.Forms.Label label_gizlialtinacma;
        private System.Windows.Forms.TextBox textbox_kasaaltindegeri;
        private System.Windows.Forms.Label label_kasaaltinmiktar;
        private System.Windows.Forms.TextBox textbox_hamlesayisi;
        private System.Windows.Forms.Label label_hamlesayisi;
        private System.Windows.Forms.TextBox textbox_hamleucret;
        private System.Windows.Forms.Label label_hamlemaliyet;
        private System.Windows.Forms.TextBox textbox_gizlialtinoran;
        private System.Windows.Forms.Label label_gizlialtinoran;
        private System.Windows.Forms.TextBox textbox_altinorani;
        private System.Windows.Forms.Label label_altinoran;
        private System.Windows.Forms.TextBox textbox_alany;
        private System.Windows.Forms.Label label_alany;
        private System.Windows.Forms.TextBox textbox_alanx;
        private System.Windows.Forms.Label label_alanx;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button_exit;
    }
}

