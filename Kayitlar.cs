using System;
using System.Data;
using System.Data.SqlClient;
using System.Linq;


namespace CezaeviOtomasyon
{
    class Kayitlar
    {
        #region Baglantı

        SqlConnection baglanti = new SqlConnection(@"Server=DESKTOP-I3MGUM0;Initial Catalog=CezaeviKayit;Integrated Security=True;");

        void BaglantiAc()
        {           
            if (baglanti.State != ConnectionState.Open)
            {
                baglanti.Open();
            }            
        }
        #endregion  

        #region Özellikler

        private long kartid;
        public long Kartid
        {
            get { return kartid; }
            set { kartid = value; }
        }

        private long tcno;
        public long TcNo
        {
            get { return tcno; }
            set { tcno = value; }
        }

        private string  ad;
        public string  Ad
        {
            get { return ad; }
            set { ad = value; }
        }

        private string soyad;
        public string Soyad
        {
            get { return soyad; }
            set { soyad = value; }
        }

        private string adres;
        public string Adres
        {
            get { return adres; }
            set { adres = value; }
        }        

        private string giristarih;
        public string Giristarih
        {
            get { return giristarih; }
            set { giristarih = value; }
        }

        private byte[] resim;
        public byte[] Resim
        {
            get { return resim; }
            set { resim = value; }
        }


        #endregion

        #region Veri Tabanı Kayıtlar Tablosu İşlemi
        public bool KayitEkle()
        {
            return fillParameters(commandText: "usp_Ziyaretci");
            
        }

        public bool KayitGuncelle()
        {
            return fillParameters(commandText: "UpdateZiyaretci");
        }

        private bool fillParameters(string commandText) {
            BaglantiAc();
            SqlCommand komut = new SqlCommand();
            komut.Connection = baglanti;
            komut.CommandType = CommandType.StoredProcedure;
            komut.CommandText = commandText;
            komut.Parameters.Add("@KartID", SqlDbType.BigInt).Value = this.kartid;
            komut.Parameters.Add("@TcNo", SqlDbType.BigInt).Value = this.tcno;
            komut.Parameters.Add("@Ad", SqlDbType.NVarChar, 50).Value = this.ad;
            komut.Parameters.Add("@Soyad", SqlDbType.NVarChar, 50).Value = this.soyad;
            komut.Parameters.Add("@Adres", SqlDbType.NVarChar, 250).Value = this.adres;           
            komut.Parameters.Add("@Resim", SqlDbType.Image).Value = this.resim;
            komut.Parameters.Add("@GirisTarih", SqlDbType.NVarChar, 50).Value = this.giristarih;
            bool durum = false;
            if (komut.ExecuteNonQuery() == 1)
            {
                durum = true;
            }

            baglanti.Close();
            return durum;
        }
        public bool KayitSil()
        {  
            BaglantiAc();
            SqlCommand komut = new SqlCommand();
            komut.Connection = baglanti;
            komut.CommandType = CommandType.StoredProcedure;
            komut.CommandText = "DeleteZiyaretci";
            komut.Parameters.Add("@KartID", SqlDbType.BigInt).Value = Kartid;

            bool durum = false;
            if (komut.ExecuteNonQuery() == 1)
            {
                durum = true;
            }
            baglanti.Close();
            return durum;
        }
        public DataTable Listele()
        {
            BaglantiAc();
            SqlCommand komut = new SqlCommand();
            komut.Connection = baglanti;
            komut.CommandType = CommandType.StoredProcedure;
            komut.CommandText = "Listele";
            SqlDataAdapter da = new SqlDataAdapter(komut);
            DataTable dt = new DataTable();
            da.Fill(dt);
            baglanti.Close();
            return dt;
        }
        public DataTable AdListele()
        {
            BaglantiAc();
            SqlCommand komut = new SqlCommand();
            komut.Connection = baglanti;
            komut.CommandType = CommandType.StoredProcedure;
            komut.CommandText = "AdListele";
            komut.Parameters.AddWithValue("@Ad", Ad);
            SqlDataAdapter da = new SqlDataAdapter(komut);
            DataTable dt = new DataTable();
            da.Fill(dt);
            baglanti.Close();
            return dt;
        }
        public DataTable KartidListele()
        {
            BaglantiAc();
            SqlCommand komut = new SqlCommand();
            komut.Connection = baglanti;
            komut.CommandType = CommandType.StoredProcedure;
            komut.CommandText = "usp_IdListele";
            komut.Parameters.Add("@KartID", SqlDbType.BigInt).Value = Kartid;
            SqlDataAdapter da = new SqlDataAdapter(komut);
            DataTable dt = new DataTable();
            da.Fill(dt);
            baglanti.Close();
            return dt;
        }       
        public DataTable TcListele()
        {
            BaglantiAc();
            SqlCommand komut = new SqlCommand();
            komut.Connection = baglanti;
            komut.CommandType = CommandType.StoredProcedure;
            komut.CommandText = "usp_TcListele";
            komut.Parameters.Add("@TcNo", SqlDbType.BigInt).Value = TcNo;
            SqlDataAdapter da = new SqlDataAdapter(komut);
            DataTable dt = new DataTable();
            da.Fill(dt);
            baglanti.Close();
            return dt;
        }
        public DataTable TarihListele()
        {
            BaglantiAc();
            SqlCommand komut = new SqlCommand();
            komut.Connection = baglanti;
            komut.CommandType = CommandType.StoredProcedure;
            komut.CommandText = "usp_TarihListele";
            komut.Parameters.Add("@GirisTarih", SqlDbType.NVarChar,50).Value = giristarih;
            SqlDataAdapter da = new SqlDataAdapter(komut);
            DataTable dt = new DataTable();
            da.Fill(dt);
            baglanti.Close();
            return dt;
        }
        #endregion
        
    }
}
