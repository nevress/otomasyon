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
    public partial class Giriş : Form
    {
        public Giriş()
        {
            InitializeComponent();
        }

        private void btngiris_Click(object sender, EventArgs e)
        {
            SqlConnection baglanti = new SqlConnection(@"Server=DESKTOP-I3MGUM0;Initial Catalog=CezaeviKayit;Integrated Security=True;");

            if (baglanti.State != ConnectionState.Open)
            {
                baglanti.Open();
            }

            string query = "SELECT Sifre FROM dbo.Hesaplar WHERE KullaniciAdi=@KullaniciAdi";
            SqlCommand komut = new SqlCommand(query, baglanti);
            
            komut.Parameters.AddWithValue("@KullaniciAdi",textBox1.Text);
            SqlDataReader ok = komut.ExecuteReader();

            if (ok.Read())
            {
                string sifre = ok["Sifre"].ToString();
                if (sifre == EncodePasswordToBase64(textBox2.Text))
                {
                    AnaMenu anaMenu = new AnaMenu();
                    anaMenu.Show();
                    this.Hide();
                }
                else MessageBox.Show("Hatalı şifre veya kullanıcı adı !", "Hatalı Giriş", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
            else
            {
                MessageBox.Show("Hatalı şifre veya kullanıcı adı !", "Hatalı Giriş", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            } 

            baglanti.Close();
        }

        private void btnkayitol_Click(object sender, EventArgs e)
        {
            YeniUye kayitOl = new YeniUye();
            kayitOl.ShowDialog();
        }

        private string EncodePasswordToBase64(string password)
        {
            byte[] bytes = Encoding.Unicode.GetBytes(password);
            byte[] inArray = HashAlgorithm.Create("SHA1").ComputeHash(bytes);
            return Convert.ToBase64String(inArray);
        }

    }
}
