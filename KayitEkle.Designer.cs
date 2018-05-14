namespace CezaeviOtomasyon
{
    partial class KayitEkle
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.txtsoyadi = new System.Windows.Forms.TextBox();
            this.txtadres = new System.Windows.Forms.TextBox();
            this.txtadi = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txttcno = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtkartno = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txttarih = new System.Windows.Forms.DateTimePicker();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.btnekle = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.btncikis = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnresimsec = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtsoyadi
            // 
            this.txtsoyadi.Location = new System.Drawing.Point(124, 127);
            this.txtsoyadi.Margin = new System.Windows.Forms.Padding(4);
            this.txtsoyadi.Name = "txtsoyadi";
            this.txtsoyadi.Size = new System.Drawing.Size(232, 22);
            this.txtsoyadi.TabIndex = 4;
            this.txtsoyadi.TextChanged += new System.EventHandler(this.txtsoyadi_TextChanged);
            // 
            // txtadres
            // 
            this.txtadres.Location = new System.Drawing.Point(124, 226);
            this.txtadres.Margin = new System.Windows.Forms.Padding(4);
            this.txtadres.Multiline = true;
            this.txtadres.Name = "txtadres";
            this.txtadres.Size = new System.Drawing.Size(232, 101);
            this.txtadres.TabIndex = 7;
            // 
            // txtadi
            // 
            this.txtadi.Location = new System.Drawing.Point(124, 96);
            this.txtadi.Margin = new System.Windows.Forms.Padding(4);
            this.txtadi.Name = "txtadi";
            this.txtadi.Size = new System.Drawing.Size(232, 22);
            this.txtadi.TabIndex = 3;
            this.txtadi.TextChanged += new System.EventHandler(this.txtadi_TextChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(15, 38);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(102, 17);
            this.label7.TabIndex = 6;
            this.label7.Text = "Kart Numarası:";
            // 
            // txttcno
            // 
            this.txttcno.Location = new System.Drawing.Point(124, 65);
            this.txttcno.Margin = new System.Windows.Forms.Padding(4);
            this.txttcno.MaxLength = 11;
            this.txttcno.Name = "txttcno";
            this.txttcno.Size = new System.Drawing.Size(232, 22);
            this.txttcno.TabIndex = 2;
            this.txttcno.TextChanged += new System.EventHandler(this.txttcno_TextChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(23, 69);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(90, 17);
            this.label6.TabIndex = 5;
            this.label6.Text = "Tc Kimlik No:";
            // 
            // txtkartno
            // 
            this.txtkartno.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.txtkartno.Location = new System.Drawing.Point(124, 34);
            this.txtkartno.Margin = new System.Windows.Forms.Padding(4);
            this.txtkartno.MaxLength = 15;
            this.txtkartno.Name = "txtkartno";
            this.txtkartno.ReadOnly = true;
            this.txtkartno.Size = new System.Drawing.Size(232, 22);
            this.txtkartno.TabIndex = 1;
            this.txtkartno.TextChanged += new System.EventHandler(this.txtkartno_TextChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(87, 100);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(28, 17);
            this.label5.TabIndex = 4;
            this.label5.Text = "Adı";
            // 
            // txttarih
            // 
            this.txttarih.Location = new System.Drawing.Point(124, 159);
            this.txttarih.Margin = new System.Windows.Forms.Padding(4);
            this.txttarih.Name = "txttarih";
            this.txttarih.Size = new System.Drawing.Size(232, 22);
            this.txttarih.TabIndex = 5;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(60, 130);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(55, 17);
            this.label4.TabIndex = 3;
            this.label4.Text = "Soyadı:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(67, 230);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(49, 17);
            this.label3.TabIndex = 2;
            this.label3.Text = "Adres:";
            // 
            // btnekle
            // 
            this.btnekle.Location = new System.Drawing.Point(27, 361);
            this.btnekle.Margin = new System.Windows.Forms.Padding(4);
            this.btnekle.Name = "btnekle";
            this.btnekle.Size = new System.Drawing.Size(125, 59);
            this.btnekle.TabIndex = 9;
            this.btnekle.Text = "Kayıt Ekle";
            this.btnekle.UseVisualStyleBackColor = true;
            this.btnekle.Click += new System.EventHandler(this.btnekle_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(40, 166);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(78, 17);
            this.label2.TabIndex = 1;
            this.label2.Text = "Giris Tarhi:";
            // 
            // btncikis
            // 
            this.btncikis.Location = new System.Drawing.Point(232, 361);
            this.btncikis.Margin = new System.Windows.Forms.Padding(4);
            this.btncikis.Name = "btncikis";
            this.btncikis.Size = new System.Drawing.Size(125, 59);
            this.btncikis.TabIndex = 10;
            this.btncikis.Text = "ÇIKIŞ";
            this.btncikis.UseVisualStyleBackColor = true;
            this.btncikis.Click += new System.EventHandler(this.btncikis_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btncikis);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.btnekle);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.txttarih);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.txtkartno);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.txttcno);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.txtadi);
            this.groupBox1.Controls.Add(this.txtadres);
            this.groupBox1.Controls.Add(this.txtsoyadi);
            this.groupBox1.Location = new System.Drawing.Point(16, 15);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox1.Size = new System.Drawing.Size(373, 444);
            this.groupBox1.TabIndex = 18;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Kişi Bilgileri";
            // 
            // btnresimsec
            // 
            this.btnresimsec.Location = new System.Drawing.Point(8, 242);
            this.btnresimsec.Margin = new System.Windows.Forms.Padding(4);
            this.btnresimsec.Name = "btnresimsec";
            this.btnresimsec.Size = new System.Drawing.Size(161, 44);
            this.btnresimsec.TabIndex = 8;
            this.btnresimsec.Text = "Resim Seç";
            this.btnresimsec.UseVisualStyleBackColor = true;
            this.btnresimsec.Click += new System.EventHandler(this.btnresimsec_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox1.Location = new System.Drawing.Point(8, 37);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(4);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(161, 184);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 7;
            this.pictureBox1.TabStop = false;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.pictureBox1);
            this.groupBox2.Controls.Add(this.btnresimsec);
            this.groupBox2.Location = new System.Drawing.Point(397, 15);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox2.Size = new System.Drawing.Size(184, 299);
            this.groupBox2.TabIndex = 19;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Resim ";
            // 
            // KayitEkle
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(596, 471);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "KayitEkle";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Kayıt İşlemleri";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.KayitEkle_FormClosed);
            this.Load += new System.EventHandler(this.KayitEkle_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnresimsec;
        private System.Windows.Forms.GroupBox groupBox2;
        public System.Windows.Forms.Button btnekle;
        public System.Windows.Forms.Button btncikis;
        private System.Windows.Forms.TextBox txtsoyadi;
        private System.Windows.Forms.TextBox txtadres;
        private System.Windows.Forms.TextBox txtadi;
        private System.Windows.Forms.TextBox txttcno;
        private System.Windows.Forms.TextBox txtkartno;
        private System.Windows.Forms.DateTimePicker txttarih;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}