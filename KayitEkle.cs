using System;
using System.Data;
using System.Drawing;
using System.IO;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace CezaeviOtomasyon
{
    public partial class KayitEkle : Form
    {
        public KayitEkle()
        {
            InitializeComponent();
        }

        string resimyolu;
        byte[] resim = null;
        public string getir;
        Image res = null;

        private void txtadi_TextChanged(object sender, EventArgs e)
        {
            if (txtadi.TextLength > 0)
            {
                string last_char = Convert.ToString(txtadi.Text[txtadi.Text.Length - 1]);
                if (!Regex.IsMatch(last_char, @"[a-zA-Z]"))
                {
                    txtadi.Text = txtadi.Text.Remove(txtadi.Text.Length - 1);
                    MessageBox.Show("Lütfen sadece harf kullanın.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                }
            }     
        }

        private void txtsoyadi_TextChanged(object sender, EventArgs e)
        {
            if (txtsoyadi.TextLength > 0)
            {
                string last_char = Convert.ToString(txtsoyadi.Text[txtsoyadi.Text.Length - 1]);
                if (!Regex.IsMatch(last_char, @"[a-zA-Z]"))
                {
                    txtsoyadi.Text = txtsoyadi.Text.Remove(txtsoyadi.Text.Length - 1);
                    MessageBox.Show("Lütfen sadece harf kullanın.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                }
            }
        }

        private void txttcno_TextChanged(object sender, EventArgs e)
        {
            if (txttcno.TextLength > 0)
            {
                string last_char = Convert.ToString(txttcno.Text[txttcno.Text.Length - 1]);
                if (!Regex.IsMatch(last_char, "[ ^ 0-9]"))
                {
                    txttcno.Text = txttcno.Text.Remove(txttcno.Text.Length - 1);
                    MessageBox.Show("Lütfen sadece rakam kullanın.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                }
            }
        }

        private void txtkartno_TextChanged(object sender, EventArgs e)
        {
            if (txtkartno.TextLength > 0)
            {
                string last_char = Convert.ToString(txtkartno.Text[txtkartno.Text.Length - 1]);
                if (!Regex.IsMatch(last_char, "[ ^ 0-9]"))
                {
                    txtkartno.Text = txtkartno.Text.Remove(txtkartno.Text.Length - 1);
                    MessageBox.Show("Lütfen sadece rakam kullanın.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                }
            }
        }

        private void VeriDoldur()
        {
            Kayitlar kayit = new Kayitlar();
            kayit.Kartid = Convert.ToInt64(getir);
            DataTable dt = kayit.KartidListele();            
            txtkartno.Text = getir;
            txttcno.Text = dt.Rows[0]["tcno"].ToString();
            txtadi.Text = dt.Rows[0]["ad"].ToString();
            txtsoyadi.Text = dt.Rows[0]["soyad"].ToString();
            txtadres.Text = dt.Rows[0]["adres"].ToString();
            txttarih.Text = dt.Rows[0]["giristarih"].ToString();
            if (dt.Rows[0]["resim"] != DBNull.Value)
            {
                resim = (byte[])dt.Rows[0]["resim"];
                MemoryStream ms = new MemoryStream(resim, 0, resim.Length);
                res = Image.FromStream(ms, true);
                pictureBox1.Image = res;
            }                 
        }
        private void Temizle()
        {
            txtkartno.Clear();
            txttcno.Clear();
            txtadi.Clear();
            txtsoyadi.Clear();
            txttarih.Value = DateTime.Now.Date;
            txtadres.Clear();
            pictureBox1.ImageLocation = "";
            txttcno.Focus();
        }
        private void ResimEkle()
        {
            try
            {
                OpenFileDialog dlg = new OpenFileDialog();
                dlg.Filter = "JPG Dosyası (*.jpg)|*.jpg|BMP Dosyası (*.bmp)|*.bmp|Tüm Dosyalar (*.*)|*.* ";
                dlg.Title = "Resim Seç";
                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    resimyolu = dlg.FileName.ToString();
                    pictureBox1.ImageLocation = resimyolu;
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Resim Eklenirken Bir Hata Oluştu! Lütfen Tekrar Deneyin...", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
        }
        private byte[] ResimKaydet()
        {
            try
            {
                if (resimyolu!=null)
                {
                    FileStream fs = new FileStream(resimyolu, FileMode.Open, FileAccess.Read);
                    BinaryReader br = new BinaryReader(fs);
                    resim = br.ReadBytes((int)fs.Length);
                }
                else
                {
                    MessageBox.Show("Lütfen Bir Resim Seçin!!!", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                } 
            }
            catch (Exception)
            {
                throw;
            }
            return resim;
        }
        private void Ekle()
        {
            try
            {
                ResimKaydet();
                if (txtkartno.Text!="" && txtadi.Text!=""&&txtadres.Text!=""&&txtsoyadi.Text!=""&&txttcno.Text!="")
                {
                    Kayitlar kayit = new Kayitlar();
                    kayit.Kartid = Convert.ToInt64(txtkartno.Text);
                    kayit.TcNo = Convert.ToInt64(txttcno.Text);
                    kayit.Ad = txtadi.Text;
                    kayit.Soyad = txtsoyadi.Text;
                    kayit.Giristarih = txttarih.Value.ToShortDateString().ToString();                  
                    kayit.Adres = txtadres.Text;
                    kayit.Resim = resim;
                    bool durum = kayit.KayitEkle();
                    if (durum == true)
                    {
                        MessageBox.Show("Kayıt Başarıyla Eklendi....", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        Temizle();
                    }
                    else
                    {
                        MessageBox.Show("Kayıt Eklenirken Hata Oluştu !!!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                    }
                }
                else MessageBox.Show("Lütfen Tüm Alanları Doldurun!!!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Hand);

            }
            catch (Exception)
            {
                MessageBox.Show("Kayıt Eklenirken Hata Oluştu !!!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }
            
        }
        private void Guncelle()
        {
            try
            {
                if (resimyolu != null) ResimKaydet();
                if (txtkartno.Text != "" && txtadi.Text != "" && txtadres.Text != "" && txtsoyadi.Text != "" && txttcno.Text != "")
                {
                    Kayitlar kayit = new Kayitlar();
                    kayit.Kartid = Convert.ToInt64(txtkartno.Text);
                    kayit.TcNo = Convert.ToInt64(txttcno.Text);
                    kayit.Ad = txtadi.Text;
                    kayit.Soyad = txtsoyadi.Text;
                    kayit.Giristarih = txttarih.Value.ToShortDateString().ToString();                 
                    kayit.Adres = txtadres.Text;
                    kayit.Resim = resim;
                    bool durum = kayit.KayitGuncelle();
                    if (durum == true)
                    {
                        MessageBox.Show("Kayıt Başarıyla Güncellendi....", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);                        
                    }
                    else
                    {
                        MessageBox.Show("Kayıt Güncellenirken Hata Oluştu !!!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                    }
                }
                else MessageBox.Show("Lütfen Tüm Alanları Doldurun!!!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Hand);

            }
            catch (Exception)
            {

                MessageBox.Show("Kayıt Güncellenirken Hata Oluştu !!!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }            
        }
        private void Sil()
        {
            try
            {
                if (txtkartno.Text!="")
                {
                    Kayitlar kayit = new Kayitlar();
                    kayit.Kartid = Convert.ToInt64(txtkartno.Text);                  
                    bool durum = kayit.KayitSil();
                    if (durum == true)
                    {
                        MessageBox.Show("Kayıt Başarıyla Silindi....", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        btncikis.PerformClick();
                    }
                    else
                    {
                        MessageBox.Show("Kayıt Silinirken Hata Oluştu !!!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                    }
                }
                else MessageBox.Show("Lütfen Kart Numarasını Boş Bırakmayın !!!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }
            catch (Exception)
            {
                MessageBox.Show("Kayıt Silinirken Hata Oluştu !!!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }
        }


        private void btnresimsec_Click(object sender, EventArgs e)
        {
            ResimEkle();
        }      
        private void btnekle_Click(object sender, EventArgs e)
        {
            if (btnekle.Text== "Kayıt Ekle")
            { 
                Ekle();                
            }
            else if(btnekle.Text == "Güncelle")
            { 
                Guncelle();               
            }
            else if (btnekle.Text == "Kayıt Sil")
            {                
                Sil();               
            }
        }
        private void KayitEkle_Load(object sender, EventArgs e)
        {
            Temizle();
            
            if (btnekle.Text == "Kayıt Ekle")
            {
                txtadi.ReadOnly = false;
                txtadres.ReadOnly = false;
                txtkartno.ReadOnly = false;
                txtsoyadi.ReadOnly = false;
                txttcno.ReadOnly = false;
                btnresimsec.Enabled = true;               
            }
            else if (btnekle.Text == "Güncelle")
            {
                txtadi.ReadOnly = false;
                txtadres.ReadOnly = false;
                txtkartno.ReadOnly = false;
                txtsoyadi.ReadOnly = false;
                txttcno.ReadOnly = false;
                btnresimsec.Enabled = true;               
            }
            else if (btnekle.Text == "Kayıt Sil")
            {
                txtadi.ReadOnly = true;
                txtadres.ReadOnly = true;
                txtkartno.ReadOnly = true;
                txtsoyadi.ReadOnly = true;
                txttcno.ReadOnly = true;
                btnresimsec.Enabled = false;                
            }
            if (btnekle.Text == "Güncelle" || btnekle.Text == "Kayıt Sil") VeriDoldur();            
        }
        private void btncikis_Click(object sender, EventArgs e)
        {
            AnaMenu anm = (AnaMenu)Application.OpenForms["AnaMenu"];
            anm.Listele();
            this.Close();
        }
        private void KayitEkle_FormClosed(object sender, FormClosedEventArgs e)
        {
            AnaMenu anm = (AnaMenu)Application.OpenForms["AnaMenu"];
            anm.Listele();
            this.Close();
        }
    }
}
