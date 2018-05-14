using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CezaeviOtomasyon
{
    public partial class YeniUye : Form
    {
        public YeniUye()
        {
            InitializeComponent();
        }

        private void btnkayitol_Click(object sender, EventArgs e)
        {
            if (textBox2.Text == textBox3.Text)
            {
                SqlConnection baglanti = new SqlConnection(@"Server=DESKTOP-I3MGUM0;Initial Catalog=CezaeviKayit;Integrated Security=True;");

                if (baglanti.State != ConnectionState.Open)
                {
                    baglanti.Open();
                }

                string checkQuery = "SELECT COUNT(*) FROM dbo.Hesaplar WHERE KullaniciAdi like @YeniKullaniciAdi";
                SqlCommand kontrolKomutu = new SqlCommand(checkQuery, baglanti);
                kontrolKomutu.Parameters.Add("@YeniKullaniciAdi", SqlDbType.VarChar).Value = textBox1.Text;
                int kullaniciSayisi = (int)kontrolKomutu.ExecuteScalar();

                if (kullaniciSayisi > 0) MessageBox.Show("Kullanıcı adı daha önce alınmış.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                else
                {
                    string query = "INSERT INTO dbo.Hesaplar(KullaniciAdi, Sifre) VALUES(@KullaniciAdi, @Sifre)";
                    SqlCommand komut = new SqlCommand(query, baglanti);

                    komut.Parameters.Add("@KullaniciAdi", SqlDbType.VarChar, 30).Value = textBox1.Text;
                    komut.Parameters.Add("@Sifre", SqlDbType.VarChar).Value = EncodePasswordToBase64(textBox2.Text);

                    komut.ExecuteNonQuery();
                    baglanti.Close();
                    this.Close();
                }
                baglanti.Close();
            }
            else MessageBox.Show("Şifreler Uyuşmuyor!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Hand);
        }

        private string EncodePasswordToBase64(string password)
        {
            byte[] bytes = Encoding.Unicode.GetBytes(password);
            byte[] inArray = HashAlgorithm.Create("SHA1").ComputeHash(bytes);
            return Convert.ToBase64String(inArray);
        }

    }
}
