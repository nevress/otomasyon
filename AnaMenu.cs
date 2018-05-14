using System;
using System.Data;
using System.Drawing;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace CezaeviOtomasyon
{
    public partial class AnaMenu : Form
    {
        public AnaMenu()
        {
            InitializeComponent();
        }

        public void Listele()
        {
            Kayitlar kayit = new Kayitlar();
            DataTable dt = kayit.Listele();
            dataGridView1.DataSource = dt;
            dataGridView1.Columns[6].Width = 100;
        }
        private void TcListele()
        {
            Kayitlar kayit = new Kayitlar();
            kayit.TcNo = Convert.ToInt64(txttcnoara.Text);
            DataTable dt = kayit.TcListele();           
            dataGridView1.DataSource = dt;
        }
        private void KartnoListele()
        {
            Kayitlar kayit = new Kayitlar();
            kayit.Kartid = Convert.ToInt64(txtkartnoara.Text);
            DataTable dt = kayit.KartidListele();           
            dataGridView1.DataSource = dt;
        }
        private void isimListele()
        {
            Kayitlar kayit = new Kayitlar();
            kayit.Ad = txtisimara.Text;
            DataTable dt = kayit.AdListele();            
            dataGridView1.DataSource = dt;
        }       
        private void TarihListele()
        {            
            Kayitlar kayit = new Kayitlar();
            kayit.Giristarih = txttarihara.Value.ToShortDateString().ToString();
            DataTable dt = kayit.TarihListele();           
            dataGridView1.DataSource = dt;
        }        
        private void GoruntuleAc()
        {           
            Goruntule grn = new Goruntule();
            grn.getir = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
            grn.ShowDialog();
        }

        
        private void btncikis_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        private void AnaMenu_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
        private void AnaMenu_Load(object sender, EventArgs e)
        {
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.ReadOnly = true;

            Listele();
        }
        private void txtkartnoara_TextChanged(object sender, EventArgs e)
        {
            if (txtkartnoara.TextLength > 0)
            {
                txttcnoara.Clear();
                txtisimara.Clear();
                txttarihara.Value = DateTime.Now.Date;

                string last_char = Convert.ToString(txtkartnoara.Text[txtkartnoara.Text.Length - 1]);
                if (!Regex.IsMatch(last_char, "[ ^ 0-9]"))
                {
                    txtkartnoara.Text = txtkartnoara.Text.Remove(txtkartnoara.Text.Length - 1);
                    MessageBox.Show("Lütfen sadece rakam kullanın.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                }
            }
            if (txtkartnoara.Text == "") Listele();
            else KartnoListele();
        }
        private void txttcnoara_TextChanged(object sender, EventArgs e)
        {
            if (txttcnoara.TextLength > 0)
            {
                txtkartnoara.Clear();
                txtisimara.Clear();
                txttarihara.Value = DateTime.Now.Date;

                string last_char = Convert.ToString(txttcnoara.Text[txttcnoara.Text.Length - 1]);
                if (!Regex.IsMatch(last_char, "[ ^ 0-9]"))
                {
                    txttcnoara.Text = txttcnoara.Text.Remove(txttcnoara.Text.Length - 1);
                    MessageBox.Show("Lütfen sadece rakam kullanın.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                }
            }
            if (txttcnoara.Text == "") Listele();
            else TcListele();
        }
        private void txtisimara_TextChanged(object sender, EventArgs e)
        {
            if (txtisimara.TextLength > 0)
            {
                txtkartnoara.Clear();
                txttcnoara.Clear();
                txttarihara.Value = DateTime.Now.Date;

                string last_char = Convert.ToString(txtisimara.Text[txtisimara.Text.Length - 1]);
                if (!Regex.IsMatch(last_char, @"[a-zA-Z]"))
                {
                    txtisimara.Text = txtisimara.Text.Remove(txtisimara.Text.Length - 1);
                    MessageBox.Show("Lütfen sadece harf kullanın.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                }
            }
            if (txtisimara.Text == "") Listele();
            else isimListele();
        }               
        private void btnaramatemizle_Click(object sender, EventArgs e)
        {
            txtkartnoara.Clear();
            txttcnoara.Clear();
            txtisimara.Clear();
            txttarihara.Value = DateTime.Now.Date;
            Listele();
        }
        private void btnekle_Click(object sender, EventArgs e)
        {
            KayitEkle kyt = new KayitEkle();
            kyt.btnekle.Text = "Kayıt Ekle";
            kyt.ShowDialog();
        }
        private void btnguncelle_Click(object sender, EventArgs e)
        {
            try
            {
                KayitEkle kayit = new KayitEkle();
                kayit.getir = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
                kayit.btnekle.Text = "Güncelle";
                kayit.ShowDialog();
            }
            catch (Exception)
            {
                MessageBox.Show("Lütfen bir kayıt seçin...", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }
            
        }
        private void btnsil_Click(object sender, EventArgs e)
        {
            try
            {
                KayitEkle kayit = new KayitEkle();
                kayit.getir = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
                kayit.btnekle.Text = "Kayıt Sil";
                kayit.ShowDialog();
            }
            catch (Exception)
            {
                MessageBox.Show("Lütfen bir kayıt seçin...", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }
            
        }
        private void btngoruntule_Click(object sender, EventArgs e)
        {
            try
            {
                GoruntuleAc();
            }
            catch (Exception)
            {
                MessageBox.Show("Lütfen bir kartno girin...", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }
            
        }        
        private void txttarihara_ValueChanged_1(object sender, EventArgs e)
        {
            if (txttarihara.Value != DateTime.Now.Date)
            {
                txtkartnoara.Clear();
                txttcnoara.Clear();
                txtisimara.Clear();
                TarihListele();

            }
            else Listele();
            
        }
    }
}
