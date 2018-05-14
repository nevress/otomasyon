using System;
using System.Data;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace CezaeviOtomasyon
{
    public partial class Goruntule : Form
    {
        public Goruntule()
        {
            InitializeComponent();
        }

        public string getir;
        byte[] resim = null;
        Image res = null;
        private void VeriGetir()
        {
            Kayitlar kyt = new Kayitlar();
            kyt.Kartid = Convert.ToInt64(getir);
            DataTable dt = kyt.KartidListele();
            txtkartno.Text = dt.Rows[0]["KartId"].ToString();
            txttcno.Text = dt.Rows[0]["TcNo"].ToString();
            txtadi.Text = dt.Rows[0]["ad"].ToString();
            txtsoyadi.Text = dt.Rows[0]["soyad"].ToString();           
            txtadres.Text = dt.Rows[0]["adres"].ToString();
            if (dt.Rows[0]["resim"] != DBNull.Value) {
                resim = (byte[])dt.Rows[0]["resim"];
                MemoryStream ms = new MemoryStream(resim, 0, resim.Length);
                res = Image.FromStream(ms, true);
                pictureBox1.Image = res;
            }
            
        }
        private void btncikis_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Goruntule_Load(object sender, EventArgs e)
        {
            VeriGetir();
        }
    }
}
